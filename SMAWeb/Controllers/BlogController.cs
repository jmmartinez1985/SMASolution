using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMAWeb.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/
        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
