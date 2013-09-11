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

    #region MetadataType

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

    [MetadataType(typeof(UserProfileMetadata))]
    public partial class UserProfile
    {

    }

    [MetadataType(typeof(CON_ContactenosMetadata))]
    public partial class CON_Contactenos
    {

    }

    [MetadataType(typeof(COM_CompañiaMetadata))]
    public partial class COM_Compañia
    {

    }
    #endregion


    #region PartialClass


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

        [Display(Name = "Código SubCategoría")]
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

        [Display(Name = "Lugar del Anuncio")]
        public string AN_Area { get; set; }

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
        [Range(0, Int32.MaxValue, ErrorMessage = "No es un número válido o no está en el rango permitido.")]
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

        [Display(Name = "Descripción de Región")]
        public string REG_Descripcion { get; set; }

        [JsonIgnore]
        [Display(Name = "País")]
        public virtual ICollection<PA_Paises> PA_Paises { get; set; }
    }

    public partial class UserProfileMetadata
    {

        [Display(Name = "Código de Usuario")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Correo")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public string Name { get; set; }

        [Display(Name = "Detalle")]
        public string Details { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Código de País")]
        public Nullable<int> PA_Id { get; set; }

        public byte[] Image { get; set; }
        public int MP_MemberShipId { get; set; }

        public int ST_Id { get; set; }

        [JsonIgnore]
        public virtual ICollection<AN_Anuncios> AN_Anuncios { get; set; }

        [JsonIgnore]
        public virtual MB_Membresia MB_Membresia { get; set; }

        [Display(Name = "País")]
        [JsonIgnore]
        public virtual PA_Paises PA_Paises { get; set; }

        [JsonIgnore]
        public virtual ST_Estatus ST_Estatus { get; set; }

        [JsonIgnore]
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }

    public partial class CON_ContactenosMetadata
    {
        [Required]
        [Display(Name = "Código Contacto")]
        public int CON_Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string CON_Nombre { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string CON_Telefono { get; set; }

        [Required]
        [Display(Name = "Celular")]
        public string CON_Celular { get; set; }

        [Required]
        [Display(Name = "Correo Electrónico")]
        public string CON_Email { get; set; }

        [Required]
        [Display(Name = "Mensaje")]
        public string CON_Mensaje { get; set; }

        [Required]
        [Display(Name = "Fecha de Contacto")]
        public System.DateTime CON_Fecha { get; set; }
    }

    public partial class COM_CompañiaMetadata
    {
        [Required]
        [Display(Name = "Código de Compañía")]
        public int COM_Id { get; set; }

        [Required]
        [Display(Name = "Nombre de Compañía")]
        public string COM_Nombre { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string COM_Direccion { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string COM_Telefono { get; set; }

        [Required]
        [Display(Name = "Correo")]
        public string COM_Correo { get; set; }

        [Required]
        [Display(Name = "Dirección Web")]
        public string COM_Web { get; set; }

        [Display(Name = "Persona de Contacto")]
        public string COM_ContactoNombre { get; set; }

        [Display(Name = "Celular de Contacto")]
        public string COM_ContactoCelular { get; set; }

        [Display(Name = "Email de Contacto")]
        public string COM_ContactoEmail { get; set; }

        public byte[] COM_Logo { get; set; }

    }

    public partial class FAQsMetadata
    {
        [Required]
        [Display(Name = "Código de FAQ")]
        public int FAQ_Id { get; set; }

        [Required]
        [Display(Name = "Pregunta")]
        public string FAQ_Question { get; set; }

        [Required]
        [Display(Name = "Respuesta")]
        public string FAQ_Answer { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int FAQ_Status { get; set; }

        [JsonIgnore]
        public virtual ST_Estatus ST_Estatus { get; set; }
    }

    #endregion

    #region ViewModel

    public class AnunciosViewModel
    {

        public AN_Anuncios AnunciosInfo { get; set; }
        public string EstatusDescription { get; set; }
        public string Usuario { get; set; }
        public string CategoriaDescripcion { get; set; }
        public string FirstImage { get; set; }
    }

    #endregion




}