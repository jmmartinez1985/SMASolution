using System;
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
                allAnunciosList = model.AN_Anuncios.OrderBy(c => c.AN_Fecha).ToList();
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
                allAnunciosList = model.AN_Anuncios.OrderBy(c => c.AN_Fecha).Where(acc => acc.ST_Id == 1 && acc.UserId == UserId).ToList();


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

        //
        // GET: /Anuncios/Details/5
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



                    viewModelAnuncios.Add(new AnunciosViewModel
                    {
                        Usuario = username,
                        EstatusDescription = statusDesc,
                        AnunciosInfo = item,
                        CategoriaDescripcion = categoria,
                        FirstImage = firstImage,
                        Rating = getRating,
                        ReviewList = rvList
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
        public ActionResult Create()
        {
            AN_Anuncios an = new AN_Anuncios();
            an.ST_Id = 1;
            an.UserId = WebSecurity.CurrentUserId;
            an.AN_Fecha = System.DateTime.Now;
            an.AN_FechaExpiracion = System.DateTime.Now.AddMonths(3);
            ViewBag.SBS_Id = new SelectList(db.SBS_SubCategoriaServicio, "SBS_Id", "SBS_Descripcion");
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion");
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion");
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName");
            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion");
            return View(an);

        }

        //
        // POST: /Anuncios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AN_Anuncios an_anuncios)
        {
            if (ModelState.IsValid)
            {
                db.AN_Anuncios.Add(an_anuncios);


                var Anuncio = db.SaveChanges<AN_Anuncios>(an_anuncios);
                if (Anuncio != null)
                {
                    string directorio = System.Configuration.ConfigurationManager.AppSettings["ContenidoMultimedia"];
                    if (!System.IO.Directory.Exists(Server.MapPath(directorio + Anuncio.AN_Id)))
                        System.IO.Directory.CreateDirectory(Server.MapPath(directorio + Anuncio.AN_Id));
                }
                HttpContext.Session["Anuncio"] = Anuncio.AN_Id;
                return PartialView("LoadUplaoder");
            }

            ViewBag.SBS_Id = new SelectList(db.SBS_SubCategoriaServicio, "SBS_Id", "SBS_Descripcion", an_anuncios.SBS_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", an_anuncios.ST_Id);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", an_anuncios.UserId);
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion", an_anuncios.PA_Id);
            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion", an_anuncios.CD_Id);
            return View(an_anuncios);
        }

        //
        // GET: /Anuncios/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AN_Anuncios an_anuncios = db.AN_Anuncios.Find(id);
            if (an_anuncios == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResourcesCount = an_anuncios.AE_AnunciosExtras.Count;
            HttpContext.Session["Anuncio"] = an_anuncios.AN_Id;
            ViewBag.SBS_Id = new SelectList(db.SBS_SubCategoriaServicio, "SBS_Id", "SBS_Descripcion", an_anuncios.SBS_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", an_anuncios.ST_Id);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", an_anuncios.UserId);
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion");
            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion");
            return View(an_anuncios);
        }

        //
        // POST: /Anuncios/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AN_Anuncios an_anuncios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(an_anuncios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResourcesCount = an_anuncios.AE_AnunciosExtras.Count;
            an_anuncios.AE_AnunciosExtras = db.AE_AnunciosExtras.Where(c => c.AN_Id == an_anuncios.AN_Id).ToList();

            ViewBag.SBS_Id = new SelectList(db.SBS_SubCategoriaServicio, "SBS_Id", "SBS_Descripcion", an_anuncios.SBS_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", an_anuncios.ST_Id);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", an_anuncios.UserId);
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion");
            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion");
            return View(an_anuncios);
        }

        //
        // GET: /Anuncios/Delete/5

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

        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AN_Anuncios an_anuncios = db.AN_Anuncios.Find(id);
            db.AN_Anuncios.Remove(an_anuncios);
            db.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return Json(new { redirectToUrl = Url.Action("GetAnunciosByUser", "Anuncios") });
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Inactivate")]
        //[ValidateAntiForgeryToken]
        public ActionResult InactivateAnuncio(int id)
        {
            AN_Anuncios an_anuncios = db.AN_Anuncios.Find(id);
            an_anuncios.ST_Id = 2;
            db.Entry(an_anuncios).State = EntityState.Modified;
            db.SaveChanges();
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }



}