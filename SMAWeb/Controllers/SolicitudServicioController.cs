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

using System.Web.Security;


namespace SMAWeb.Controllers
{
    public class SolicitudServicioController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /SolicitudServicio/
        [Authorize(Roles = "Users, Admin")]
        public ActionResult Index()
        {
            var mysol = new List<SolicitudViewModel>();
            using (var db = new Entities())
            {
                var solicitudes = db.SS_SolicitudServicio;
                Func<int, string> x = value =>
                {
                    switch (value)
                    {
                        case 1: return "Activo";
                        case 2: return "Cancelado";
                        case 3: return "Realizado";
                        case 4: return "En espera de Review";
                        case 5: return "Completado";
                        case 6: return "Iniciar Tarea";
                        case 7: return "A revisión";
                        case 8: return "Eliminado";
                        case 9: return "Expirado";
                        default: return "";
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
                        TelefonoSolicitante = sol.AN_Anuncios.AN_Telefono  , // "No Telefono",
                        StatusId = sol.ST_Id
                    });
                });
            }
            //mysol.OrderByDescending(sol => sol.FechaCreacion);
            return View(mysol);
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
                    //Si es administrador
                    if (Roles.IsUserInRole(WebSecurity.CurrentUserName, "Admin"))
                    {
                        return Json(new { Message = "Estimado usuario, le informamos que su cuenta administrador no le permite solicitar servicios. Utilice su cuenta de usuario regular." });
                    }

                    //Si existe una solicitud sin iniciar atención
                    var existSolicitud = db.SS_SolicitudServicio.Any(c => c.AN_Id == anuncioId && c.ST_Id == 1 && c.UserId == WebSecurity.CurrentUserId);
                    if (existSolicitud)
                    {
                        return Json(new { Message = "Estimado usuario, le informamos que ya cuenta con una solicitud activa para este anuncio que desea solicitar, por favor póngase en contacto con el anunciante." });
                    }

                    //Si es un propio anuncio
                    var anuncio = db.AN_Anuncios.Find(anuncioId);
                    if (anuncio.UserId == WebSecurity.CurrentUserId)
                    {
                        return Json(new { Message = "Estimado usuario, le informamos que no es posible hacer solicitudes a sus propios anuncios." });
                    }

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
                        SendEmailNotification(solicitudcreada, false, 1);
                    }
                }
            }
            return null;
        }

        [AjaxAuthorizeAttribute(Roles = "Users")]
        public ActionResult SolicitudRequest()
        {
            var mysol = new List<SolicitudViewModel>();
            using (var db = new Entities())
            {
                var solicitudes = db.SS_SolicitudServicio.OrderByDescending(c => c.SS_Id).Where(c => c.AN_Anuncios.UserId == WebSecurity.CurrentUserId);
                Func<int, string> x = value =>
                {
                    switch (value)
                    {
                        case 1: return "Activo";
                        case 2: return "Cancelado";
                        case 3: return "Realizado";
                        case 4: return "En espera de Review";
                        case 5: return "Completado";
                        case 6: return "Iniciar Tarea";
                        case 7: return "A revisión";
                        case 8: return "Eliminado";
                        case 9: return "Expirado";
                        default: return "";
                    }
                };

                solicitudes.ToList().ForEach((sol) =>
                {

                    mysol.Add(new SolicitudViewModel
                    {
                        TituloAnuncio = sol.AN_Anuncios.AN_Titulo,
                        Solicitante = sol.UserProfile.Name,
                        EmailSolicitante = sol.UserProfile.UserName,
                        FechaCreacion = sol.SS_Fecha,
                        Solicitud = sol.SS_Id,
                        Status = x.Invoke(sol.ST_Id),
                        TelefonoSolicitante = sol.UserProfile.NumeroTelefono, // sol.AN_Anuncios.AN_Telefono,
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
            Updating update = new Updating() { Message = "La solicitud número " + Solicitud.ToString() + " ha sido cancelada." };
            using (var db = new Entities())
            {
                var solicitud = db.SS_SolicitudServicio.Find(Solicitud);
                solicitud.ST_Id = Status;
                db.Entry(solicitud).State = EntityState.Modified;
                db.SaveChanges();
                if (Status == 3)
                {
                    SendEmailNotification(solicitud, true, Status);
                }
                else if (Status == 2)
                {
                    SendEmailNotification(solicitud, false, Status);
                }
            }


            if (Request.IsAjaxRequest())
            {
                return Json(update.SerializeToJson(), JsonRequestBehavior.AllowGet);
            }

            return View();

        }

        //
        // GET: /SolicitudServicio/Details/5
        [Authorize(Roles = "Users")]
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
        [Authorize(Roles = "Users")]
        public ActionResult Create()
        {
            ViewBag.AN_Id = new SelectList(db.AN_Anuncios, "AN_Id", "AN_Titulo");
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion");
            return View();
        }

        //
        // POST: /SolicitudServicio/Create
        [Authorize(Roles = "Users")]
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
        [Authorize(Roles = "Users")]
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
        [Authorize(Roles = "Users")]
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
        [Authorize(Roles = "Users")]
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
        [Authorize(Roles = "Users")]
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


        private void SendEmailNotification(SS_SolicitudServicio solicitud, bool isReview, int Status)
        {
            string pXml = string.Empty;
            var ppEmailTemplate = new Notification();
            var userName = WebSecurity.CurrentUserName;
            using (db = new Entities())
            {
                var soli = db.SS_SolicitudServicio.Where(c => c.SS_Id == solicitud.SS_Id);
                ppEmailTemplate.CustomerName = soli.FirstOrDefault().UserProfile.Name;
                ppEmailTemplate.ProviderName = soli.FirstOrDefault().AN_Anuncios.UserProfile.Name;
                ppEmailTemplate.SolicitudId = soli.FirstOrDefault().SS_Id;
                ppEmailTemplate.AnuncioId = soli.FirstOrDefault().AN_Anuncios.AN_Id;
                ppEmailTemplate.AnuncioTitulo = soli.FirstOrDefault().AN_Anuncios.AN_Titulo;
                ppEmailTemplate.EmailCliente = soli.FirstOrDefault().UserProfile.UserName;
                ppEmailTemplate.EmailProveedor = soli.FirstOrDefault().AN_Anuncios.UserProfile.UserName;
                ppEmailTemplate.TelefonoProveedor = soli.FirstOrDefault().AN_Anuncios.AN_Telefono;
                ppEmailTemplate.TelefonoCliente = soli.FirstOrDefault().UserProfile.NumeroTelefono;

                string urlimg = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
                var firstImage = "~/Images/logo2-blue.png";
                var formatted = firstImage.Replace("~", "");
                if (formatted.StartsWith("/"))
                    formatted = formatted.Remove(0, 1);
                firstImage = urlimg + formatted;

                ppEmailTemplate.Image = firstImage;

                string link = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/") + "Review/Create/" + solicitud.SS_Id;
                ppEmailTemplate.LinkReview = link;

                pXml = ppEmailTemplate.Serialize<Notification>();
                string serverPath = string.Empty;
                serverPath = base.Server.MapPath("~");
                string body = string.Empty;

                if (isReview)
                {
                    body = pXml.ConvertXML(Path.Combine(serverPath, @"EmailTemplates\ServicioReview.xslt"));
                    Extensions.ExtensionHelper.SendEmail(ppEmailTemplate.EmailCliente, "¿Qué te pareció el servicio contratado?", body);

                    var soliupdate = db.SS_SolicitudServicio.Find(solicitud.SS_Id);
                    soliupdate.ST_Id = 4;
                    db.Entry(soliupdate).State = EntityState.Modified;
                    db.SaveChanges();

                }

                else
                {
                    if (Status == 2)
                    {
                        body = pXml.ConvertXML(Path.Combine(serverPath, @"EmailTemplates\ServicioRejected.xslt"));
                        Extensions.ExtensionHelper.SendEmail(ppEmailTemplate.EmailCliente, "Servicio No Disponible", body);
                    }
                    else
                    {
                        body = pXml.ConvertXML(Path.Combine(serverPath, @"EmailTemplates\ServicioRequestClient.xslt"));
                        Extensions.ExtensionHelper.SendEmail(ppEmailTemplate.EmailCliente, "Solicitud de Servicio", body);


                        body = pXml.ConvertXML(Path.Combine(serverPath, @"EmailTemplates\ServicioRequestProved.xslt"));
                        Extensions.ExtensionHelper.SendEmail(ppEmailTemplate.EmailProveedor, "Solicitud de Servicio", body);
                    }
                }
            }
        }



        public class Notification
        {
            public string CustomerName { get; set; }
            public string ProviderName { get; set; }
            public int AnuncioId { get; set; }
            public string AnuncioTitulo { get; set; }
            public int SolicitudId { get; set; }
            public int CR_Id { get; set; }
            public string EmailCliente { get; set; }
            public string EmailProveedor { get; set; }
            public string LinkReview { get; set; }
            public string AnuncioDescripcion { get; set; }
            public string TelefonoCliente { get; set; }
            public string TelefonoProveedor { get; set; }
            public string Image { get; set; }

        }
    }
}