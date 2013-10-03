using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using SMAWeb.Models;
using System.Web.Security;
using System.Web.Routing;
using System.Linq;

namespace SMAWeb.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<Entities>(null);

                try
                {
                    using (var context = new Entities())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AdminRoleFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Roles.IsUserInRole(WebSecurity.CurrentUserName, "Admin"))// Check the Role Against the database Value
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }
        }


    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UserRoleFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Roles.IsUserInRole(WebSecurity.CurrentUserName, "Users"))// Check the Role Against the database Value
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }
        }


    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class IsValidReviewFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var db = new Entities();
            int solicitud = int.Parse(filterContext.ActionParameters.Values.FirstOrDefault().ToString());
            if (db.RW_Reviews.Any(c => c.SS_Id == solicitud))
            {
                filterContext.Result = new RedirectResult("~/Review/ReviewSubmitted");
                return;
            }
        }
    }

    public class AjaxAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                //var url = System.Web.HttpUtility.HtmlEncode(context.HttpContext.Request.RawUrl);
                var urlHelper = new UrlHelper(context.RequestContext);
                context.HttpContext.Response.StatusCode = 403;

                context.Result = new JsonResult
                {
                    Data = new
                    {
                        Error = "NotAuthorized",
                        LogOnUrl = urlHelper.Action("Login", "Account")
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(context);
            }
        }
    }
}
