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

namespace SMAWeb.Controllers
{
    public class AnunciosController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Anuncios/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            //var an_anuncios = db.AN_Anuncios.Include(a => a.SBS_SubCategoriaServicio).Include(a => a.ST_Estatus).Include(a => a.UserProfile);
            //return View(an_anuncios.ToList());
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
                        firstImage = item.AE_AnunciosExtras.FirstOrDefault().AN_Imagen;
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
            //var an_anuncios = db.AN_Anuncios.Include(a => a.SBS_SubCategoriaServicio).
            //    Include(a => a.ST_Estatus).Include(a => a.UserProfile)
            //    .Where(c => c.UserId == UserId);
           // return View(an_anuncios.ToList());

            int UserId = UserId = WebSecurity.CurrentUserId;

            var allAnunciosList = new List<AN_Anuncios>();
            List<AnunciosViewModel> viewModelAnuncios = new List<AnunciosViewModel>();
            using (Entities model = new Entities())
            {
                allAnunciosList = model.AN_Anuncios.OrderBy(c => c.AN_Fecha).Where(acc => acc.ST_Id == 1 && acc.UserId == UserId).ToList();

                foreach (var item in allAnunciosList)
                {
                    string username = item.UserProfile.Name;
                    string statusDesc = item.ST_Estatus.ST_Descripcion;
                    var categoria = item.SBS_SubCategoriaServicio.CD_CategoriaServicio.CD_Descripcion;
                    var firstImage = string.Empty;
                    if (item.AE_AnunciosExtras.FirstOrDefault() != null)
                    {
                        firstImage = item.AE_AnunciosExtras.FirstOrDefault().AN_Imagen;
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
        //
        // GET: /Anuncios/Details/5

        public ActionResult Details(int id = 0)
        {
            AN_Anuncios an_anuncios = db.AN_Anuncios.Find(id);
            if (an_anuncios == null)
            {
                return HttpNotFound();
            }
            return View(an_anuncios);
        }

        //
        // GET: /Anuncios/Create

        public ActionResult Create()
        {
            ViewBag.SBS_Id = new SelectList(db.SBS_SubCategoriaServicio, "SBS_Id", "SBS_Descripcion");
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion");
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName");
            return View();
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
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SBS_Id = new SelectList(db.SBS_SubCategoriaServicio, "SBS_Id", "SBS_Descripcion", an_anuncios.SBS_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", an_anuncios.ST_Id);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", an_anuncios.UserId);
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
            ViewBag.SBS_Id = new SelectList(db.SBS_SubCategoriaServicio, "SBS_Id", "SBS_Descripcion", an_anuncios.SBS_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", an_anuncios.ST_Id);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", an_anuncios.UserId);
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
            ViewBag.SBS_Id = new SelectList(db.SBS_SubCategoriaServicio, "SBS_Id", "SBS_Descripcion", an_anuncios.SBS_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", an_anuncios.ST_Id);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", an_anuncios.UserId);
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
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AN_Anuncios an_anuncios = db.AN_Anuncios.Find(id);
            db.AN_Anuncios.Remove(an_anuncios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult LoadUplaoder()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}