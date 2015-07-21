using Elmah;
using SMAWeb.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMAWeb.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnException(ExceptionContext filterContext)
        {
            try
            {
                ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Error(filterContext.Exception));
            }
            catch
            { }

            if (Request.IsAjaxRequest())
            {
                HttpContext.Response.StatusCode = 500;
                filterContext.ExceptionHandled = true;
                string message = string.Empty;

                if (filterContext.Exception is DbEntityValidationException)
                {
                    foreach (var entityError in (filterContext.Exception as DbEntityValidationException).EntityValidationErrors)
                    {
                        foreach (var validationError in entityError.ValidationErrors)
                        {
                            message += validationError.ErrorMessage + "\r\n";
                        }
                    }
                }
                else
                {
                    message = filterContext.Exception.Message;
                }

                filterContext.RequestContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                filterContext.RequestContext.HttpContext.ClearError();

                filterContext.Result = new ContentResult()
                {
                    Content = message,
                    ContentType = "text/plain"
                };
            }
            else
            {
                base.OnException(filterContext);
            }
        }

        protected new HttpNotFoundResult HttpNotFound(string statusDescription = null)
        {
            return new HttpNotFoundResult(statusDescription);
        }

        protected HttpUnauthorizedResult HttpUnauthorized(string statusDescription = null)
        {
            return new HttpUnauthorizedResult(statusDescription);
        }

        protected class HttpNotFoundResult : HttpStatusCodeResult
        {
            public HttpNotFoundResult() : this(null) { }

            public HttpNotFoundResult(string statusDescription) : base(404, statusDescription) { }

        }

        protected class HttpUnauthorizedResult : HttpStatusCodeResult
        {
            public HttpUnauthorizedResult(string statusDescription) : base(401, statusDescription) { }
        }

        protected class HttpStatusCodeResult : ViewResult
        {
            public int StatusCode { get; private set; }
            public string StatusDescription { get; private set; }

            public HttpStatusCodeResult(int statusCode) : this(statusCode, null) { }

            public HttpStatusCodeResult(int statusCode, string statusDescription)
            {
                this.StatusCode = statusCode;
                this.StatusDescription = statusDescription;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }

                context.HttpContext.Response.StatusCode = this.StatusCode;
                if (this.StatusDescription != null)
                {
                    context.HttpContext.Response.StatusDescription = this.StatusDescription;
                }
                // 1. Uncomment this to use the existing Error.ascx / Error.cshtml to view as an error or
                // 2. Uncomment this and change to any custom view and set the name here or simply
                // 3. (Recommended) Let it commented and the ViewName will be the current controller view action and on your view (or layout view even better) show the @ViewBag.Message to produce an inline message that tell the Not Found or Unauthorized
                this.ViewName = "Error";
                this.ViewBag.Message = context.HttpContext.Response.StatusDescription;
                base.ExecuteResult(context);
            }
        }

        public void SendEmailNotification(int value, Plantillas plantilla)
        {
            string pXml = string.Empty;
            var ppEmailTemplate = new SolicitudServicioController.Notification();
            var userName = WebMatrix.WebData.WebSecurity.CurrentUserName;

           

            string urlimg = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
            var firstImage = "~/Images/logo2-blue.png";
            var formatted = firstImage.Replace("~", "");
            if (formatted.StartsWith("/"))
                formatted = formatted.Remove(0, 1);
            firstImage = urlimg + formatted;

            ppEmailTemplate.Image = firstImage;
            string serverPath = string.Empty;
            serverPath = base.Server.MapPath("~");
            string body = string.Empty;

            string subject = "Servicio No Disponible";
            switch (plantilla)
            {
                case Plantillas.AnuncioReview:
                    ppEmailTemplate.AnuncioId = value;
                    ppEmailTemplate.EmailCliente = System.Configuration.ConfigurationManager.AppSettings["EmailId"].ToString();
                    subject = "Anuncio a Revisión";
                    pXml = ppEmailTemplate.Serialize<SolicitudServicioController.Notification>();
                    body = pXml.ConvertXML(Path.Combine(serverPath, @"EmailTemplates\AnuncioRevisionAdmin.xslt"));
                    //Envio a Admin
                    Extensions.ExtensionHelper.SendEmail(ppEmailTemplate.EmailCliente, subject, body);

                    body = pXml.ConvertXML(Path.Combine(serverPath, @"EmailTemplates\AnuncioRevision.xslt"));
                    ppEmailTemplate.ProviderName = userName;
                    //Envio a Usuario
                    Extensions.ExtensionHelper.SendEmail(userName, subject, body);
                    break;
                case Plantillas.AnuncioSpam:
                    ppEmailTemplate.AnuncioId = value;
                    ppEmailTemplate.EmailCliente = System.Configuration.ConfigurationManager.AppSettings["EmailId"].ToString();
                    subject = "Anuncio reportado como Spam";
                    pXml = ppEmailTemplate.Serialize<SolicitudServicioController.Notification>();
                    body = pXml.ConvertXML(Path.Combine(serverPath, @"EmailTemplates\AnuncioSpam.xslt"));
                    Extensions.ExtensionHelper.SendEmail(ppEmailTemplate.EmailCliente, subject, body);
                    break;
                case Plantillas.ComentarioReview:
                    ppEmailTemplate.CR_Id = value;
                    subject = "Comentario a Revisión";
                    ppEmailTemplate.EmailCliente = System.Configuration.ConfigurationManager.AppSettings["EmailId"].ToString();
                    pXml = ppEmailTemplate.Serialize<SolicitudServicioController.Notification>();
                    body = pXml.ConvertXML(Path.Combine(serverPath, @"EmailTemplates\ComentarioRevision.xslt"));
                    Extensions.ExtensionHelper.SendEmail(ppEmailTemplate.EmailCliente, subject, body);
                    break;
                default:
                    break;
            }
            

        }
    }

}
