using Newtonsoft.Json;
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


    [MetadataType(typeof(AN_AnunciosMetadata))]
    public partial class AN_Anuncios
    {
    }

    [MetadataType(typeof(SBS_SubCategoriaServicioMetadata))]
    public partial class SBS_SubCategoriaServicio
    {
    }
    [MetadataType(typeof(CD_CategoriaServicioMetadata))]
    public partial class CD_CategoriaServicio
    {
    }


    public partial class AN_AnunciosMetadata
    {


        public int AN_Id { get; set; }
        public int UserId { get; set; }
        public int PA_Id { get; set; }
        public Nullable<int> SBS_Id { get; set; }
        public string AN_Titulo { get; set; }
        public string AN_Telefono { get; set; }
        public string AN_Celular { get; set; }
        public string AN_Descripcion { get; set; }
        public System.DateTime AN_Fecha { get; set; }
        public Nullable<System.DateTime> AN_FechaExpiracion { get; set; }
        public int ST_Id { get; set; }

        [JsonIgnore]
        public virtual ICollection<AE_AnunciosExtras> AE_AnunciosExtras { get; set; }
        [JsonIgnore]
        public virtual ICollection<AM_MultimediaAnuncios> AM_MultimediaAnuncios { get; set; }
        [JsonIgnore]
        public virtual SBS_SubCategoriaServicio SBS_SubCategoriaServicio { get; set; }
        [JsonIgnore]
        public virtual ST_Estatus ST_Estatus { get; set; }
        [JsonIgnore]
        public virtual UserProfile UserProfile { get; set; }
        [JsonIgnore]
        public virtual ICollection<SS_SolicitudServicio> SS_SolicitudServicio { get; set; }
    }

    public partial class ST_EstatusMetadata
    {

        public int ST_Id { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string ST_Descripcion { get; set; }

    }

    public partial class SBS_SubCategoriaServicioMetadata
    {

        [Display(Name = "Código SubCategoría")]
        public int SBS_Id { get; set; }

        [Display(Name = "Código Categoría")]
        [Required]
        public Nullable<int> CD_Id { get; set; }

         [Required]
        [Display(Name = "Descripcion")]
        public string SBS_Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<AN_Anuncios> AN_Anuncios { get; set; }
        [JsonIgnore]
        [Display(Name = "Categorias")]
        public virtual CD_CategoriaServicio CD_CategoriaServicio { get; set; }
    }

    public partial class CD_CategoriaServicioMetadata
    {
        [Required]
        [Display(Name = "Código Categoría")]
        public int CD_Id { get; set; }
        [Display(Name = "Descripcion")]
        public string CD_Descripcion { get; set; }
        [JsonIgnore]
        public virtual ICollection<SBS_SubCategoriaServicio> SBS_SubCategoriaServicio { get; set; }
    }

    public class AnunciosViewModel
    {
        public AN_Anuncios AnunciosInfo { get; set; }
        public string EstatusDescription { get; set; }
        public string Usuario { get; set; }
        public string CategoriaDescripcion { get; set; }

    }

}