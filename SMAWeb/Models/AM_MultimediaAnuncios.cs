//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class AM_MultimediaAnuncios
    {
        public int AM_Id { get; set; }
        public int AN_Id { get; set; }
        public string AM_Titulo { get; set; }
        public string AM_MultimediaUrl { get; set; }
        public int MT_Id { get; set; }
    
        public virtual MT_MultimediaTipos MT_MultimediaTipos { get; set; }
        public virtual AN_Anuncios AN_Anuncios { get; set; }
    }
}
