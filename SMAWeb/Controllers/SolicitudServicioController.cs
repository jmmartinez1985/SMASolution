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
    public class SolicitudServicioController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /SolicitudServicio/

        public ActionResult Index()
        {
            var ss_solicitudservicio = db.SS_SolicitudServicio.Include(s => s.AN_Anuncios).Include(s => s.ST_Estatus);
            return View(ss_solicitudservicio.ToList());
        }

        [HttpPost]
        public ActionResult TakeService(FormCollection form)
        {

            return null;
        }

        //
        // GET: /SolicitudServicio/Details/5

        public ActionResult Details(int id = 0)
        {
            SS_SolicitudServicio ss_solicitudservicio = db.SS_SolicitudServicio.Find(id);
            if (ss_solicitudservicio == null)
            {
                return HttpNotFound();
            }
            return View(ss_solicitudservicio);
        }

        //
        // GET: /SolicitudServicio/Create

        public ActionResult Create()
        {
            ViewBag.AN_Id = new SelectList(db.AN_Anuncios, "AN_Id", "AN_Titulo");
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion");
            return View();
        }

        //
        // POST: /SolicitudServicio/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SS_SolicitudServicio ss_solicitudservicio)
        {
            if (ModelState.IsValid)
            {
                db.SS_SolicitudServicio.Add(ss_solicitudservicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AN_Id = new SelectList(db.AN_Anuncios, "AN_Id", "AN_Titulo", ss_solicitudservicio.AN_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", ss_solicitudservicio.ST_Id);
            return View(ss_solicitudservicio);
        }

        //
        // GET: /SolicitudServicio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SS_SolicitudServicio ss_solicitudservicio = db.SS_SolicitudServicio.Find(id);
            if (ss_solicitudservicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.AN_Id = new SelectList(db.AN_Anuncios, "AN_Id", "AN_Titulo", ss_solicitudservicio.AN_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", ss_solicitudservicio.ST_Id);
            return View(ss_solicitudservicio);
        }

        //
        // POST: /SolicitudServicio/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SS_SolicitudServicio ss_solicitudservicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ss_solicitudservicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AN_Id = new SelectList(db.AN_Anuncios, "AN_Id", "AN_Titulo", ss_solicitudservicio.AN_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", ss_solicitudservicio.ST_Id);
            return View(ss_solicitudservicio);
        }

        //
        // GET: /SolicitudServicio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SS_SolicitudServicio ss_solicitudservicio = db.SS_SolicitudServicio.Find(id);
            if (ss_solicitudservicio == null)
            {
                return HttpNotFound();
            }
            return View(ss_solicitudservicio);
        }

        //
        // POST: /SolicitudServicio/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SS_SolicitudServicio ss_solicitudservicio = db.SS_SolicitudServicio.Find(id);
            db.SS_SolicitudServicio.Remove(ss_solicitudservicio);
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