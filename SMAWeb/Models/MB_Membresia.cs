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
    
    public partial class MB_Membresia
    {
        public MB_Membresia()
        {
            this.UserProfiles = new HashSet<UserProfile>();
        }
    
        public int MP_MemberShipId { get; set; }
        public string MP_Descripcion { get; set; }
        public Nullable<int> MP_ExpiracionDays { get; set; }
    
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}