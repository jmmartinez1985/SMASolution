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
    public class FAQController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /FAQ/

        public ActionResult Index()
        {
            var faqs = db.FAQs.Include(f => f.ST_Estatus);
            return View(faqs.ToList());
        }

        //
        // GET: /FAQ/Details

        public ActionResult Details(int id = 0)
        {
            var faqs = db.FAQs.Include(f => f.ST_Estatus);
            return View(faqs.ToList());
        }

        //
        // GET: /FAQ/Create

        public ActionResult Create()
        {
            FAQs faq = new FAQs();
            faq.FAQ_Id = 1;
            faq.FAQ_Status = 1;
            ViewBag.FAQ_Status = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion");
            return View(faq);
        }

        //
        // POST: /FAQ/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FAQs faqs)
        {
            if (ModelState.IsValid)
            {
                db.FAQs.Add(faqs);
                db.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    //limpiar pantalla
                    return Json(new { wasSuccess = true });
                }
                return RedirectToAction("Index");
            }

            ViewBag.FAQ_Status = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", faqs.FAQ_Status);
            
            if (Request.IsAjaxRequest())
            {
                return Json(new { wasSuccess = false });
            }
            return View(faqs);
        }

        //
        // GET: /FAQ/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FAQs faqs = db.FAQs.Find(id);
            if (faqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.FAQ_Status = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", faqs.FAQ_Status);
            return View(faqs);
        }

        //
        // POST: /FAQ/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FAQs faqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faqs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FAQ_Status = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", faqs.FAQ_Status);
            return View(faqs);
        }

        //
        // GET: /FAQ/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FAQs faqs = db.FAQs.Find(id);
            if (faqs == null)
            {
                return HttpNotFound();
            }
            return View(faqs);
        }

        //
        // POST: /FAQ/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FAQs faqs = db.FAQs.Find(id);
            db.FAQs.Remove(faqs);
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