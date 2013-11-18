using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMAWeb.Models;
using SMAWeb.Extensions;

namespace SMAWeb.Controllers
{
    public class SubCategoriaServicioController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /SubCategoriaServicio/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var sbs_subcategoriaservicio = db.SBS_SubCategoriaServicio.Include(s => s.CD_CategoriaServicio);
            return View(sbs_subcategoriaservicio.ToList());
        }


        // Creo que esto está demás no encontré donde se utilizaba y veo que el metodo de abajo hace lo mismo que este...!
        //// GET: /SubCategoriaServicio/1
        //public ActionResult Index(int Cat)
        //{
        //    var sbs_subcategoriaservicio = db.SBS_SubCategoriaServicio.Include(s => s.CD_CategoriaServicio).Where(c=> c.CD_Id == Cat);
        //    return View(sbs_subcategoriaservicio.ToList());
        //}


        public JsonResult GetSubCategories(int Cat)
        {
            var sbs_subcategoriaservicio = db.SBS_SubCategoriaServicio.Include(s => s.CD_CategoriaServicio).Where(c => c.CD_Id == Cat);

            var subcat = sbs_subcategoriaservicio.SerializeToJson();

            return Json(subcat);
        }

        //
        // GET: /SubCategoriaServicio/Details/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {

            SBS_SubCategoriaServicio subCat = new SBS_SubCategoriaServicio();
            subCat.SBS_Id = 1;

            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion");
            return View(subCat);
        }

        //
        // POST: /SubCategoriaServicio/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SBS_SubCategoriaServicio sbs_subcategoriaservicio)
        {
            if (ModelState.IsValid)
            {
                db.SBS_SubCategoriaServicio.Add(sbs_subcategoriaservicio);
                db.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { wasSuccess = true });
                }
                return RedirectToAction("Index");
            }

            ViewBag.CD_Id = new SelectList(db.CD_CategoriaServicio, "CD_Id", "CD_Descripcion", sbs_subcategoriaservicio.CD_Id);

            if (Request.IsAjaxRequest())
            {
                return Json(new { wasSuccess = false });
            }

            return View(sbs_subcategoriaservicio);
        }

        //
        // GET: /SubCategoriaServicio/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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