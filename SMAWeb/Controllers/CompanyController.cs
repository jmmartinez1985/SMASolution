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
    public class CompanyController : BaseController
    {
        private Entities db = new Entities();




        public ActionResult GetCompanyInfo()
        {
            var Company = new COM_Compañia();

            using (Entities model = new Entities())
            {
                Company = model.COM_Compañia.FirstOrDefault();
            }

            if (Company == null)
            {
                return HttpNotFound();
            }

            return Json(Company.SerializeToJson());
        }







        //
        // GET: /Company/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.COM_Compañia.ToList());
        }

        //
        // GET: /Company/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id = 0)
        {
            COM_Compañia com_compañia = db.COM_Compañia.Find(id);
            if (com_compañia == null)
            {
                return HttpNotFound();
            }
            return View(com_compañia);
        }

        //
        // GET: /Company/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Company/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(COM_Compañia com_compañia)
        {
            if (ModelState.IsValid)
            {
                db.COM_Compañia.Add(com_compañia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(com_compañia);
        }

        //
        // GET: /Company/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id = 0)
        {
            COM_Compañia com_compañia = db.COM_Compañia.Find(id);
            if (com_compañia == null)
            {
                return HttpNotFound();
            }
            return View(com_compañia);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(COM_Compañia com_compañia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(com_compañia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(com_compañia);
        }

        //
        // GET: /Company/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id = 0)
        {
            COM_Compañia com_compañia = db.COM_Compañia.Find(id);
            if (com_compañia == null)
            {
                return HttpNotFound();
            }
            return View(com_compañia);
        }

        //
        // POST: /Company/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COM_Compañia com_compañia = db.COM_Compañia.Find(id);
            db.COM_Compañia.Remove(com_compañia);
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