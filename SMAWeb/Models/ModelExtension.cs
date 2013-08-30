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

    [MetadataType(typeof(MB_MembresiaMetadata))]
    public partial class MB_Membresia
    {
    }

    [MetadataType(typeof(MT_MultimediaTiposMetadata))]
    public partial class MT_MultimediaTipos
    {
    }

    [MetadataType(typeof(PA_PaisesMetadata))]
    public partial class PA_Paises
    {
    }

    [MetadataType(typeof(REG_RegionMetadata))]
    public partial class Reg_Region
    {

    }

    public partial class ST_EstatusMetadata
    {
        [Display(Name = "Código de Estado")]
        public int ST_Id { get; set; }

        [Required]
        [Display(Name = "Descripción del Estado")]
        public string ST_Descripcion { get; set; }

    }

    public partial class AN_AnunciosMetadata
    {
        [Display(Name = "Código Anuncio")]
        public int AN_Id { get; set; }

        [Display(Name = "ID Usuario")]
        public int UserId { get; set; }

        [Display(Name = "ID")]
        public int PA_Id { get; set; }

        [Display(Name = "Código SubCategoría Usuario")]
        public Nullable<int> SBS_Id { get; set; }

        [Display(Name = "Título del Anuncio")]
        public string AN_Titulo { get; set; }

        [Display(Name = "Teléfono")]
        public string AN_Telefono { get; set; }

        [Display(Name = "Celular")]
        public string AN_Celular { get; set; }

        [Display(Name = "Descripción del Anuncio")]
        public string AN_Descripcion { get; set; }

        [Display(Name = "Fecha de Publicación")]
        public System.DateTime AN_Fecha { get; set; }

        [Display(Name = "Fecha de Expiración")]
        public Nullable<System.DateTime> AN_FechaExpiracion { get; set; }

        [Display(Name = "Código de Estado")]
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

    public partial class SBS_SubCategoriaServicioMetadata
    {

        [Display(Name = "Código SubCategoría")]
        public int SBS_Id { get; set; }

        [Display(Name = "Código de Categoría")]
        [Required]
        public Nullable<int> CD_Id { get; set; }


        [Display(Name = "Descripción")]
        [Required]
        public string SBS_Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<AN_Anuncios> AN_Anuncios { get; set; }

        [JsonIgnore]
        [Display(Name = "Categoría")]
        public virtual CD_CategoriaServicio CD_CategoriaServicio { get; set; }
    }

    public partial class CD_CategoriaServicioMetadata
    {
        [Required]
        [Display(Name = "Código Categoría")]
        public int CD_Id { get; set; }
        [Display(Name = "Descripción de la Categoría")]
        public string CD_Descripcion { get; set; }
        [JsonIgnore]
        public virtual ICollection<SBS_SubCategoriaServicio> SBS_SubCategoriaServicio { get; set; }
    }

    public partial class MB_MembresiaMetadata
    {

        [Display(Name = "Código de Membresía")]
        public int MP_MemberShipId { get; set; }

        [Display(Name = "Descripción de Membresía")]
        public string MP_Descripcion { get; set; }

        [Display(Name = "Días de Expiración")]
        public Nullable<int> MP_ExpiracionDays { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }

    public partial class MT_MultimediaTiposMetadata
    {

        [Display(Name = "Código de Tipo de Multimedios")]
        public int MT_Id { get; set; }

        [Display(Name = "Descripción Tipo de Multimedios")]
        public string MT_Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<AM_MultimediaAnuncios> AM_MultimediaAnuncios { get; set; }
    }

    public partial class PA_PaisesMetadata
    {

        [Display(Name = "Código de País")]
        public int PA_Id { get; set; }

        [Display(Name = "Descripción de País")]
        public string PA_Descripcion { get; set; }

        [Display(Name = "Código de Región")]
        public int REG_Id { get; set; }

        public virtual REG_Region REG_Region { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }

    public partial class REG_RegionMetadata
    {
        [Display(Name = "Código de Región")]
        public int REG_Id { get; set; }

        [Display (Name= "Descripción de Región")]
        public string REG_Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<PA_Paises> PA_Paises { get; set; }
    }

    public class AnunciosViewModel
    {
        public AN_Anuncios AnunciosInfo { get; set; }
        public string EstatusDescription { get; set; }
        public string Usuario { get; set; }
        public string CategoriaDescripcion { get; set; }

    }



}