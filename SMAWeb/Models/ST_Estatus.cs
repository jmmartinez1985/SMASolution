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
            this.FAQs = new HashSet<FAQs>();
            this.SS_SolicitudServicio = new HashSet<SS_SolicitudServicio>();
            this.RW_Reviews = new HashSet<RW_Reviews>();
            this.CR_ComentarioReview = new HashSet<CR_ComentarioReview>();
            this.UserProfile = new HashSet<UserProfile>();
        }
    
        public int ST_Id { get; set; }
        public string ST_Descripcion { get; set; }
    
        public virtual ICollection<AN_Anuncios> AN_Anuncios { get; set; }
        public virtual ICollection<FAQs> FAQs { get; set; }
        public virtual ICollection<SS_SolicitudServicio> SS_SolicitudServicio { get; set; }
        public virtual ICollection<RW_Reviews> RW_Reviews { get; set; }
        public virtual ICollection<CR_ComentarioReview> CR_ComentarioReview { get; set; }
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }
}
