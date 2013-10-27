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

    }
}
