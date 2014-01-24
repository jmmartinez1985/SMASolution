using System;
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
using System.IO;
using Recaptcha;

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
        [RecaptchaControlMvc.CaptchaValidator]
        public ActionResult Register(RegisterModel model, bool captchaValid)
        {
            if (!captchaValid)
            {
                ModelState.AddModelError(string.Empty, "El captcha ingresado no es correcto, por favor vuelva a intentarlo.");
            }
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.Email, model.Password);
                    WebSecurity.Login(model.Email, model.Password);
                    if (!Roles.IsUserInRole("Users"))
                        Roles.AddUsersToRole(new string[] { model.Email }, "Users");
                    return RedirectToAction("EditUser", "UserProfile");
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
        public ActionResult ForgotPassword(string Email)
        {
            //check user existance
            var user = Membership.GetUser(Email);
            if (user == null)
            {
                if (Email == string.Empty)
                    TempData["Message"] = "No ha ingresado el correo electrónico.";
                else
                    TempData["Message"] = "El correo electronico ingresado no corresponde a un usuario existente.";
            }
            else
            {
                //generate password token
                var token = WebSecurity.GeneratePasswordResetToken(Email);
                //create url with above token
                var resetLink = Url.Action("ResetPassword", "Account", new { un = Email, rt = token }, "http");

                //get user emailid
                Entities db = new Entities();
                var emailid = (from i in db.UserProfile
                               where i.UserName == Email
                               select i.UserName).FirstOrDefault();
                //send mail
                string subject = "Restaurar su contraseña de Service Market";
                string body = MensajeRestablecerPassword(resetLink, Email); //edit it
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
                TempData["Message"] = "Se ha enviado un correo electrónico en el cual podrá restaurar su contraseña.";

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
                    string subject = "Nueva Contraseña de Service Market";
                    string body = MensajeNuevoPassword(newpassword); //edit it
                    try
                    {
                        SendEMail(emailid, subject, body);
                        TempData["Message"] = "Correo enviado.";
                    }
                    catch (Exception ex)
                    {
                        TempData["Message"] = "Ha ocurrido un error al intentar enviar el correo." + ex.Message;
                    }

                    //display message
                    TempData["Message"] = "Hemos atendido su solicitud de restauración de contraseña. Su nueva contraseña para Service Market es: " + newpassword + " De igual forma le hemos enviado un correo con su nueva contraseña.";
                }
                else
                {
                    TempData["Message"] = "Hubo un error al reiniciar la contraseña, por favor vuelva a intentarlo más a tarde o comuníquese con nuestros agnetes de Service Market.";
                }
            }
            else
            {
                TempData["Message"] = "Hubo un error al reiniciar la contraseña, por favor vuelva a intentarlo más a tarde o comuníquese con nuestros agnetes de Service Market";
            }

            return View("ResetPasswordComplete");
        }

        private string MensajeNuevoPassword(string password)
        {
            string mensaje = string.Empty;
            string imagen = Url.Content(Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port) + "/Images/logo2-blue.png");

            mensaje += "<div style='color: #333; font-size: 13px; line-height: 1.6; font-family: Helvetica Neue, Helvetica, Arial, sans-serif;'><br /><div style='min-width: 90%; max-width: 30%;padding: 20px 50px 30px; overflow: hidden; margin: 0 auto; background: #fcfcfc; border: solid 1px #eee; box-shadow: 0 0 7px #eee;' ><div style='display: block; margin: 10px 0 25px 0; border-bottom: 1px dotted #e4e9f0; border-radius: 0 !important;'><img id='logo-footer' src='" + imagen + "' alt='Service Market' style='height: auto; max-width: 100%; vertical-align: middle; border: 0; -ms-interpolation-mode: bicubic;'>";
            mensaje += "<h3 style='border-bottom: 2px solid #e67e22; margin-bottom: 25px; color: #585f69; margin: 0 0 -2px 0; padding-right: 10px; display: inline-block; text-shadow: 0 0 1px #f6f6f6; font-weight: normal !important; font-family: 'Open Sans', sans-serif; font-size: 24.5px; line-height: 40px; text-rendering: optimizelegibility; -webkit-margin-before: 1em; -webkit-margin-after: 1em; -webkit-margin-start: 0px; -webkit-margin-end: 0px;' >Nueva Contraseña de Service Market</h3></div><h5 style='color: #555; margin-top: 5px; text-shadow: none; text-shadow: 0 0 1px #f6f6f6; font-weight: normal !important; font-family: 'Open Sans', sans-serif; font-size: 14px; line-height: 20px; text-rendering: optimizelegibility; border-radius: 0 !important; display: block; -webkit-margin-before: 1.67em; -webkit-margin-after: 1.67em; -webkit-margin-start: 0px; -webkit-margin-end: 0px;'>";
            mensaje += "Hemos atendido su solicitud de restauración de contraseña. Su nueva contraseña para Service Market es:</h5><br /><h1 style='color: #e67e22; margin-top: 5px; text-shadow: none; text-shadow: 0 0 1px #f6f6f6; font-weight: normal !important; font-family: 'Open Sans', sans-serif; font-size: 14px; line-height: 20px; text-rendering: optimizelegibility; border-radius: 0 !important; display: block; -webkit-margin-before: 1.67em; -webkit-margin-after: 1.67em; -webkit-margin-start: 0px; -webkit-margin-end: 0px;'>" + password + "</h1><br /><br /><h5 style='color: #555; margin-top: 5px; text-shadow: none; text-shadow: 0 0 1px #f6f6f6; font-weight: normal !important; font-family: 'Open Sans', sans-serif; font-size: 14px; line-height: 20px; text-rendering: optimizelegibility; border-radius: 0 !important; display: block; -webkit-margin-before: 1.67em; -webkit-margin-after: 1.67em; -webkit-margin-start: 0px; -webkit-margin-end: 0px;'>Le recomendamos guardar su contraseña en un lugar seguro.</h5>";
            mensaje += "</div><div style='margin-top: 40px; padding: 20px 10px; background: #585f69; color: #dadada; border-radius: 0 !important; display: block; font-size: 13px; line-height: 1.6;' ><div class='container'><div class='row-fluid'><div class='span12'><h6 style='font-size: 11.9px; margin: 10px 0; font-family: inherit; font-weight: bold; line-height: 20px; color: inherit; text-rendering: optimizelegibility; -webkit-margin-before: 2.33em; -webkit-margin-after: 2.33em; -webkit-margin-start: 0px; -webkit-margin-end: 0px;'>Por favor no responda a este mensaje; fue enviado desde una dirección de correo electrónico no supervisada como parte del servicio de restauración de su contraseña de Service Market.</h6>";
            mensaje += "</div></div></div></div><div style='font-size: 12px; padding: 5px 10px; background: #3e4753; border-top: solid 1px #777; border-radius: 0 !important;'><div class='container'><div class='row-fluid'><div class='span8'><p style='color: #dadada; line-height: 1.6; margin: 0 0 10px; border-radius: 0 !important; display: block; -webkit-margin-before: 1em; -webkit-margin-after: 1em; -webkit-margin-start: 0px; -webkit-margin-end: 0px; font-size: 12px;'>2013 © Service Market. Todos los derechos reservados. <a href='#' style='color: #e67e22; text-decoration: none;'>Política de Privacidad</a> | <a href='#' style='color: #e67e22; text-decoration: none;'>Término de Servicios</a></p></div></div></div></div></div>";

            return mensaje;

        }
        private string MensajeRestablecerPassword(string urlReset, string email)
        {
            string mensaje = string.Empty;
            string imagen = Url.Content(Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port) + "/Images/logo2-blue.png");

            mensaje += "<div style='color: #333; font-size: 13px; line-height: 1.6; font-family: Helvetica Neue, Helvetica, Arial, sans-serif;'><br />";
            mensaje += "<div style='min-width: 90%; max-width: 30%;padding: 20px 50px 30px; overflow: hidden; margin: 0 auto; background: #fcfcfc; border: solid 1px #eee; box-shadow: 0 0 7px #eee;' >";
            mensaje += "<div style='display: block; margin: 10px 0 25px 0; border-bottom: 1px dotted #e4e9f0; border-radius: 0 !important;'>";
            mensaje += "<img id='logo-footer' src='" + imagen + "' alt='Service Market' style='height: auto; max-width: 100%; vertical-align: middle; border: 0; -ms-interpolation-mode: bicubic;'>";
            mensaje += "<h3 style='border-bottom: 2px solid #e67e22; margin-bottom: 25px; color: #585f69; margin: 0 0 -2px 0; padding-right: 10px; display: inline-block; text-shadow: 0 0 1px #f6f6f6; font-weight: normal !important; font-family: 'Open Sans', sans-serif; font-size: 24.5px; line-height: 40px; text-rendering: optimizelegibility; -webkit-margin-before: 1em; -webkit-margin-after: 1em; -webkit-margin-start: 0px; -webkit-margin-end: 0px;' >¿Olvidó su Contraseña de Service Market?</h3></div>";
            mensaje += "<h5 style='color: #555; margin-top: 5px; text-shadow: none; text-shadow: 0 0 1px #f6f6f6; font-weight: normal !important; font-family: 'Open Sans', sans-serif; font-size: 14px; line-height: 20px; text-rendering: optimizelegibility; border-radius: 0 !important; display: block; -webkit-margin-before: 1.67em; -webkit-margin-after: 1.67em; -webkit-margin-start: 0px; -webkit-margin-end: 0px;'>";
            mensaje += "Hemos recibido una solicitud para restablecer la contraseña de su cuenta " + email + ".</h5><h5 style='color: #555; margin-top: 5px; text-shadow: none; text-shadow: 0 0 1px #f6f6f6; font-weight: normal !important; font-family: 'Open Sans', sans-serif; font-size: 14px; line-height: 20px; text-rendering: optimizelegibility; border-radius: 0 !important; display: block; -webkit-margin-before: 1.67em; -webkit-margin-after: 1.67em; -webkit-margin-start: 0px; -webkit-margin-end: 0px;'>Para continuar con el proceso de restauración de contraseña, haga clic en el siguiente botón</h5><br />";
            mensaje += "<br /><a href='" + urlReset + "' style=' padding: 4px 13px; vertical-align: middle; background: #e67e22; border: 0; font-size: 14px; cursor: pointer; position: relative; display: inline-block; color: #fff !important; text-decoration: none !important; outline: 0 !important; line-height: 1.6; border-radius: 0 !important;' >Clic para restablecer su contraseña de Service Market</a>";
            mensaje += "<br /><br /><h5 style='color: #555; margin-top: 5px; text-shadow: none; text-shadow: 0 0 1px #f6f6f6; font-weight: normal !important; font-family: 'Open Sans', sans-serif; font-size: 14px; line-height: 20px; text-rendering: optimizelegibility; border-radius: 0 !important; display: block; -webkit-margin-before: 1.67em; -webkit-margin-after: 1.67em; -webkit-margin-start: 0px; -webkit-margin-end: 0px;'>O puede copiar y pegar la URL en su navegador<br />";
            mensaje += "<a style='color: #e67e22; text-decoration: none;' href='" + urlReset + "'>" + urlReset + "</a></h5></div>";
            mensaje += "<div style='margin-top: 40px; padding: 20px 10px; background: #585f69; color: #dadada; border-radius: 0 !important; display: block; font-size: 13px; line-height: 1.6;' >";
            mensaje += "<div class='container'><div class='row-fluid'><div class='span12'>";
            mensaje += "<h6 style='font-size: 11.9px; margin: 10px 0; font-family: inherit; font-weight: bold; line-height: 20px; color: inherit; text-rendering: optimizelegibility; -webkit-margin-before: 2.33em; -webkit-margin-after: 2.33em; -webkit-margin-start: 0px; -webkit-margin-end: 0px;'>Por favor no responda a este mensaje; fue enviado desde una dirección de correo electrónico no supervisada como parte del servicio de restauración de su contraseña de Service Market.</h6>";
            mensaje += "</div></div></div></div>";
            mensaje += "<div style='font-size: 12px; padding: 5px 10px; background: #3e4753; border-top: solid 1px #777; border-radius: 0 !important;'>";
            mensaje += "<div class='container'><div class='row-fluid'><div class='span8'>";
            mensaje += "<p style='color: #dadada; line-height: 1.6; margin: 0 0 10px; border-radius: 0 !important; display: block; -webkit-margin-before: 1em; -webkit-margin-after: 1em; -webkit-margin-start: 0px; -webkit-margin-end: 0px; font-size: 12px;'>2013 © Service Market. Todos los derechos reservados. <a href='#' style='color: #e67e22; text-decoration: none;'>Política de Privacidad</a> | <a href='#' style='color: #e67e22; text-decoration: none;'>Término de Servicios</a></p>";
            mensaje += "</div></div></div></div></div>";

            return mensaje;

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


                        db.UserProfile.Add(new UserProfile { UserName = model.UserName, ST_Id = 1, MP_MemberShipId = 1, Name = model.UserName });
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
