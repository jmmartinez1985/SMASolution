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
                    string username = item.UserProfile.Name;
                    string statusDesc = item.ST_Estatus.ST_Descripcion;
                    var categoria = item.SBS_SubCategoriaServicio.CD_CategoriaServicio.CD_Descripcion;
                    viewModelAnuncios.Add(new AnunciosViewModel
                    {
                        Usuario = username,
                        EstatusDescription = statusDesc,
                        AnunciosInfo = item, CategoriaDescripcion = categoria
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
