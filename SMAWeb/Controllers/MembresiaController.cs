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
    public class MembresiaController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /Membresia/

        public ActionResult Index()
        {
            return View(db.MB_Membresia.ToList());
        }

        //
        // GET: /Membresia/Details/5

        public ActionResult Details(int id = 0)
        {
            MB_Membresia mb_membresia = db.MB_Membresia.Find(id);
            if (mb_membresia == null)
            {
                return HttpNotFound();
            }
            return View(mb_membresia);
        }

        //
        // GET: /Membresia/Create

        public ActionResult Create()
        {
            MB_Membresia mem = new MB_Membresia();
            mem.MP_MemberShipId = 1;
            return View(mem);
        }

      
        //
        // POST: /Membresia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MB_Membresia mb_membresia)
        {
            if (ModelState.IsValid)
            {
                db.MB_Membresia.Add(mb_membresia);
                db.SaveChanges();

                if (Request.IsAjaxRequest()) 
                {

                    return Json(new { wasSuccess = true });
                }

                return RedirectToAction("Index");
            }
            if (Request.IsAjaxRequest())
            {
                return Json(new { wasSuccess = false});
            }
            return View(mb_membresia);
        }

        //
        // GET: /Membresia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MB_Membresia mb_membresia = db.MB_Membresia.Find(id);
            if (mb_membresia == null)
            {
                return HttpNotFound();
            }
            return View(mb_membresia);
        }

        //
        // POST: /Membresia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MB_Membresia mb_membresia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mb_membresia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mb_membresia);
        }

        //
        // GET: /Membresia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MB_Membresia mb_membresia = db.MB_Membresia.Find(id);
            if (mb_membresia == null)
            {
                return HttpNotFound();
            }
            return View(mb_membresia);
        }

        //
        // POST: /Membresia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MB_Membresia mb_membresia = db.MB_Membresia.Find(id);
            db.MB_Membresia.Remove(mb_membresia);
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