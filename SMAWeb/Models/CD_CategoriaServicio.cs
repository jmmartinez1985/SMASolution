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
    
    public partial class CD_CategoriaServicio
    {
        public CD_CategoriaServicio()
        {
            this.SBS_SubCategoriaServicio = new HashSet<SBS_SubCategoriaServicio>();
            this.AN_Anuncios = new HashSet<AN_Anuncios>();
        }
    
        public int CD_Id { get; set; }
        public string CD_Descripcion { get; set; }
    
        public virtual ICollection<SBS_SubCategoriaServicio> SBS_SubCategoriaServicio { get; set; }
        public virtual ICollection<AN_Anuncios> AN_Anuncios { get; set; }
    }
}
