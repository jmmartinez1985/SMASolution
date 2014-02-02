using System;
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
    public class NotificaController : ApiController
    {
        [System.Web.Http.HttpGet]
        public string GetExpiration()
        {
            var tareaAsincronica = Task.Factory.StartNew(() => PorExpirar());
            Task.WaitAll(tareaAsincronica);
            return "Proceso concluido satisfactoriamente";
        }

        private void PorExpirar()
        {
            using (Models.Entities model = new Models.Entities())
            {
                
                model.SEL_MembresiasPorExpirar().ToList().ForEach(correo =>
                {
                    SendEmailNotification(correo.ToString(),  @"EmailTemplates\ServicioReview.xslt", "Membresía Por Expirar");
                });
                // colocar el sp correcto y hacer un foreach
            }
        }

        private void SendEmailNotification(string Correo, string Plantilla, string Asunto)
        {
            string pXml = string.Empty;
            string imagen = "imagen";
            string serverPath = "url del sitio";
            string linkMembresia = "link";
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


}
