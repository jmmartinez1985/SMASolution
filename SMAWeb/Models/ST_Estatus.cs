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
    
    public partial class ST_Estatus
    {
        public ST_Estatus()
        {
            this.AN_Anuncios = new HashSet<AN_Anuncios>();
            this.SS_SolicitudServicio = new HashSet<SS_SolicitudServicio>();
            this.UserProfiles = new HashSet<UserProfile>();
        }
    
        public int ST_Id { get; set; }
        public string ST_Descripcion { get; set; }
    
        public virtual ICollection<AN_Anuncios> AN_Anuncios { get; set; }
        public virtual ICollection<SS_SolicitudServicio> SS_SolicitudServicio { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
