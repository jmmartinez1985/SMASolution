using SMAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMAWeb.Controllers
{
    public class BlogController : BaseController
    {
        //
        // GET: /Blog/
        //[Authorize(Roles="Admin")]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "SuperUsers")]
        public ActionResult Create()
        {
            var personalDetail = new PersonalDetail();
            return View(personalDetail);
        }

        [HttpPost]
        public string Create(PersonalDetail personalDetails)
        {
            return "Hi " + personalDetails.Name + "!. Thanks for providing the details.";
        } 


    }
}
