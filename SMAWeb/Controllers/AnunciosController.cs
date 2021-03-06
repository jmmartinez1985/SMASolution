﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMAWeb.Models;
using SMAWeb.Filters;
using WebMatrix.WebData;
using SMAWeb.Extensions;
using Newtonsoft.Json.Linq;
using System.Transactions;

namespace SMAWeb.Controllers
{
    public class AnunciosController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /Anuncios/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var allAnunciosList = new List<AN_Anuncios>();
            List<AnunciosViewModel> viewModelAnuncios = new List<AnunciosViewModel>();
            using (Entities model = new Entities())
            {
                allAnunciosList = model.AN_Anuncios.OrderByDescending(c => c.AN_Fecha).ToList();
                foreach (var item in allAnunciosList)
                {
                    string username = item.UserProfile.Name;
                    string statusDesc = item.ST_Estatus.ST_Descripcion;
                    var categoria = item.SBS_SubCategoriaServicio.CD_CategoriaServicio.CD_Descripcion;
                    var firstImage = string.Empty;
                    if (item.AE_AnunciosExtras.FirstOrDefault() != null)
                    {
                        firstImage = item.AE_AnunciosExtras.FirstOrDefault().AN_ImagenUrl;
                    }

                    string urlimg = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
                    var formatted = firstImage.Replace("~", "");
                    if (formatted.StartsWith("/"))
                        formatted = formatted.Remove(0, 1);
                    firstImage = urlimg + formatted;


                    viewModelAnuncios.Add(new AnunciosViewModel
                    {
                        Usuario = username,
                        EstatusDescription = statusDesc,
                        AnunciosInfo = item,
                        CategoriaDescripcion = categoria,
                        FirstImage = firstImage
                    });

                }
            }
            if (viewModelAnuncios == null || viewModelAnuncios.Count == 0)
            {
                return HttpNotFound();
            }
            return View(viewModelAnuncios);
        }


        [Authorize(Roles = "Users, Admin")]
        public ActionResult GetAnunciosByUser()
        {
            int UserId = UserId = WebSecurity.CurrentUserId;
            var allAnunciosList = new List<AN_Anuncios>();
            List<AnunciosViewModel> viewModelAnuncios = new List<AnunciosViewModel>();
            using (Entities model = new Entities())
            {
                //allAnunciosList = model.AN_Anuncios.OrderBy(c => c.AN_Fecha).Where(acc => acc.ST_Id == 1 && acc.UserId == UserId).ToList();
                allAnunciosList = model.AN_Anuncios.OrderBy(c => c.AN_Fecha).Where(acc => acc.UserId == UserId && (acc.ST_Id == 1 | acc.ST_Id == 2 | acc.ST_Id == 9)).ToList();


                var categoriasList = new List<Categoria>();
                db.CD_CategoriaServicio.ToList().ForEach(c =>
                {
                    var subCatList = new List<SubCategorias>();

                    c.SBS_SubCategoriaServicio.ToList().ForEach(sb =>
                    {
                        subCatList.Add(new SubCategorias { SubCatId = sb.SBS_Id, SubCatDesc = sb.SBS_Descripcion });
                    });
                    categoriasList.Add(new Categoria
                    {
                        CatId = c.CD_Id,
                        CatDesc = c.CD_Descripcion,
                        SubCatCollection = subCatList
                    });
                });



                ViewBag.Categories = categoriasList;

                foreach (var item in allAnunciosList)
                {
                    string username = item.UserProfile.Name;
                    string statusDesc = item.ST_Estatus.ST_Descripcion;
                    var categoria = item.SBS_SubCategoriaServicio.CD_CategoriaServicio.CD_Descripcion;
                    var firstImage = string.Empty;
                    if (item.AE_AnunciosExtras.FirstOrDefault() != null)
                    {
                        firstImage = item.AE_AnunciosExtras.FirstOrDefault().AN_ImagenUrl;
                    }
                    else
                    {
                        firstImage = item.UserProfile.Image == null ? "~/Images/No_Profile.jpg" : item.UserProfile.Image;
                    }

                    var getRating = model.SEL_ValoracionAnuncios(item.AN_Id).FirstOrDefault();


                    string urlimg = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
                    var formatted = firstImage.Replace("~", "");
                    if (formatted.StartsWith("/"))
                        formatted = formatted.Remove(0, 1);
                    firstImage = urlimg + formatted;


                    viewModelAnuncios.Add(new AnunciosViewModel
                    {
                        Usuario = username,
                        EstatusDescription = statusDesc,
                        AnunciosInfo = item,
                        CategoriaDescripcion = categoria,
                        FirstImage = firstImage,
                        Rating = getRating
                    });

                }
            }
            if (viewModelAnuncios == null || viewModelAnuncios.Count == 0)
            {
                //return HttpNotFound();
            }
            return View(viewModelAnuncios);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetLastAnuncios()
        {
            var allAnunciosList = new List<AN_Anuncios>();
            List<AnunciosViewModel> viewModelAnuncios = new List<AnunciosViewModel>();
            using (Entities model = new Entities())
            {
                allAnunciosList = model.AN_Anuncios.OrderByDescending(day => day.AN_Fecha).Where(acc => acc.ST_Id == 1).Take(3).ToList();

                foreach (var item in allAnunciosList)
                {
                    string username = item.UserProfile.Name;
                    string statusDesc = item.ST_Estatus.ST_Descripcion;
                    var categoria = item.SBS_SubCategoriaServicio.CD_CategoriaServicio.CD_Descripcion;
                    var firstImage = string.Empty;
                    if (item.AE_AnunciosExtras.FirstOrDefault() != null)
                    {
                        firstImage = item.AE_AnunciosExtras.FirstOrDefault().AN_ImagenUrl;
                    }
                    else
                    {
                        firstImage = item.UserProfile.Image == null ? "~/Images/No_Profile.jpg" : item.UserProfile.Image;
                    }

                    string urlimg = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
                    var formatted = firstImage.Replace("~", "");
                    if (formatted.StartsWith("/"))
                        formatted = formatted.Remove(0, 1);
                    firstImage = urlimg + formatted;

                    string descripcion = string.Empty;
                    descripcion = item.AN_Descripcion.Substring(0, item.AN_Descripcion.Length < 112 ? item.AN_Descripcion.Length : 112);
                    if (descripcion.LastIndexOf(' ') > 0)
                        descripcion = descripcion.Substring(0, descripcion.LastIndexOf(' '));

                    descripcion += "...";

                    item.AN_Descripcion = descripcion;

                    viewModelAnuncios.Add(new AnunciosViewModel
                    {
                        Usuario = username,
                        EstatusDescription = statusDesc,
                        AnunciosInfo = item,
                        CategoriaDescripcion = categoria,
                        FirstImage = firstImage
                    });

                }
            }
            if (viewModelAnuncios == null || viewModelAnuncios.Count == 0)
            {
                return HttpNotFound();
            }
            return Json((viewModelAnuncios).SerializeToJson());

        }


        public ActionResult GetInformationAnuncios(FormCollection form)
        {
            var allAnunciosList = new List<AN_Anuncios>();

            var category = string.IsNullOrEmpty(form["Categoria"]) ? default(int) : int.Parse(form["Categoria"].ToString());
            var subcategoria = string.IsNullOrEmpty(form["SubCategoria"]) ? default(int) : int.Parse(form["SubCategoria"].ToString());
            var lugar = string.IsNullOrEmpty(form["Lugar"]) ? default(string) : form["Lugar"].ToString();
            var descripcion = string.IsNullOrEmpty(form["Descripcion"]) ? default(string) : form["Descripcion"].ToString();


            List<AnunciosViewModel> viewModelAnuncios = new List<AnunciosViewModel>();
            using (Entities model = new Entities())
            {

                allAnunciosList = db.Get_AdvanceSearch(category, subcategoria, descripcion, lugar).ToList();

                foreach (var item in allAnunciosList)
                {
                    string username = item.UserProfile.Name;
                    string statusDesc = item.ST_Estatus.ST_Descripcion;
                    var categoria = item.SBS_SubCategoriaServicio.CD_CategoriaServicio.CD_Descripcion;
                    var firstImage = string.Empty;
                    if (item.AE_AnunciosExtras.FirstOrDefault() != null)
                    {
                        firstImage = item.AE_AnunciosExtras.FirstOrDefault().AN_ImagenUrl;
                    }
                    else
                    {
                        firstImage = item.UserProfile.Image == null ? "~/Images/No_Profile.jpg" : item.UserProfile.Image;
                    }

                    var getRating = model.SEL_ValoracionAnuncios(item.AN_Id).FirstOrDefault();
                    string urlimg = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
                    var formatted = firstImage.Replace("~", "");
                    if (formatted.StartsWith("/"))
                        formatted = formatted.Remove(0, 1);
                    firstImage = urlimg + formatted;

                    List<RW_Reviews> rvList = new List<RW_Reviews>();
                    model.SS_SolicitudServicio.Where(c => c.AN_Id == item.AN_Id).AsParallel().ToList().ForEach(
                        c =>
                        {
                            c.RW_Reviews.AsParallel().ToList().ForEach(i => rvList.Add(i));
                        });

                    var number = 0;
                    item.SS_SolicitudServicio.AsParallel().ToList().ForEach((counter) =>
                    {
                        number += counter.RW_Reviews.Count;
                    });
                    //viewModelAnuncios.Add(new AnunciosViewModel
                    //{
                    //    Usuario = username,
                    //    EstatusDescription = statusDesc,
                    //    AnunciosInfo = item,
                    //    CategoriaDescripcion = categoria,
                    //    FirstImage = firstImage,
                    //    Rating = getRating,
                    //    Comments = number,
                    //});

                    viewModelAnuncios.Add(new AnunciosViewModel
                    {
                        Usuario = username,
                        EstatusDescription = statusDesc,
                        AnunciosInfo = item,
                        CategoriaDescripcion = categoria,
                        FirstImage = firstImage,
                        Rating = getRating,
                        Comments = number,
                    });

                }
            }
            if (viewModelAnuncios == null || viewModelAnuncios.Count == 0)
            {
                return Json(new { Error = "No se encontraron registros" });
            }
            var anuncios = viewModelAnuncios.SerializeToJson();
            return Json(anuncios);
        }

        //
        // GET: /Anuncios/Details/5
        //[Authorize(Roles = "Users, Admin")]
        public ActionResult Details(int id = 0)
        {
            AN_Anuncios an_anuncios = db.AN_Anuncios.Find(id);
            if (an_anuncios == null)
            {
                return HttpNotFound("Page Not Found");
            }
            var ListReview = new List<ContentReviews>();
            an_anuncios.SS_SolicitudServicio.ToList().ForEach(
                an =>
                {
                    ListReview.Add(new ContentReviews { ReviewsList = an.RW_Reviews, SolicitudProfilePic = an.UserProfile.Image });
                });


            ViewBag.ReviewFound = ListReview;

            ViewBag.SBS_Id = new SelectList(db.SBS_SubCategoriaServicio, "SBS_Id", "SBS_Descripcion");
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion");
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion");
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName");
            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion");
            return View(an_anuncios);
        }

        //
        // GET: /Anuncios/Create
        [Authorize(Roles = "Users")]
        public ActionResult Create()
        {
            AN_Anuncios an = new AN_Anuncios();
            an.ST_Id = 1;
            an.UserId = WebSecurity.CurrentUserId;
            an.AN_Fecha = System.DateTime.Now;
            an.AN_FechaExpiracion = System.DateTime.Now.AddMonths(3);
            ViewBag.SBS_Id = new SelectList(db.SBS_SubCategoriaServicio.OrderBy(x => x.SBS_Descripcion), "SBS_Id", "SBS_Descripcion");
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion");
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion");
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName");
            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio.OrderBy(x => x.CD_Descripcion), "CD_Id", "CD_Descripcion");
            return View(an);

        }

        //
        // POST: /Anuncios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Users")]
        public ActionResult Create(AN_Anuncios an_anuncios)
        {
            if (ModelState.IsValid)
            {
                bool wasNotApproved = Extensions.ExtensionHelper.NotApproved(an_anuncios.AN_Descripcion);
                if (wasNotApproved)
                {
                    an_anuncios.ST_Id = 7;
                }
                else
                    an_anuncios.ST_Id = 1;
                db.AN_Anuncios.Add(an_anuncios);
                var Anuncio = db.SaveChanges<AN_Anuncios>(an_anuncios);
                if (Anuncio != null)
                {
                    string directorio = System.Configuration.ConfigurationManager.AppSettings["ContenidoMultimedia"];
                    if (!System.IO.Directory.Exists(Server.MapPath(directorio + Anuncio.AN_Id)))
                        System.IO.Directory.CreateDirectory(Server.MapPath(directorio + Anuncio.AN_Id));
                }
                HttpContext.Session["Anuncio"] = Anuncio.AN_Id;
                if (Anuncio.ST_Id == 7)
                    base.SendEmailNotification(an_anuncios.AN_Id, Plantillas.AnuncioReview);

                return PartialView("LoadUplaoder");
            }

            ViewBag.SBS_Id = new SelectList(db.SBS_SubCategoriaServicio, "SBS_Id", "SBS_Descripcion", an_anuncios.SBS_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", an_anuncios.ST_Id);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", an_anuncios.UserId);
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion", an_anuncios.PA_Id);
            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion", an_anuncios.CD_Id);
            return View(an_anuncios);
        }


        public JsonResult ValidateAnuncioCreate()
        {
            using (var db = new Entities())
            {
                if (db.AN_Anuncios.Count(c => c.UserId == WebSecurity.CurrentUserId) >=
                    db.UserProfile.Where(c => c.UserId == WebSecurity.CurrentUserId).FirstOrDefault().MB_Membresia.MP_AnunciosQty)
                {
                    return Json(new { ErrorMessage = "No puede agregar más anuncios ya que supera el limite de anuncios permitidos para su membresia" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { UrlAnuncios = Url.Action("Create", "Anuncios") }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        //
        // GET: /Anuncios/Edit/5
        [Authorize(Roles = "Users")]
        public ActionResult Edit(int id = 0)
        {
            AN_Anuncios an_anuncios = db.AN_Anuncios.Find(id);
            if (an_anuncios == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResourcesCount = an_anuncios.AE_AnunciosExtras.Count;
            HttpContext.Session["Anuncio"] = an_anuncios.AN_Id;
            var subcategorias = db.SBS_SubCategoriaServicio.Where(c => c.CD_Id == an_anuncios.CD_Id);
            ViewBag.SBS_Id = new SelectList(subcategorias, "SBS_Id", "SBS_Descripcion", an_anuncios.SBS_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", an_anuncios.ST_Id);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", an_anuncios.UserId);


            //var selecteditems = new List<SelectListItem>();

            //db.PA_Paises.ToList().ForEach(item => 
            //{
            //    selecteditems.Add(new SelectListItem { Text = item.PA_Descripcion, Value = item.PA_Id.ToString(), Selected = item.PA_Id == an_anuncios.PA_Id ? true : false });
            //});

            ViewBag.PA_Id = db.PA_Paises.ToList();
            ViewData["Paises"] = new SelectList(db.PA_Paises.ToList(), "PA_Id", "PA_Descripcion", an_anuncios.PA_Id);// your dropdownlist


            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion", an_anuncios.CD_Id);
            return View(an_anuncios);
        }

        //
        // POST: /Anuncios/Edit/5
        [Authorize(Roles = "Users")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AN_Anuncios an_anuncios)
        {
            if (ModelState.IsValid)
            {
                bool wasNotApproved = Extensions.ExtensionHelper.NotApproved(an_anuncios.AN_Descripcion);
                if (wasNotApproved)
                {
                    an_anuncios.ST_Id = 7;
                    base.SendEmailNotification(an_anuncios.AN_Id, Plantillas.AnuncioReview);
                }
                else
                    an_anuncios.ST_Id = 1;
                db.Entry(an_anuncios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetAnunciosByUser");
            }
            ViewBag.ResourcesCount = an_anuncios.AE_AnunciosExtras.Count;
            an_anuncios.AE_AnunciosExtras = db.AE_AnunciosExtras.Where(c => c.AN_Id == an_anuncios.AN_Id).ToList();
            
            ViewBag.SBS_Id = new SelectList(db.SBS_SubCategoriaServicio.OrderBy(x => x.SBS_Descripcion), "SBS_Id", "SBS_Descripcion");
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion");
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion");
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName");
            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio.OrderBy(x => x.CD_Descripcion), "CD_Id", "CD_Descripcion");

            return View(an_anuncios);
        }

        //
        // GET: /Anuncios/Delete/5
        [Authorize(Roles = "Users")]
        public ActionResult Delete(int id = 0)
        {
            AN_Anuncios an_anuncios = db.AN_Anuncios.Find(id);
            if (an_anuncios == null)
            {
                return HttpNotFound();
            }
            return View(an_anuncios);
        }

        //
        // POST: /Anuncios/Delete/5
        [Authorize(Roles = "Users, Admin")]
        //[HttpPost, ActionName("Delete, Admin")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AN_Anuncios an_anuncios = db.AN_Anuncios.Find(id);

            using (var scope = new TransactionScope())
            {
                //if (an_anuncios.SS_SolicitudServicio.All(c => c.ST_Id == 1))
                //{
                an_anuncios.SS_SolicitudServicio.AsParallel().ToList().ForEach(sol =>
                {
                    //db.SS_SolicitudServicio.Remove(sol);
                    sol.ST_Id = 7;
                    db.Entry(sol).State = EntityState.Modified;
                    sol.RW_Reviews.AsParallel().ToList().ForEach(rev =>
                    {
                        db.Entry(sol).State = EntityState.Modified;
                        rev.ST_Id = 7;
                    });
                });
                db.Entry(an_anuncios).State = EntityState.Modified;
                an_anuncios.ST_Id = 7;
                db.SaveChanges();
                scope.Complete();
                //}
                //else
                //{
                //    throw new Exception("No se puede borrar este anuncio ya esta sirviendo de referencia para solicitud de servicio, por favor proceda a desactivar el mismo.");
                //}
            }
            if (Request.IsAjaxRequest())
            {
                return Json(new { redirectToUrl = Url.Action("GetAnunciosByUser", "Anuncios") });
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Users, Admin")]
        [HttpPost, ActionName("Inactivate")]
        //[ValidateAntiForgeryToken]
        public ActionResult InactivateAnuncio(int id)
        {
            AN_Anuncios an_anuncios = db.AN_Anuncios.Find(id);
            //activar y desactivar
            if (an_anuncios.ST_Id == 1)
                an_anuncios.ST_Id = 2;
            else
                an_anuncios.ST_Id = 1;

            db.Entry(an_anuncios).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("El anuncio no puedo ser inactivado, intente más tarde o pongase en contacto con el administrador.");
            }
            if (Request.IsAjaxRequest())
            {
                return Json(new { redirectToUrl = Url.Action("GetAnunciosByUser", "Anuncios") });
            }
            return RedirectToAction("Index");
        }

        public ActionResult LoadUplaoder()
        {
            if (Request.IsAjaxRequest())
                return PartialView("LoadUplaoder");
            return View();
        }

        [Authorize(Roles = "Users, Admin")]
        [HttpPost, ActionName("Spam")]
        //[ValidateAntiForgeryToken]
        public ActionResult SpamAnuncio(int id)
        {
            AN_Anuncios an_anuncios = db.AN_Anuncios.Find(id);
            //activar y desactivar
            if (an_anuncios.ST_Id == 1)
                an_anuncios.ST_Id = 10;
            else
                an_anuncios.ST_Id = 1;

            db.Entry(an_anuncios).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
                base.SendEmailNotification(id, Plantillas.AnuncioSpam);
            }
            catch (Exception)
            {
                throw new Exception("El anuncio no puedo ser reportado como spam, intente más tarde o pongase en contacto con el administrador.");
            }
            if (Request.IsAjaxRequest())
            {
                return Json(new { redirectToUrl = Url.Action("Index", "Home") });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }



}