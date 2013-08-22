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
    public class ContactosController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Contactos/

        public ActionResult Index()
        {
            return View(db.CON_Contactenos.ToList());
        }

        //
        // GET: /Contactos/Details/5

        public ActionResult Details(int id = 0)
        {
            CON_Contactenos con_contactenos = db.CON_Contactenos.Find(id);
            if (con_contactenos == null)
            {
                return HttpNotFound();
            }
            return View(con_contactenos);
        }

        //
        // GET: /Contactos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contactos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CON_Contactenos con_contactenos)
        {
            if (ModelState.IsValid)
            {
                db.CON_Contactenos.Add(con_contactenos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(con_contactenos);
        }

        //
        // GET: /Contactos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CON_Contactenos con_contactenos = db.CON_Contactenos.Find(id);
            if (con_contactenos == null)
            {
                return HttpNotFound();
            }
            return View(con_contactenos);
        }

        //
        // POST: /Contactos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CON_Contactenos con_contactenos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(con_contactenos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(con_contactenos);
        }

        //
        // GET: /Contactos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CON_Contactenos con_contactenos = db.CON_Contactenos.Find(id);
            if (con_contactenos == null)
            {
                return HttpNotFound();
            }
            return View(con_contactenos);
        }

        //
        // POST: /Contactos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CON_Contactenos con_contactenos = db.CON_Contactenos.Find(id);
            db.CON_Contactenos.Remove(con_contactenos);
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