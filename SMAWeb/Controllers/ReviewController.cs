using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMAWeb.Models;
using SMAWeb.Filters;
using System.Transactions;

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
        
        [HttpGet]
        [Authorize(Roles = "Users")]
        [IsValidReviewFilter]
        public ActionResult Create(int id = 0)
        {
            RW_Reviews rw_reviews = new RW_Reviews();
            rw_reviews.RW_Fecha = System.DateTime.Now;
            rw_reviews.RW_Id = 0;
            rw_reviews.SS_Id = id;
            rw_reviews.RW_Rate = 0;
            return View(rw_reviews);
        }

        //
        // POST: /Review/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Users")]
        public ActionResult Create(RW_Reviews rw_reviews)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    using (TransactionScope tr = new TransactionScope())
                    {
                        db.RW_Reviews.Add(rw_reviews);
                        var solicitud = db.SS_SolicitudServicio.Find(rw_reviews.SS_Id);
                        solicitud.ST_Id = 5;
                        db.Entry(solicitud).State = EntityState.Modified;
                        db.SaveChanges();
                        tr.Complete();
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.SS_Id = new SelectList(db.SS_SolicitudServicio, "SS_Id", "SS_Id", rw_reviews.SS_Id);
            return View(rw_reviews);
        }

        public ActionResult ReviewSubmitted()
        {
            return View();
        }

        public ActionResult NoReviewAllowed()
        {
            return View();
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