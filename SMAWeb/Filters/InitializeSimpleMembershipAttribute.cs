﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using SMAWeb.Models;
using System.Web.Security;

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
}
