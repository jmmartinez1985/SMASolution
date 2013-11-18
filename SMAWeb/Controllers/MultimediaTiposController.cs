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
    public class MultimediaTiposController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /MultimediaTipos/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.MT_MultimediaTipos.ToList());
        }

        //
        // GET: /MultimediaTipos/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id = 0)
        {
            MT_MultimediaTipos mt_multimediatipos = db.MT_MultimediaTipos.Find(id);
            if (mt_multimediatipos == null)
            {
                return HttpNotFound();
            }
            return View(mt_multimediatipos);
        }

        //
        // GET: /MultimediaTipos/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MultimediaTipos/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MT_MultimediaTipos mt_multimediatipos)
        {
            if (ModelState.IsValid)
            {
                db.MT_MultimediaTipos.Add(mt_multimediatipos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mt_multimediatipos);
        }

        //
        // GET: /MultimediaTipos/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id = 0)
        {
            MT_MultimediaTipos mt_multimediatipos = db.MT_MultimediaTipos.Find(id);
            if (mt_multimediatipos == null)
            {
                return HttpNotFound();
            }
            return View(mt_multimediatipos);
        }

        //
        // POST: /MultimediaTipos/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MT_MultimediaTipos mt_multimediatipos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mt_multimediatipos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mt_multimediatipos);
        }

        //
        // GET: /MultimediaTipos/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id = 0)
        {
            MT_MultimediaTipos mt_multimediatipos = db.MT_MultimediaTipos.Find(id);
            if (mt_multimediatipos == null)
            {
                return HttpNotFound();
            }
            return View(mt_multimediatipos);
        }

        //
        // POST: /MultimediaTipos/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MT_MultimediaTipos mt_multimediatipos = db.MT_MultimediaTipos.Find(id);
            db.MT_MultimediaTipos.Remove(mt_multimediatipos);
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