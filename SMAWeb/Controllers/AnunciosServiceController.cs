using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SMAWeb.Models;

namespace SMAWeb.Controllers
{
    public class AnunciosServiceController : ApiController
    {
        private readonly Entities _db = new Entities();

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var anuncios = new List<AnunciosViewModel>();

            var anunciosList = _db.AN_Anuncios
                    .OrderByDescending(c => c.AN_Fecha).ToList();

            Parallel.ForEach(anunciosList, (item, status) =>
            {
                var username = item.UserProfile.Name;
                var statusDesc = item.ST_Estatus.ST_Descripcion;
                var categoria = item.SBS_SubCategoriaServicio.CD_CategoriaServicio.CD_Descripcion;
                var firstImage = string.Empty;

                var aeAnunciosExtras = item.AE_AnunciosExtras.FirstOrDefault();
                if (aeAnunciosExtras != null)
                    firstImage = aeAnunciosExtras.AN_ImagenUrl;

                var urlimg = "";//Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
                var formatted = firstImage.Replace("~", "");
                if (formatted.StartsWith("/"))
                    formatted = formatted.Remove(0, 1);
                firstImage = urlimg + formatted;

                anuncios
                    .Add(new AnunciosViewModel
                    {
                        Usuario = username,
                        EstatusDescription = statusDesc,
                        AnunciosInfo = item,
                        CategoriaDescripcion = categoria,
                        FirstImage = firstImage
                    });
            });

            return Request.CreateResponse(HttpStatusCode.OK, anuncios);
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var anuncio = _db.AN_Anuncios.Find(id);
            if (anuncio == null)
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Anuncio no encontrado.")
                });

            var reviews = new List<ContentReviews>();
            anuncio
                .SS_SolicitudServicio
                .ToList()
                .ForEach(
                an =>
                {
                    reviews.Add(new ContentReviews { ReviewsList = an.RW_Reviews, SolicitudProfilePic = an.UserProfile.Image });
                });

            var anuncios = new 
            {
                Anuncio = anuncio,
                Reviews = reviews
            };

            return Request.CreateResponse(HttpStatusCode.OK, anuncios);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}