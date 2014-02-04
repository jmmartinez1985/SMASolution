﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


using System.Data;
using System.Data.Entity;
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
using System.Threading.Tasks;


namespace SMAWeb.Controllers
{
    public class ExpireController : ApiController
    {


        [System.Web.Http.HttpGet]
        public string Get()
        {
            var current = HttpContext.Current;
            var tareaAsincronica = Task.Factory.StartNew(() => Expirada());
            Task.WaitAll(tareaAsincronica);
            return "Proceso concluido satisfactoriamente";

        }

        public void Expirada()
        {
            using (Models.Entities model = new Models.Entities())
            {
                model.UPD_MembresiasExpiradas().ToList().ForEach(correo =>
                {

                    SendEmailNotification(correo.ToString(), @"EmailTemplates/ServicioReview.xslt", "Membresía Expirada");
                });
            }

        }

        private void SendEmailNotification(string Correo, string Plantilla, string Asunto)
        {
            string pXml = string.Empty;
            var current = HttpContext.Current;
            string imagen = System.Configuration.ConfigurationManager.AppSettings["NotificationLogo"].ToString();
            string serverPath = current.Server.MapPath("~/"); //System.Configuration.ConfigurationManager.AppSettings["NotificationPath"].ToString();
            string linkMembresia = System.Configuration.ConfigurationManager.AppSettings["NotificationLink"].ToString();
            string body = string.Empty;
            var ppEmailTemplate = new Notification();

            ppEmailTemplate.UserName = Correo;
            ppEmailTemplate.Image = imagen;
            ppEmailTemplate.LinkMembresia = linkMembresia;

            pXml = ppEmailTemplate.Serialize<Notification>();

            body = pXml.ConvertXML(Path.Combine(serverPath, Plantilla));
            Extensions.ExtensionHelper.SendEmail(Correo, Asunto, body);

        }


    }
    public class Notification
    {
        public string UserName { get; set; }
        public string LinkMembresia { get; set; }
        public string Image { get; set; }

    }
}


