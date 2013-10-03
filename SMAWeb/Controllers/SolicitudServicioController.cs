using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMAWeb.Models;
using WebMatrix.WebData;
using SMAWeb.Filters;
using System.Xml.Xsl;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using SMAWeb.Extensions;
using System.Dynamic;

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
        [AjaxAuthorizeAttribute(Roles = "Admin, Users")]
        public ActionResult TakeService(FormCollection form)
        {
            if (form[0] != null)
            {
                int anuncioId = int.Parse(form[0]);
                using (var db = new Entities())
                {
                    var solicitud = db.SS_SolicitudServicio.Add(new SS_SolicitudServicio
                    {
                        AN_Id = anuncioId,
                        ST_Id = 1,
                        SS_Fecha = System.DateTime.Now,
                        UserId = WebSecurity.CurrentUserId
                    });
                    var solicitudcreada = db.SaveChanges<SS_SolicitudServicio>(solicitud);
                    if (solicitudcreada != null)
                    {
                        SendEmailNotification(solicitudcreada);
                    }
                }
            }
            return null;
        }


        public ActionResult SolicitudRequest()
        {
            var mysol = new List<SolicitudViewModel>();
            using (var db = new Entities())
            {
                var solicitudes = db.SS_SolicitudServicio.Where(c => c.AN_Anuncios.UserId == WebSecurity.CurrentUserId);
                Func<int, string> x = value =>
                {
                    switch (value)
                    {
                        case 1: return "Activo";
                        case 3: return "Realizado";
                        case 5: return "En espera de Review";
                        case 6: return "Iniciar Tarea";
                        default: return "Cancelado";
                    }
                };
                solicitudes.ToList().ForEach((sol) =>
                {
                    mysol.Add(new SolicitudViewModel
                    {
                        Solicitante = sol.UserProfile.Name,
                        EmailSolicitante = sol.UserProfile.UserName,
                        FechaCreacion = sol.SS_Fecha,
                        Solicitud = sol.SS_Id,
                        Status = x.Invoke(sol.ST_Id),
                        TelefonoSolicitante = "No Telefono",
                        StatusId = sol.ST_Id
                    });
                });
            }
            return View(mysol);
        }

        internal class Updating
        {
            public string Message { get; set; }
        
        }

        [HttpGet]
        public ActionResult ChangeStatus(int Solicitud, int Status)
        {
            Updating update = new Updating() { Message = "Proceso de Actualización Exitosa." };
            using (var db = new Entities())
            {
                var solicitud = db.SS_SolicitudServicio.Find(Solicitud);
                solicitud.ST_Id = Status;
                db.Entry(solicitud).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(update.SerializeToJson(), JsonRequestBehavior.AllowGet);
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


        private void SendEmailNotification(SS_SolicitudServicio solicitud)
        {
            string pXml = string.Empty;
            var ppEmailTemplate = new Notification();

            pXml = ppEmailTemplate.Serialize<Notification>();
            var userName = WebSecurity.CurrentUserName;

            using (db = new Entities())
            {
                var soli = db.SS_SolicitudServicio.Where(c => c.SS_Id == solicitud.SS_Id);
                ppEmailTemplate.CustomerName = soli.FirstOrDefault().UserProfile.Name;
                ppEmailTemplate.ProviderName = soli.FirstOrDefault().AN_Anuncios.UserProfile.Name;
                ppEmailTemplate.SolicitudId = soli.FirstOrDefault().SS_Id;
                ppEmailTemplate.AnuncioId = soli.FirstOrDefault().AN_Anuncios.AN_Id;
                ppEmailTemplate.EmailCliente = soli.FirstOrDefault().UserProfile.UserName;
                ppEmailTemplate.EmailProveedor = soli.FirstOrDefault().AN_Anuncios.UserProfile.UserName;
            }

            string serverPath = string.Empty;
            serverPath = base.Server.MapPath("~");
            string body = string.Empty;
            body = pXml.ConvertXML(Path.Combine(serverPath, @"EmailTemplates\ServicioRequestClient.xslt"));
            Extensions.ExtensionHelper.SendEmail(ppEmailTemplate.EmailCliente, "Solicitud de Servicio", body);


            body = pXml.ConvertXML(Path.Combine(serverPath, @"EmailTemplates\ServicioRequestProved.xslt"));
            Extensions.ExtensionHelper.SendEmail(ppEmailTemplate.EmailProveedor, "Solicitud de Servicio", body);

        }



        public class Notification
        {
            public string CustomerName { get; set; }
            public string ProviderName { get; set; }
            public int AnuncioId { get; set; }
            public int SolicitudId { get; set; }
            public string EmailCliente { get; set; }
            public string EmailProveedor { get; set; }
        }
    }
}