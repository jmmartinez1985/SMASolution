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
    public class RegionController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /Region/

        public ActionResult Index()
        {
            return View(db.REG_Region.ToList());
        }

        //
        // GET: /Region/Details/5

        public ActionResult Details(int id = 0)
        {
            REG_Region reg_region = db.REG_Region.Find(id);
            if (reg_region == null)
            {
                return HttpNotFound();
            }
            return View(reg_region);
        }

        //
        // GET: /Region/Create

        public ActionResult Create()
        {
            REG_Region reg = new REG_Region();
            reg.REG_Id = 1;
            return View(reg);
        }

        //
        // POST: /Region/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(REG_Region reg_region)
        {
            if (ModelState.IsValid)
            {
                db.REG_Region.Add(reg_region);
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
            return View(reg_region);
        }

        //
        // GET: /Region/Edit/5

        public ActionResult Edit(int id = 0)
        {
            REG_Region reg_region = db.REG_Region.Find(id);
            if (reg_region == null)
            {
                return HttpNotFound();
            }
            return View(reg_region);
        }

        //
        // POST: /Region/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(REG_Region reg_region)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reg_region).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reg_region);
        }

        //
        // GET: /Region/Delete/5

        public ActionResult Delete(int id = 0)
        {
            REG_Region reg_region = db.REG_Region.Find(id);
            if (reg_region == null)
            {
                return HttpNotFound();
            }
            return View(reg_region);
        }

        //
        // POST: /Region/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REG_Region reg_region = db.REG_Region.Find(id);
            db.REG_Region.Remove(reg_region);
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