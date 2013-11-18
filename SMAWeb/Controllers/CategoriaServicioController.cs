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
    public class CategoriaServicioController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /CategoriaServicio/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.CD_CategoriaServicio.ToList());
        }

        ////
        //// GET: /CategoriaServicio/Details/5
        //[Authorize(Roles = "Admin")]
        //public ActionResult Details(int id = 0)
        //{
        //    CD_CategoriaServicio cd_categoriaservicio = db.CD_CategoriaServicio.Find(id);
        //    if (cd_categoriaservicio == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cd_categoriaservicio);
        //}


        //
        // GET: /CategoriaServicio/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            CD_CategoriaServicio cat = new CD_CategoriaServicio();
            cat.CD_Id = 1;
            return View(cat);
        }

        //
        // POST: /CategoriaServicio/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CD_CategoriaServicio cd_categoriaservicio)
        {
            if (ModelState.IsValid)
            {
                db.CD_CategoriaServicio.Add(cd_categoriaservicio);
                db.SaveChanges();

                if (Request.IsAjaxRequest())
                {
                    return Json(new { wasSuccess = true });
                }
                return RedirectToAction("Index");
            }
            if (Request.IsAjaxRequest())
            {
                return Json(new { wasSuccess = false });
            }
            return View(cd_categoriaservicio);
        }



        //
        // GET: /CategoriaServicio/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id = 0)
        {
            CD_CategoriaServicio cd_categoriaservicio = db.CD_CategoriaServicio.Find(id);
            if (cd_categoriaservicio == null)
            {
                return HttpNotFound();
            }
            return View(cd_categoriaservicio);
        }

        //
        // POST: /CategoriaServicio/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(CD_CategoriaServicio cd_categoriaservicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cd_categoriaservicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cd_categoriaservicio);
        }

        //
        // GET: /CategoriaServicio/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    CD_CategoriaServicio cd_categoriaservicio = db.CD_CategoriaServicio.Find(id);
        //    if (cd_categoriaservicio == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cd_categoriaservicio);
        //}

        //
        // POST: /CategoriaServicio/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CD_CategoriaServicio cd_categoriaservicio = db.CD_CategoriaServicio.Find(id);
        //    db.CD_CategoriaServicio.Remove(cd_categoriaservicio);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}