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
    public class EstatusController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /Estatus/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.ST_Estatus.ToList());
        }

        //
        // GET: /Estatus/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id = 0)
        {
            ST_Estatus st_estatus = db.ST_Estatus.Find(id);
            if (st_estatus == null)
            {
                return HttpNotFound();
            }
            return View(st_estatus);
        }

        //
        // GET: /Estatus/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Estatus/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ST_Estatus st_estatus)
        {
            if (ModelState.IsValid)
            {
                db.ST_Estatus.Add(st_estatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(st_estatus);
        }

        //
        // GET: /Estatus/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id = 0)
        {
            ST_Estatus st_estatus = db.ST_Estatus.Find(id);
            if (st_estatus == null)
            {
                return HttpNotFound();
            }
            return View(st_estatus);
        }

        //
        // POST: /Estatus/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ST_Estatus st_estatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(st_estatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(st_estatus);
        }

        //
        // GET: /Estatus/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id = 0)
        {
            ST_Estatus st_estatus = db.ST_Estatus.Find(id);
            if (st_estatus == null)
            {
                return HttpNotFound();
            }
            return View(st_estatus);
        }

        //
        // POST: /Estatus/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ST_Estatus st_estatus = db.ST_Estatus.Find(id);
            db.ST_Estatus.Remove(st_estatus);
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