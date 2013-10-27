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
    public class PaisesController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /Paises/

        public ActionResult Index()
        {
            var pa_paises = db.PA_Paises.Include(p => p.REG_Region);
            return View(pa_paises.ToList());
        }

        //
        // GET: /Paises/Details/5

        public ActionResult Details(int id = 0)
        {
            PA_Paises pa_paises = db.PA_Paises.Find(id);
            if (pa_paises == null)
            {
                return HttpNotFound();
            }
            return View(pa_paises);
        }

        //
        // GET: /Paises/Create

        public ActionResult Create()
        {
            ViewBag.REG_Id = new SelectList(db.REG_Region, "REG_Id", "REG_Descripcion");
            return View();
        }

        //
        // POST: /Paises/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PA_Paises pa_paises)
        {
            if (ModelState.IsValid)
            {
                db.PA_Paises.Add(pa_paises);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.REG_Id = new SelectList(db.REG_Region, "REG_Id", "REG_Descripcion", pa_paises.REG_Id);
            return View(pa_paises);
        }

        //
        // GET: /Paises/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PA_Paises pa_paises = db.PA_Paises.Find(id);
            if (pa_paises == null)
            {
                return HttpNotFound();
            }
            ViewBag.REG_Id = new SelectList(db.REG_Region, "REG_Id", "REG_Descripcion", pa_paises.REG_Id);
            return View(pa_paises);
        }

        //
        // POST: /Paises/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PA_Paises pa_paises)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pa_paises).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.REG_Id = new SelectList(db.REG_Region, "REG_Id", "REG_Descripcion", pa_paises.REG_Id);
            return View(pa_paises);
        }

        //
        // GET: /Paises/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PA_Paises pa_paises = db.PA_Paises.Find(id);
            if (pa_paises == null)
            {
                return HttpNotFound();
            }
            return View(pa_paises);
        }

        //
        // POST: /Paises/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PA_Paises pa_paises = db.PA_Paises.Find(id);
            db.PA_Paises.Remove(pa_paises);
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