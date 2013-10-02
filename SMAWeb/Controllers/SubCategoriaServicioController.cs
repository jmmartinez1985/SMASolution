using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMAWeb.Models;

namespace SMAWeb.Controllers
{
    public class SubCategoriaServicioController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /SubCategoriaServicio/

        public ActionResult Index()
        {
            var sbs_subcategoriaservicio = db.SBS_SubCategoriaServicio.Include(s => s.CD_CategoriaServicio);
            return View(sbs_subcategoriaservicio.ToList());
        }
        // GET: /SubCategoriaServicio/1
        public ActionResult Index(int Cat)
        {
            var sbs_subcategoriaservicio = db.SBS_SubCategoriaServicio.Include(s => s.CD_CategoriaServicio).Where(c=> c.CD_Id == Cat);
            return View(sbs_subcategoriaservicio.ToList());
        }


        public JsonResult GetSubCategories(int Cat)
        {
            var sbs_subcategoriaservicio = db.SBS_SubCategoriaServicio.Include(s => s.CD_CategoriaServicio).Where(c => c.CD_Id == Cat);
            return Json(sbs_subcategoriaservicio.ToList());
        }

        //
        // GET: /SubCategoriaServicio/Details/5

        public ActionResult Details(int id = 0)
        {
            SBS_SubCategoriaServicio sbs_subcategoriaservicio = db.SBS_SubCategoriaServicio.Find(id);
            if (sbs_subcategoriaservicio == null)
            {
                return HttpNotFound();
            }
            return View(sbs_subcategoriaservicio);
        }

        //
        // GET: /SubCategoriaServicio/Create

        public ActionResult Create()
        {
            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion");
            return View();
        }

        //
        // POST: /SubCategoriaServicio/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SBS_SubCategoriaServicio sbs_subcategoriaservicio)
        {
            if (ModelState.IsValid)
            {
                db.SBS_SubCategoriaServicio.Add(sbs_subcategoriaservicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion", sbs_subcategoriaservicio.CD_Id);
            return View(sbs_subcategoriaservicio);
        }

        //
        // GET: /SubCategoriaServicio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SBS_SubCategoriaServicio sbs_subcategoriaservicio = db.SBS_SubCategoriaServicio.Find(id);
            if (sbs_subcategoriaservicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion", sbs_subcategoriaservicio.CD_Id);
            return View(sbs_subcategoriaservicio);
        }

        //
        // POST: /SubCategoriaServicio/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SBS_SubCategoriaServicio sbs_subcategoriaservicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sbs_subcategoriaservicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion", sbs_subcategoriaservicio.CD_Id);
            return View(sbs_subcategoriaservicio);
        }

        //
        // GET: /SubCategoriaServicio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SBS_SubCategoriaServicio sbs_subcategoriaservicio = db.SBS_SubCategoriaServicio.Find(id);
            if (sbs_subcategoriaservicio == null)
            {
                return HttpNotFound();
            }
            return View(sbs_subcategoriaservicio);
        }

        //
        // POST: /SubCategoriaServicio/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SBS_SubCategoriaServicio sbs_subcategoriaservicio = db.SBS_SubCategoriaServicio.Find(id);
            db.SBS_SubCategoriaServicio.Remove(sbs_subcategoriaservicio);
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