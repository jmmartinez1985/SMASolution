using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMAWeb.Models;
using SMAWeb.Filters;
using System.Xml.Xsl;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using SMAWeb.Extensions;
using System.Dynamic;

namespace SMAWeb.Controllers
{
    public class ContactosController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /Contactos/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.CON_Contactenos.ToList());
        }

        //
        // GET: /Contactos/Details/5
        [Authorize(Roles = "Admin")]
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
            if (con_contactenos.CON_Celular == null)
                con_contactenos.CON_Celular = "0";
            if (con_contactenos.CON_Telefono == null)
                con_contactenos.CON_Telefono = "0";

            if (ModelState.IsValid)
            {
                con_contactenos.CON_Fecha = DateTime.Now;
                db.CON_Contactenos.Add(con_contactenos);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(con_contactenos);
        }

        //
        // GET: /Contactos/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CON_Contactenos con_contactenos = db.CON_Contactenos.Find(id);
            db.CON_Contactenos.Remove(con_contactenos);
            db.SaveChanges();
            var urlRedirect = Url.Action("Index");
            return Json(new { url = urlRedirect });
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult RespuestaContacto(string id, string nombre, string correo, string respuesta)
        {
            string pXml = string.Empty;
            var ppEmailTemplate = new Notification();

            ppEmailTemplate.CustomerName = nombre;
            ppEmailTemplate.Respuesta = respuesta;
            ppEmailTemplate.Destinatario = correo;

            string urlimg = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
            var firstImage = "~/Images/logo2-blue.png";
            var formatted = firstImage.Replace("~", "");
            if (formatted.StartsWith("/"))
                formatted = formatted.Remove(0, 1);
            firstImage = urlimg + formatted;

            ppEmailTemplate.Image = firstImage;

            pXml = ppEmailTemplate.Serialize<Notification>();
            string serverPath = string.Empty;
            serverPath = base.Server.MapPath("~");
            string body = string.Empty;

            try
            {
                body = pXml.ConvertXML(Path.Combine(serverPath, @"EmailTemplates\RespuestaContacto.xslt"));
                Extensions.ExtensionHelper.SendEmail(ppEmailTemplate.Destinatario, "Respuesta a consulta en Service Market", body);

                CON_Contactenos con_contactenos = db.CON_Contactenos.Find(Convert.ToInt16(id));
                db.CON_Contactenos.Remove(con_contactenos);
                db.SaveChanges();

            }
            catch
            {

            }


            var urlRedirect = Url.Action("Index");
            return Json(new { url = urlRedirect });

        }

        public class Notification
        {
            public string CustomerName { get; set; }
            public string Respuesta { get; set; }
            public string Destinatario { get; set; }
            public string Image { get; set; }

        }

    }

}