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
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
            base.Configuration.ProxyCreationEnabled = false;
            base.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AE_AnunciosExtras> AE_AnunciosExtras { get; set; }
        public DbSet<AM_MultimediaAnuncios> AM_MultimediaAnuncios { get; set; }
        public DbSet<AN_Anuncios> AN_Anuncios { get; set; }
        public DbSet<CD_CategoriaServicio> CD_CategoriaServicio { get; set; }
        public DbSet<MB_Membresia> MB_Membresia { get; set; }
        public DbSet<MT_MultimediaTipos> MT_MultimediaTipos { get; set; }
        public DbSet<PA_Paises> PA_Paises { get; set; }
        public DbSet<REG_Region> REG_Region { get; set; }
        public DbSet<RT_TipoReview> RT_TipoReview { get; set; }
        public DbSet<RW_Reviews> RW_Reviews { get; set; }
        public DbSet<SBS_SubCategoriaServicio> SBS_SubCategoriaServicio { get; set; }
        public DbSet<SS_SolicitudServicio> SS_SolicitudServicio { get; set; }
        public DbSet<ST_Estatus> ST_Estatus { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
    }
}
