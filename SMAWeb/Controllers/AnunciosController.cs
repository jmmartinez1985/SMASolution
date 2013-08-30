using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMAWeb.Models;
using SMAWeb.Filters;

namespace SMAWeb.Controllers
{
    public class AnunciosController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Anuncios/
        [AdminRoleFilter]
        public ActionResult Index()
        {
            var an_anuncios = db.AN_Anuncios.Include(a => a.SBS_SubCategoriaServicio).Include(a => a.ST_Estatus).Include(a => a.UserProfile);
            return View(an_anuncios.ToList());
        }

        [UserRoleFilter]
        public ActionResult GetAnunciosByUser(int UserId)
        {
          
            var an_anuncios = db.AN_Anuncios.Include(a => a.SBS_SubCategoriaServicio).
                Include(a => a.ST_Estatus).Include(a => a.UserProfile)
                .Where(c => c.UserId == UserId);
            return View(an_anuncios.ToList());
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}