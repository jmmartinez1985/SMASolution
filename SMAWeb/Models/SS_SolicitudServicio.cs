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
    
    public partial class SS_SolicitudServicio
    {
        public SS_SolicitudServicio()
        {
            this.RW_Reviews = new HashSet<RW_Reviews>();
        }
    
        public int SS_Id { get; set; }
        public int AN_Id { get; set; }
        public System.DateTime SS_Fecha { get; set; }
        public string SS_Nombre { get; set; }
        public string SS_Mail { get; set; }
        public string SS_Telefono { get; set; }
        public string SS_Celular { get; set; }
        public string SS_Descripcion { get; set; }
        public int ST_Id { get; set; }
    
        public virtual AN_Anuncios AN_Anuncios { get; set; }
        public virtual ICollection<RW_Reviews> RW_Reviews { get; set; }
        public virtual ST_Estatus ST_Estatus { get; set; }
    }
}
