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
    public class ReviewController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Review/

        public ActionResult Index()
        {
            var rw_reviews = db.RW_Reviews.Include(r => r.SS_SolicitudServicio);
            return View(rw_reviews.ToList());
        }

        //
        // GET: /Review/Details/5

        public ActionResult Details(int id = 0)
        {
            RW_Reviews rw_reviews = db.RW_Reviews.Find(id);
            if (rw_reviews == null)
            {
                return HttpNotFound();
            }
            return View(rw_reviews);
        }

        //
        // GET: /Review/Create

        public ActionResult Create()
        {
            ViewBag.SS_Id = new SelectList(db.SS_SolicitudServicio, "SS_Id", "SS_Id");
            return View();
        }

        //
        // POST: /Review/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RW_Reviews rw_reviews)
        {
            if (ModelState.IsValid)
            {
                db.RW_Reviews.Add(rw_reviews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SS_Id = new SelectList(db.SS_SolicitudServicio, "SS_Id", "SS_Id", rw_reviews.SS_Id);
            return View(rw_reviews);
        }

        //
        // GET: /Review/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RW_Reviews rw_reviews = db.RW_Reviews.Find(id);
            if (rw_reviews == null)
            {
                return HttpNotFound();
            }
            ViewBag.SS_Id = new SelectList(db.SS_SolicitudServicio, "SS_Id", "SS_Id", rw_reviews.SS_Id);
            return View(rw_reviews);
        }

        //
        // POST: /Review/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RW_Reviews rw_reviews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rw_reviews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SS_Id = new SelectList(db.SS_SolicitudServicio, "SS_Id", "SS_Id", rw_reviews.SS_Id);
            return View(rw_reviews);
        }

        //
        // GET: /Review/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RW_Reviews rw_reviews = db.RW_Reviews.Find(id);
            if (rw_reviews == null)
            {
                return HttpNotFound();
            }
            return View(rw_reviews);
        }

        //
        // POST: /Review/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RW_Reviews rw_reviews = db.RW_Reviews.Find(id);
            db.RW_Reviews.Remove(rw_reviews);
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