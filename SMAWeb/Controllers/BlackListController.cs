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
    public class BlackListController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /BlackList/

        public ActionResult Index()
        {
            return View(db.BL_BlackList.ToList());
        }

        //
        // GET: /BlackList/Details/5

        public ActionResult Details(int id = 0)
        {
            BL_BlackList bl_blacklist = db.BL_BlackList.Find(id);
            if (bl_blacklist == null)
            {
                return HttpNotFound();
            }
            return View(bl_blacklist);
        }

        //
        // GET: /BlackList/Create

        public ActionResult Create()
        {
            BL_BlackList BL = new BL_BlackList();
            BL.BL_Id = 1;
            return View(BL);
        }

        //
        // POST: /BlackList/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(BL_BlackList bl_blacklist)
        {
            if (ModelState.IsValid)
            {
                db.BL_BlackList.Add(bl_blacklist);
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
            return View(bl_blacklist);

        }

        //
        // GET: /BlackList/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BL_BlackList bl_blacklist = db.BL_BlackList.Find(id);
            if (bl_blacklist == null)
            {
                return HttpNotFound();
            }
            return View(bl_blacklist);
        }

        //
        // POST: /BlackList/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BL_BlackList bl_blacklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bl_blacklist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bl_blacklist);
        }

        //
        // GET: /BlackList/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BL_BlackList bl_blacklist = db.BL_BlackList.Find(id);
            if (bl_blacklist == null)
            {
                return HttpNotFound();
            }
            return View(bl_blacklist);
        }

        //
        // POST: /BlackList/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BL_BlackList bl_blacklist = db.BL_BlackList.Find(id);
            db.BL_BlackList.Remove(bl_blacklist);
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