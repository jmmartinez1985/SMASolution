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
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var pa_paises = db.PA_Paises;
            return View(pa_paises.ToList());
        }

        //
        // GET: /Paises/Details/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "SuperUsers")]
        public ActionResult Create()
        {
            PA_Paises pais = new PA_Paises();
            pais.PA_Id = 1;
            return View(pais);
        }

        //
        // POST: /Paises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperUsers")]
        public ActionResult Create(PA_Paises pa_paises)
        {
            if (ModelState.IsValid)
            {
                
                db.PA_Paises.Add(pa_paises);
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
            return View(pa_paises);
        }

        //
        // GET: /Paises/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id = 0)
        {
            PA_Paises pa_paises = db.PA_Paises.Find(id);
            if (pa_paises == null)
            {
                return HttpNotFound();
            }
            return View(pa_paises);
        }

        //
        // POST: /Paises/Edit/5
        [Authorize(Roles = "Admin")]
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
            return View(pa_paises);
        }

        //
        // GET: /Paises/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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