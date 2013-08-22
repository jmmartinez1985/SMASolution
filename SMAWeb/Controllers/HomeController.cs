using SMAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMAWeb.Extensions;

namespace SMAWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";



            return View();
        }


        public ActionResult GetServices()
        {
            var allAnunciosList = new List<AN_Anuncios>();
            List<AnunciosViewModel> viewModelAnuncios = new List<AnunciosViewModel>();
            using (Entities model = new Entities())
            {
                allAnunciosList = model.AN_Anuncios.OrderBy(c => c.AN_Fecha).ToList();

                foreach (var item in allAnunciosList)
                {
                    string username = model.UserProfile.SingleOrDefault(c => c.UserId == item.UserId).UserName;
                    string statusDesc = model.ST_Estatus.SingleOrDefault( c=>c.ST_Id == item.ST_Id).ST_Descripcion;

                    var valor = model.SBS_SubCategoriaServicio.SingleOrDefault(c => c.SBS_Id == item.SBS_Id);
                    viewModelAnuncios.Add(new AnunciosViewModel
                    {
                        Usuario = username,
                        EstatusDescription = statusDesc,
                        AnunciosInfo = item
                    });

                }
            }
            if (viewModelAnuncios == null || viewModelAnuncios.Count == 0)
            {
                return HttpNotFound();
            }

            var anuncios = viewModelAnuncios.SerializeToJson();
            return Json(anuncios);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}
