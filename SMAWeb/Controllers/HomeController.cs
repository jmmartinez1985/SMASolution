using SMAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMAWeb.Extensions;
using SMAWeb.Filters;
using WebMatrix.WebData;
using Postal;


namespace SMAWeb.Controllers
{
    public class HomeController : BaseController
    {


        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            using (var db = new Entities())
            {
                var ListCategorias = db.CD_CategoriaServicio.ToList();
                var firstCategoria = ListCategorias.FirstOrDefault().CD_Id;
                var ListSubCategory = db.SBS_SubCategoriaServicio.Where(c => c.CD_Id == firstCategoria).ToList();
                ViewBag.IsIncomplete = false;
                ViewBag.Categories = new SelectList(ListCategorias, "CD_Id", "CD_Descripcion");
                ViewBag.SubCategories = new SelectList(ListSubCategory, "SBS_Id", "SBS_Descripcion");

                //if (Request.IsAuthenticated)
                //{
                //    var user = db.UserProfile.FirstOrDefault(c => c.UserId == WebSecurity.CurrentUserId);
                //    if (user != null)
                //    {
                //        if (user.Name == null | user.UserName == null)
                //        {
                //            ViewBag.IsIncomplete = true;
                //        }
                //    }
                //}

            }

            return View();
        }

        public ActionResult VerifyCompleteCredential()
        {
            using (var db = new Entities())
            {
                if (Request.IsAuthenticated)
                {
                    var user = db.UserProfile.FirstOrDefault(c => c.UserId == WebSecurity.CurrentUserId);
                    if (user != null)
                    {
                        if (user.Name == null | user.UserName == null)
                        {
                            return Json(new { IsIncomplete = true });
                        }
                    }
                }
            }
            return Json(new { IsIncomplete = false });
        }

        public ActionResult VerifySolicitudesPendientes()
        {
            var anunciosSolicitados = new List<SS_SolicitudServicio>();
            using (Entities model = new Entities())
            {
                if (Request.IsAuthenticated)
                {
                    anunciosSolicitados = model.SS_SolicitudServicio.Where(c => c.ST_Id == 1 & c.UserId == WebSecurity.CurrentUserId).ToList();
                    var total = anunciosSolicitados.Count();
                    if (total > 0)
                        return Json(new { SolicitudesPendientes = true });
                    else
                        return Json(new { SolicitudesPendientes = false });
                }
            }
            return Json(new { SolicitudesPendientes = false });
        }

        public ActionResult GetServices()
        {
            var allAnunciosList = new List<AN_Anuncios>();
            List<AnunciosViewModel> viewModelAnuncios = new List<AnunciosViewModel>();
            using (Entities model = new Entities())
            {
                allAnunciosList = model.AN_Anuncios.AsParallel().OrderByDescending(c => c.AN_Fecha).Where(sts => sts.ST_Id == 1).ToList();

                foreach (var item in allAnunciosList)
                {
                    string username = item.UserProfile.Name;
                    string statusDesc = item.ST_Estatus.ST_Descripcion;
                    var categoria = item.SBS_SubCategoriaServicio.CD_CategoriaServicio.CD_Descripcion;
                    var firstImage = string.Empty;
                    if (item.AE_AnunciosExtras.FirstOrDefault() != null)
                    {
                        firstImage = item.AE_AnunciosExtras.FirstOrDefault().AN_ImagenUrl;
                    }
                    else
                    {
                        firstImage = item.UserProfile.Image == null ? "~/Images/No_Profile.jpg" : item.UserProfile.Image;
                    }

                    //item.AN_Fecha = Convert.ToDateTime(item.AN_Fecha.ToShortDateString());

                    var getRating = model.SEL_ValoracionAnuncios(item.AN_Id).FirstOrDefault();

                    string urlimg = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
                    var formatted = firstImage.Replace("~", "");
                    if (formatted.StartsWith("/"))
                        formatted = formatted.Remove(0, 1);
                    firstImage = urlimg + formatted;

                    var number = 0;
                    item.SS_SolicitudServicio.AsParallel().ToList().ForEach((counter) =>
                    {
                        number += counter.RW_Reviews.Count;
                    });
                    viewModelAnuncios.Add(new AnunciosViewModel
                    {
                        Usuario = username,
                        EstatusDescription = statusDesc,
                        AnunciosInfo = item,
                        CategoriaDescripcion = categoria,
                        FirstImage = firstImage,
                        Rating = getRating,
                        Comments = number,
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

        public ActionResult Terminos()
        {
            ViewBag.Message = "Términos y Condiciones.";
            return View();
        }

        public ActionResult Policy()
        {
            ViewBag.Message = "Políticas de Privacidad";
            return View();
        }
    }
}
