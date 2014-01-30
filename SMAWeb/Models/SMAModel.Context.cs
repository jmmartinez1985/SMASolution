﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMAWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AM_MultimediaAnuncios> AM_MultimediaAnuncios { get; set; }
        public DbSet<CD_CategoriaServicio> CD_CategoriaServicio { get; set; }
        public DbSet<COM_Compañia> COM_Compañia { get; set; }
        public DbSet<CON_Contactenos> CON_Contactenos { get; set; }
        public DbSet<CONF_Parametros> CONF_Parametros { get; set; }
        public DbSet<FAQs> FAQs { get; set; }
        public DbSet<MT_MultimediaTipos> MT_MultimediaTipos { get; set; }
        public DbSet<PA_Paises> PA_Paises { get; set; }
        public DbSet<SBS_SubCategoriaServicio> SBS_SubCategoriaServicio { get; set; }
        public DbSet<SS_SolicitudServicio> SS_SolicitudServicio { get; set; }
        public DbSet<ST_Estatus> ST_Estatus { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
        public DbSet<RW_Reviews> RW_Reviews { get; set; }
        public DbSet<BL_BlackList> BL_BlackList { get; set; }
        public DbSet<CR_ComentarioReview> CR_ComentarioReview { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<AE_AnunciosExtras> AE_AnunciosExtras { get; set; }
        public DbSet<AN_Anuncios> AN_Anuncios { get; set; }
        public DbSet<ELMAH_Error> ELMAH_Error { get; set; }
        public DbSet<MB_Membresia> MB_Membresia { get; set; }
        public DbSet<MC_MembresiaControl> MC_MembresiaControl { get; set; }
    
        public virtual ObjectResult<SEL_BusquedaAvanzada_Result> SEL_BusquedaAvanzada(Nullable<int> categoria, Nullable<int> subCategoria, string descripcion, string lugar)
        {
            var categoriaParameter = categoria.HasValue ?
                new ObjectParameter("Categoria", categoria) :
                new ObjectParameter("Categoria", typeof(int));
    
            var subCategoriaParameter = subCategoria.HasValue ?
                new ObjectParameter("SubCategoria", subCategoria) :
                new ObjectParameter("SubCategoria", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var lugarParameter = lugar != null ?
                new ObjectParameter("Lugar", lugar) :
                new ObjectParameter("Lugar", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SEL_BusquedaAvanzada_Result>("SEL_BusquedaAvanzada", categoriaParameter, subCategoriaParameter, descripcionParameter, lugarParameter);
        }
    
        public virtual int sp_SEL_BusquedaAvanzada(Nullable<int> categoria, Nullable<int> subCategoria, string descripcion, string lugar)
        {
            var categoriaParameter = categoria.HasValue ?
                new ObjectParameter("Categoria", categoria) :
                new ObjectParameter("Categoria", typeof(int));
    
            var subCategoriaParameter = subCategoria.HasValue ?
                new ObjectParameter("SubCategoria", subCategoria) :
                new ObjectParameter("SubCategoria", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var lugarParameter = lugar != null ?
                new ObjectParameter("Lugar", lugar) :
                new ObjectParameter("Lugar", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_SEL_BusquedaAvanzada", categoriaParameter, subCategoriaParameter, descripcionParameter, lugarParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SEL_ValoracionAnuncios(Nullable<int> aN_Id)
        {
            var aN_IdParameter = aN_Id.HasValue ?
                new ObjectParameter("AN_Id", aN_Id) :
                new ObjectParameter("AN_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SEL_ValoracionAnuncios", aN_IdParameter);
        }
    
        public virtual ObjectResult<Nullable<short>> Get_Anuncio_Rating(Nullable<int> aN_Id)
        {
            var aN_IdParameter = aN_Id.HasValue ?
                new ObjectParameter("AN_Id", aN_Id) :
                new ObjectParameter("AN_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<short>>("Get_Anuncio_Rating", aN_IdParameter);
        }
    
        public virtual int get_Busqueda_Avanzada(Nullable<int> categoria, Nullable<int> subCategoria, string descripcion, string lugar)
        {
            var categoriaParameter = categoria.HasValue ?
                new ObjectParameter("Categoria", categoria) :
                new ObjectParameter("Categoria", typeof(int));
    
            var subCategoriaParameter = subCategoria.HasValue ?
                new ObjectParameter("SubCategoria", subCategoria) :
                new ObjectParameter("SubCategoria", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var lugarParameter = lugar != null ?
                new ObjectParameter("Lugar", lugar) :
                new ObjectParameter("Lugar", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("get_Busqueda_Avanzada", categoriaParameter, subCategoriaParameter, descripcionParameter, lugarParameter);
        }
    
        public virtual ObjectResult<AN_Anuncios> Get_AdvanceSearch(Nullable<int> categoria, Nullable<int> subCategoria, string descripcion, string lugar)
        {
            var categoriaParameter = categoria.HasValue ?
                new ObjectParameter("Categoria", categoria) :
                new ObjectParameter("Categoria", typeof(int));
    
            var subCategoriaParameter = subCategoria.HasValue ?
                new ObjectParameter("SubCategoria", subCategoria) :
                new ObjectParameter("SubCategoria", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var lugarParameter = lugar != null ?
                new ObjectParameter("Lugar", lugar) :
                new ObjectParameter("Lugar", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AN_Anuncios>("Get_AdvanceSearch", categoriaParameter, subCategoriaParameter, descripcionParameter, lugarParameter);
        }
    
        public virtual ObjectResult<AN_Anuncios> Get_AdvanceSearch(Nullable<int> categoria, Nullable<int> subCategoria, string descripcion, string lugar, MergeOption mergeOption)
        {
            var categoriaParameter = categoria.HasValue ?
                new ObjectParameter("Categoria", categoria) :
                new ObjectParameter("Categoria", typeof(int));
    
            var subCategoriaParameter = subCategoria.HasValue ?
                new ObjectParameter("SubCategoria", subCategoria) :
                new ObjectParameter("SubCategoria", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var lugarParameter = lugar != null ?
                new ObjectParameter("Lugar", lugar) :
                new ObjectParameter("Lugar", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AN_Anuncios>("Get_AdvanceSearch", mergeOption, categoriaParameter, subCategoriaParameter, descripcionParameter, lugarParameter);
        }
    
        public virtual ObjectResult<string> SEL_MembresiasPorExpirar() 
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SEL_MembresiasPorExpirar");
        }
    
        public virtual ObjectResult<string> UPD_MembresiasExpiradas() 
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("UPD_MembresiasExpiradas");
        }
    
        public virtual int get_MembresiaPorExpirar()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("get_MembresiaPorExpirar");
        }
    }
}
