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

    [MetadataType(typeof(FAQsMetadata))]
    public partial class FAQs
    {

    }

    [MetadataType(typeof(SS_SolicitudServicioMetadata))]
    public partial class SS_SolicitudServicio
    {

    }

    [MetadataType(typeof(RW_ReviewsMetadata))]
    public partial class RW_Reviews
    {

    }

    [MetadataType(typeof(LoginModelMetadata))]
    public partial class LoginModel
    {

    }

    #endregion

    #region PartialClass

    public partial class ST_EstatusMetadata
    {
        [Required]
        [Display(Name = "Código de Estado")]
        public int ST_Id { get; set; }

        [Required]
        [Display(Name = "Descripción del Estado")]
        public string ST_Descripcion { get; set; }

    }

    public partial class AN_AnunciosMetadata
    {
        [Required]
        [Display(Name = "Código Anuncio")]
        public int AN_Id { get; set; }

        [Required]
        [Display(Name = "ID Usuario")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Por favor seleccione el país del anuncio")]
        [Display(Name = "País")]
        public int PA_Id { get; set; }

        [Display(Name = "SubCategoría")]
        public Nullable<int> SBS_Id { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el título del anuncio.")]
        [StringLength(150, ErrorMessage = "Por favor verifique el título del anuncio, sólo se permite un título de hasta 150 dígitos.")]
        [Display(Name = "Título del Anuncio")]
        public string AN_Titulo { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el teléfono 1.")]
        [StringLength(20, ErrorMessage = "Por favor verifique el campo teléfono 1, sólo se permite un teléfono de hasta 20 dígitos.")]
        [Display(Name = "Teléfono 1")]
        public string AN_Telefono { get; set; }

        [Display(Name = "Teléfono 2")]
        [StringLength(20, ErrorMessage = "Por favor verifique el campo teléfono 2, sólo se permite un teléfono de hasta 20 dígitos.")]
        public string AN_Celular { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la descripción del anuncio.")]
        [StringLength(2000, ErrorMessage = "Por favor verifique el campo descripción del anuncio, sólo se permite una descripción de hasta 2000 dígitos.")]
        [Display(Name = "Descripción")]
        public string AN_Descripcion { get; set; }

        [Display(Name = "Fecha de Publicación")]
        public System.DateTime AN_Fecha { get; set; }

        [Display(Name = "Fecha de Expiración")]
        public Nullable<System.DateTime> AN_FechaExpiracion { get; set; }

        [Display(Name = "Código de Estado")]
        public int ST_Id { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el lugar del anuncio.")]
        [Display(Name = "Lugar del Anuncio")]
        public string AN_Area { get; set; }

        [Required(ErrorMessage = "Por favor seleccione la categoría del anuncio")]
        [Display(Name = "Categoría")]
        public Nullable<int> CD_Id { get; set; }


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
        [JsonIgnore]
        public virtual CD_CategoriaServicio CD_CategoriaServicio { get; set; }
        [JsonIgnore]
        public virtual PA_Paises PA_Paises { get; set; }

    }

    public partial class SBS_SubCategoriaServicioMetadata
    {

        [Display(Name = "Código SubCategoría")]
        public int SBS_Id { get; set; }

        [Display(Name = "Código de Categoría")]
        [Required(ErrorMessage = "Por favor seleccione una categoría.")]
        public Nullable<int> CD_Id { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Por favor ingrese la descripción.")]
        [StringLength(100, ErrorMessage = "Por favor verifique el campo descripción, sólo permite una descripción de hasta 100 dígitos.")]
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
        [Required(ErrorMessage = "Por favor ingrese la descripción de la categoría.")]
        [StringLength(100, ErrorMessage = "Por favor verifique el campo descripción de la categoría, sólo se permite una descripción de hasta 100 dígitos.")]
        public string CD_Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<SBS_SubCategoriaServicio> SBS_SubCategoriaServicio { get; set; }
    }

    public partial class MB_MembresiaMetadata
    {

        [Display(Name = "Código de Membresía")]
        public int MP_MemberShipId { get; set; }

        [Display(Name = "Descripción de Membresía")]
        [Required(ErrorMessage = "Por favor ingrese la descripción de la membresía.")]
        [StringLength(100, ErrorMessage = "Por favor verifique el campo descripción de membresía, sólo se permite una descripción de hasta 100 dígitos.")]
        public string MP_Descripcion { get; set; }

        [Display(Name = "Días de Expiración")]
        [Required(ErrorMessage = "Por favor ingrese los días de expiración de la membresía.")]
        //[StringLength(4, ErrorMessage = "Por favor verifique el campo días de expiración, sólo se permiten números de hasta 4 dígitos.")]
        [RegularExpression(@"([1-9][0-9]*)", ErrorMessage = "Por favor revise los datos ingresados para el campo días de expiración.")]
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

        [Display(Name = "País")]
        [Required(ErrorMessage = "Por favor ingrese el país")]
        [StringLength(50, ErrorMessage = "Por favor verifique el campo país, sólo se permite nombre de países de hasta 50 dígitos.")]
        public string PA_Descripcion { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }

    public partial class REG_RegionMetadata
    {
        [Display(Name = "Código de Región")]
        [Required(ErrorMessage = "Por favor seleccione la región.")]
        public int REG_Id { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la descripción de la región.")]
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
        [Display(Name = "Correo Electrónico")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public string Name { get; set; }

        [Display(Name = "Profesión")]
        public string Details { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Nacionalidad")]
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
        [Display(Name = "ID")]
        public int CON_Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string CON_Nombre { get; set; }

        [Display(Name = "Teléfono")]
        public string CON_Telefono { get; set; }

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

        [Required(ErrorMessage = "Por favor ingrese el nombre de la compañía")]
        [StringLength(100, ErrorMessage = "Por favor verifique el campo nombre de la compañía, sólo se permite nombres de hasta 100 dígitos.")]
        [Display(Name = "Nombre de Compañía")]
        public string COM_Nombre { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la dirección de la compañía")]
        [Display(Name = "Dirección")]
        [StringLength(150, ErrorMessage = "Por favor verifique el campo dirección de la compañía, sólo se permite una dirección de hasta 150 dígitos.")]
        public string COM_Direccion { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el teléfono de la compañía")]
        [Display(Name = "Teléfono")]
        [StringLength(20, ErrorMessage = "Por favor verifique el campo teléfono de la compañía, sólo se permite un número telefónico de hasta 20 dígitos.")]
        public string COM_Telefono { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el correo electrónico de la compañía")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Por favor revise los datos ingresados para el campo correo electrónico.")]
        [Display(Name = "Correo Electrónico")]
        [StringLength(50, ErrorMessage = "Por favor verifique el campo correo electrónico, sólo se permite una dirección de correo electrónico de hasta 50 dígitos.")]
        public string COM_Correo { get; set; }

        [Display(Name = "Dirección Web")]
        [StringLength(150, ErrorMessage = "Por favor verifique el campo dirección web, sólo se permite una dirección web de hasta 150 dígitos.")]
        public string COM_Web { get; set; }

        [Display(Name = "Persona de Contacto")]
        [StringLength(50, ErrorMessage = "Por favor verifique el campo persona, sólo se permite un nombre de persona de contacto de hasta 50 dígitos.")]
        public string COM_ContactoNombre { get; set; }

        [Display(Name = "Teléfono de Contacto")]
        [StringLength(20, ErrorMessage = "Por favor verifique el campo teléfono de contacto, sólo se permite un número telefónico de contacto de hasta 20 dígitos.")]
        public string COM_ContactoCelular { get; set; }

        [Display(Name = "Correo Electrónico de Contacto")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Por favor revise los datos ingresados para el campo correo electrónico de contacto.")]
        [StringLength(50, ErrorMessage = "Por favor verifique el campo correo electrónico de contacto, sólo se permite una dirección de correo electrónico de hasta 50 dígitos.")]
        public string COM_ContactoEmail { get; set; }


        public byte[] COM_Logo { get; set; }

    }

    public partial class FAQsMetadata
    {
        [Display(Name = "Código de FAQ")]
        public int FAQ_Id { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la pregunta.")]
        [StringLength(200, ErrorMessage = "Por favor verifique el campo pregunta, sólo se permite una pregunta máxima de 200 dígitos.")]
        [Display(Name = "Pregunta")]
        public string FAQ_Question { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la respuesta.")]
        [StringLength(500, ErrorMessage = "Por favor verifique el campo respuesta, sólo se permite una respuesta máxima de 500 dígitos.")]
        [Display(Name = "Respuesta")]
        public string FAQ_Answer { get; set; }

        [Required(ErrorMessage = "Por favor seleccione el estado.")]
        [Display(Name = "Estado")]
        public int FAQ_Status { get; set; }

        [JsonIgnore]
        public virtual ST_Estatus ST_Estatus { get; set; }
    }

    public partial class SS_SolicitudServicioMetadata
    {
        public SS_SolicitudServicioMetadata()
        {
            this.RW_Reviews = new HashSet<RW_Reviews>();
        }

        [Display(Name = "Código de Solicitud de Servicio")]
        public int SS_Id { get; set; }

        [Display(Name = "Código de Anuncio")]
        public int AN_Id { get; set; }

        [Display(Name = "Fecha")]
        public System.DateTime SS_Fecha { get; set; }

        //[Display(Name = "Nombre")]
        //public string SS_Nombre { get; set; }

        //[Display(Name = "Correo Electrónico")]
        //public string SS_Mail { get; set; }

        //[Display(Name = "Teléfono")]
        //public string SS_Telefono { get; set; }

        //[Display(Name = "Celular")]
        //public string SS_Celular { get; set; }

        //[Display(Name = "Descripción")]
        //public string SS_Descripcion { get; set; }

        [Display(Name = "Estado")]
        public int ST_Id { get; set; }

        [JsonIgnore]
        public virtual AN_Anuncios AN_Anuncios { get; set; }

        [JsonIgnore]
        public virtual ICollection<RW_Reviews> RW_Reviews { get; set; }

        [JsonIgnore]
        public virtual ST_Estatus ST_Estatus { get; set; }
    }

    public partial class RW_ReviewsMetadata
    {
        [Required]
        [Display(Name = "Código Comentario")]
        public int RW_Id { get; set; }

        [Required]
        [Display(Name = "Código de Solicitud de Servicio")]
        public int SS_Id { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su comentario.")]
        [Display(Name = "Comentario")]
        public string RW_Comentario { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        public System.DateTime RW_Fecha { get; set; }

        [Required]
        [Display(Name = "Calificación")]
        public Nullable<byte> RW_Rate { get; set; }

        [JsonIgnore]
        public virtual SS_SolicitudServicio SS_SolicitudServicio { get; set; }

        [JsonIgnore]
        public virtual ICollection<CR_ComentarioReview> CR_ComentarioReview { get; set; }
    }

    public partial class LoginModelMetadata
    {
        [Required(ErrorMessage = "Por favor ingrese su dirección de correo electrónico")]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Verifique el formato de su dirección de correo electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordar mis datos")]
        public bool RememberMe { get; set; }
    }

    #endregion

    #region ViewModel

    public class AnunciosViewModel
    {

        public AN_Anuncios AnunciosInfo { get; set; }
        public List<RW_Reviews> ReviewList { get; set; }
        public string EstatusDescription { get; set; }
        public string Usuario { get; set; }
        public string CategoriaDescripcion { get; set; }
        public string FirstImage { get; set; }
        public int? Rating { get; set; }
        public int Comments { get; set; }

    }

    public class CategoriaSubCategoriaViewModel
    {
        public CategoriaSubCategoriaViewModel()
        {
            SubCategorias = new List<SBS_SubCategoriaServicio>();
        }
        public CD_CategoriaServicio Categoria { get; set; }
        public ICollection<SBS_SubCategoriaServicio> SubCategorias { get; set; }
    }

    public class Categoria
    {
        public Categoria()
        {
            SubCatCollection = new List<SubCategorias>();
        }
        public int CatId { get; set; }
        public string CatDesc { get; set; }
        public ICollection<SubCategorias> SubCatCollection { get; set; }

    }

    public class SubCategorias
    {
        public int SubCatId { get; set; }
        public string SubCatDesc { get; set; }

    }

    public class SolicitudViewModel
    {
        [Display(Name = "Solicitud")]
        public int Solicitud { get; set; }

        [Display(Name = "Fecha")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Solicitante")]
        public string Solicitante { get; set; }

        [Display(Name = "Correo")]
        public string EmailSolicitante { get; set; }

        [Display(Name = "Teléfono")]
        public string TelefonoSolicitante { get; set; }

        [Display(Name = "Código Estado")]
        public int StatusId { get; set; }

        [Display(Name = "Estado")]
        [JsonIgnore]
        public string Status { get; set; }
    }

    public class ContentReviews
    {
        public ContentReviews()
        {
            ReviewsList = new List<RW_Reviews>();
        }
        public string SolicitudProfilePic { get; set; }
        public ICollection<RW_Reviews> ReviewsList { get; set; }


    }

    #endregion




}