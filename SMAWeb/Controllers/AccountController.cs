﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using SMAWeb.Filters;
using SMAWeb.Models;
using System.Net.Mail;

namespace SMAWeb.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : BaseController
    {
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.Email, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToLocal(returnUrl, model.Email);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "El usuario o contraseña ingresados es incorrecto.");
            return View(model);
        }

     

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.Email, model.Password);
                    WebSecurity.Login(model.Email, model.Password);
                    if (!Roles.IsUserInRole("Users"))
                        Roles.AddUsersToRole(new string[] { model.Email }, "Users");
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(string UserName)
        {
            //check user existance
            var user = Membership.GetUser(UserName);
            if (user == null)
            {
                TempData["Message"] = "El usuario no existe.";
            }
            else
            {
                //generate password token
                var token = WebSecurity.GeneratePasswordResetToken(UserName);
                //create url with above token
                var resetLink = "<a href='" + Url.Action("ResetPassword", "Account", new { un = UserName, rt = token }, "http") + "'>Restaurar contraseña</a>";
                //get user emailid
                Entities db = new Entities();
                var emailid = (from i in db.UserProfile
                               where i.UserName == UserName
                               select i.UserName).FirstOrDefault();
                //send mail
                string subject = "Por favor proceda a actualizar ssu password";
                string body = "<b>En este link prodrá restaurar su contraseña</b><br/>" + resetLink; //edit it
                try
                {
                    SendEMail(emailid, subject, body);
                    TempData["Message"] = "Mensaje enviado.";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Ha ocurrido un error enviando el mensaje." + ex.Message;
                }
                //only for testing
                TempData["Message"] = "Se ha enviado un correo electrónico donde podrá restaurar sus credenciales.";
            }

            return View();
        }

        public ActionResult ResetPasswordComplete()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string un, string rt)
        {
            Entities db = new Entities();
            //TODO: Check the un and rt matching and then perform following
            //get userid of received username
            var userid = (from i in db.UserProfile
                          where i.UserName == un
                          select i.UserId).FirstOrDefault();
            //check userid and token matches
            bool any = (from j in db.webpages_Membership
                        where (j.UserId == userid)
                        && (j.PasswordVerificationToken == rt)
                        //&& (j.PasswordVerificationTokenExpirationDate < DateTime.Now)
                        select j).Any();

            if (any == true)
            {
                //generate random password
                string newpassword = GenerateRandomPassword(6);
                //reset password
                bool response = WebSecurity.ResetPassword(rt, newpassword);
                if (response == true)
                {
                    //get user emailid to send password
                    var emailid = (from i in db.UserProfile
                                   where i.UserName == un
                                   select i.UserName).FirstOrDefault();
                    //send email
                    string subject = "Nueva contraseña";
                    string body = "<b>Su nueva contraseña creada:</b><br/>" + newpassword; //edit it
                    try
                    {
                        SendEMail(emailid, subject, body);
                        TempData["Message"] = "Correo enviado.";
                    }
                    catch (Exception ex)
                    {
                        TempData["Message"] = "Ha ocurrido un error mientras se enviaba el correo." + ex.Message;
                    }

                    //display message
                    TempData["Message"] = "Exito! Verifique su correo electrónico. Su nueva contraseña es: " + newpassword;
                }
                else
                {
                    TempData["Message"] = "Hey, avoid random request on this page.";
                }
            }
            else
            {
                TempData["Message"] = "El usuario y el tokem no son válidos-";
            }

            return View("ResetPasswordComplete");
        }

        private string GenerateRandomPassword(int length)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-*&#+";
            char[] chars = new char[length];
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }

        private void SendEMail(string emailid, string subject, string body)
        {
            var from = System.Configuration.ConfigurationManager.AppSettings["EmailId"];
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            var user = System.Configuration.ConfigurationManager.AppSettings["EmailId"].ToString();
            var pwduser = System.Configuration.ConfigurationManager.AppSettings["EmailPwd"].ToString();

            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(user, pwduser);
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(from);
            msg.To.Add(new MailAddress(emailid));

            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = body;

            client.Send(msg);
        }




        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if (ownerAccount == User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Su contraseña ha sido cambiada."
                : message == ManageMessageId.SetPasswordSuccess ? "Su contraseña se ha agregado."
                : message == ManageMessageId.RemoveLoginSuccess ? "Se ha desvinculado su cuenta a Service Market."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "La actual contraseña es incorrecta o la nueva contraseña es inválida.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing
                // OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", String.Format("No pudimos registrarle en Service Market. Puede que ya exista una cuenta con el correo \"{0}\".", User.Identity.Name));
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl, string.Empty);
            }

            if (User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl, string.Empty);
            }
            else
            {
                // User is new, ask for their desired membership name
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Insert a new user into the database
                using (Entities db = new Entities())
                {
                    UserProfile user = db.UserProfile.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
                    // Check if user already exists
                    if (user == null)
                    {
                        // Insert name into the profile table
                        db.UserProfile.Add(new UserProfile { UserName = model.UserName });
                        db.SaveChanges();

                        OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                        OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                        return RedirectToLocal(returnUrl, string.Empty);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "Ya existe una cuenta con esta cuenta de correo. Por favor ingrese un correo diferente.");
                    }
                }
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // GET: /Account/ExternalLoginFailure

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl, string Username)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                //if (Roles.FindUsersInRole("Admin", Username).Count() > 0)
                return RedirectToAction("Index", "Home");
                //else
                //    return RedirectToAction("GetAnunciosByUser", "Anuncios");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Ya existe una cuenta con esta cuenta de correo. Por favor ingrese un correo diferente.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Ya existe una cuenta con esta cuenta de correo. Por favor ingrese un correo diferente.";

                case MembershipCreateStatus.InvalidPassword:
                    return "La contraseña ingresa no es válida. Por favor ingrese una contraseña válida.";

                case MembershipCreateStatus.InvalidEmail:
                    return "El correo electrónico ingresado no es válido. Por favor verifique y vuelva a intentarlo.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "La respuesta secreta no es válida. Por favor verifique y vuelva a intentarlo.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "La pregunta secreta no es válida. Por favor verifique y vuelva a intentarlo.";

                case MembershipCreateStatus.InvalidUserName:
                    return "El nombre de usuario ingresado no es válida. Por favor verifique y vuelva a intentarlo.";

                case MembershipCreateStatus.ProviderError:
                    return "Error con el proveedor de autentificación. Por favor verifique sus datos y vuelva a intentarlo. Si los problemas continuan por favor contactenos.";

                case MembershipCreateStatus.UserRejected:
                    return "La creación del usuario ha sido cancelada. Por favor verifique sus datos y vuelva a intentarlo. Si los problemas continuan por favor contactenos.";

                default:
                    return "Ha ocurrido un error. Por favor verifique los datos ingresados y vuelva a intentarlo. Si los problemas continuan por favor contactenos.";
            }
        }
        #endregion
    }
}
