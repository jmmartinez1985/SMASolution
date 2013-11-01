using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMAWeb.Models;
using SMAWeb.Extensions;
using WebMatrix.WebData;
using SMAWeb.Filters;

namespace SMAWeb.Controllers
{
    public class ComentariosController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /Comentarios/

        public ActionResult Index()
        {
            var cr_comentarioreview = db.CR_ComentarioReview.Include(c => c.RW_Reviews).Include(c => c.ST_Estatus).Include(c => c.UserProfile);
            return View(cr_comentarioreview.ToList());
        }

        //
        // GET: /Comentarios/Details/5

        public ActionResult Details(int id = 0)
        {
            CR_ComentarioReview cr_comentarioreview = db.CR_ComentarioReview.Find(id);
            if (cr_comentarioreview == null)
            {
                return HttpNotFound();
            }
            return View(cr_comentarioreview);
        }

        public ActionResult GetCommentsByReview(int id = 0)
        {
            List<CR_ComentarioReview> comentariosList = db.CR_ComentarioReview.Where(c => c.RW_Id == id).ToList();
            return View(comentariosList);
        }


        //
        // GET: /Comentarios/Create

        public ActionResult Create()
        {
            ViewBag.RW_Id = new SelectList(db.RW_Reviews, "RW_Id", "RW_Comentario");
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion");
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Comentarios/Create
         
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AjaxAuthorizeAttribute(Roles = "Admin, Users")]
        public ActionResult Create(CR_ComentarioReview cr_comentarioreview)
        {
            if (ModelState.IsValid)
            {
                bool wasNotApproved = Extensions.ExtensionHelper.NotApproved(cr_comentarioreview.CR_Comentario);
                if (wasNotApproved)
                {
                    cr_comentarioreview.ST_Id = 7;
                }
                else
                    cr_comentarioreview.ST_Id = 1;
                db.SaveChanges<CR_ComentarioReview>(cr_comentarioreview);
                var user = db.UserProfile.Find(WebSecurity.CurrentUserId);
                CommentReview cmt = new CommentReview { Comments = cr_comentarioreview.CR_Comentario, Image = Url.Content(user.Image), Name = user.Name };
                if (Request.IsAjaxRequest())
                {
                    return Json(new { data = cmt }.SerializeToJson());
                }
                return RedirectToAction("Index");
            }

            ViewBag.RW_Id = new SelectList(db.RW_Reviews, "RW_Id", "RW_Comentario", cr_comentarioreview.RW_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", cr_comentarioreview.ST_Id);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", cr_comentarioreview.UserId);
            if (Request.IsAjaxRequest())
            {
                return Json(new { error = true }.SerializeToJson());
            }
            return View(cr_comentarioreview);
        }

        //
        // GET: /Comentarios/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CR_ComentarioReview cr_comentarioreview = db.CR_ComentarioReview.Find(id);
            if (cr_comentarioreview == null)
            {
                return HttpNotFound();
            }
            ViewBag.RW_Id = new SelectList(db.RW_Reviews, "RW_Id", "RW_Comentario", cr_comentarioreview.RW_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", cr_comentarioreview.ST_Id);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", cr_comentarioreview.UserId);
            return View(cr_comentarioreview);
        }

        //
        // POST: /Comentarios/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CR_ComentarioReview cr_comentarioreview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cr_comentarioreview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RW_Id = new SelectList(db.RW_Reviews, "RW_Id", "RW_Comentario", cr_comentarioreview.RW_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", cr_comentarioreview.ST_Id);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", cr_comentarioreview.UserId);
            return View(cr_comentarioreview);
        }

        //
        // GET: /Comentarios/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CR_ComentarioReview cr_comentarioreview = db.CR_ComentarioReview.Find(id);
            if (cr_comentarioreview == null)
            {
                return HttpNotFound();
            }
            return View(cr_comentarioreview);
        }

        //
        // POST: /Comentarios/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CR_ComentarioReview cr_comentarioreview = db.CR_ComentarioReview.Find(id);
            db.CR_ComentarioReview.Remove(cr_comentarioreview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        internal class CommentReview
        {
            public string Comments { get; set; }
            public string Image { get; set; }
            public string Name { get; set; }
        }
    }
}