using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMAWeb.Models
{
    public class ModelExtension
    {
    }


    [MetadataType(typeof(ST_EstatusMetadata))]
    public partial class ST_Estatus
    {
    }

    public partial class ST_EstatusMetadata
    {

        public int ST_Id { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string ST_Descripcion { get; set; }

    }

    public class AnunciosViewModel 
    {
        public AN_Anuncios AnunciosInfo { get; set; }
        public string EstatusDescription { get; set; }
        public string Usuario { get; set; }
        public string CategoriaDescripcion { get; set; }

    }

}