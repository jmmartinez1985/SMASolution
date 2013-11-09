using Elmah;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        //protected new HttpNotFoundResult HttpNotFound(string statusDescription = null)
        //{
        //    return new HttpNotFoundResult(statusDescription);
        //}

        //protected HttpUnauthorizedResult HttpUnauthorized(string statusDescription = null)
        //{
        //    return new HttpUnauthorizedResult(statusDescription);
        //}

        //protected class HttpNotFoundResult : HttpStatusCodeResult
        //{
        //    public HttpNotFoundResult() : this(null) { }

        //    public HttpNotFoundResult(string statusDescription) : base(404, statusDescription) { }

        //}

        //protected class HttpUnauthorizedResult : HttpStatusCodeResult
        //{
        //    public HttpUnauthorizedResult(string statusDescription) : base(401, statusDescription) { }
        //}

        //protected class HttpStatusCodeResult : ViewResult
        //{
        //    public int StatusCode { get; private set; }
        //    public string StatusDescription { get; private set; }

        //    public HttpStatusCodeResult(int statusCode) : this(statusCode, null) { }

        //    public HttpStatusCodeResult(int statusCode, string statusDescription)
        //    {
        //        this.StatusCode = statusCode;
        //        this.StatusDescription = statusDescription;
        //    }

        //    public override void ExecuteResult(ControllerContext context)
        //    {
        //        if (context == null)
        //        {
        //            throw new ArgumentNullException("context");
        //        }

        //        context.HttpContext.Response.StatusCode = this.StatusCode;
        //        if (this.StatusDescription != null)
        //        {
        //            context.HttpContext.Response.StatusDescription = this.StatusDescription;
        //        }
        //        // 1. Uncomment this to use the existing Error.ascx / Error.cshtml to view as an error or
        //        // 2. Uncomment this and change to any custom view and set the name here or simply
        //        // 3. (Recommended) Let it commented and the ViewName will be the current controller view action and on your view (or layout view even better) show the @ViewBag.Message to produce an inline message that tell the Not Found or Unauthorized
        //        //this.ViewName = "Error";
        //        this.ViewBag.Message = context.HttpContext.Response.StatusDescription;
        //        base.ExecuteResult(context);
        //    }
        //}
    }
}
