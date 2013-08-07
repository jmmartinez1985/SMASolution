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
    public class UserProfileController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /UserProfile/

        public ActionResult Index()
        {
            var userprofile = db.UserProfile.Include(u => u.MB_Membresia).Include(u => u.PA_Paises).Include(u => u.ST_Estatus);
            return View(userprofile.ToList());
        }

        //
        // GET: /UserProfile/Details/5

        public ActionResult Details(int id = 0)
        {
            UserProfile userprofile = db.UserProfile.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Create

        public ActionResult Create()
        {
            ViewBag.MP_MemberShipId = new SelectList(db.MB_Membresia, "MP_MemberShipId", "MP_Descripcion");
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion");
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion");
            return View();
        }

        //
        // POST: /UserProfile/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfile.Add(userprofile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MP_MemberShipId = new SelectList(db.MB_Membresia, "MP_MemberShipId", "MP_Descripcion", userprofile.MP_MemberShipId);
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion", userprofile.PA_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", userprofile.ST_Id);
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserProfile userprofile = db.UserProfile.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            ViewBag.MP_MemberShipId = new SelectList(db.MB_Membresia, "MP_MemberShipId", "MP_Descripcion", userprofile.MP_MemberShipId);
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion", userprofile.PA_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", userprofile.ST_Id);
            return View(userprofile);
        }

        //
        // POST: /UserProfile/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MP_MemberShipId = new SelectList(db.MB_Membresia, "MP_MemberShipId", "MP_Descripcion", userprofile.MP_MemberShipId);
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion", userprofile.PA_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", userprofile.ST_Id);
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserProfile userprofile = db.UserProfile.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /UserProfile/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userprofile = db.UserProfile.Find(id);
            db.UserProfile.Remove(userprofile);
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