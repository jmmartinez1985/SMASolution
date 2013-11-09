using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMAWeb.Controllers
{
    public class ErrorController : BaseController
    {
        //
        // GET: /Error/

        public ViewResult Index()
        {
            return View("Error");
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            ViewBag.Message = Response.StatusDescription.ToString();
            return View("NotFound");
        }

    }
}
