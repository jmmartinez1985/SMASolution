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
    
    public partial class MC_MembresiaControl
    {
        public int MC_Id { get; set; }
        public int MC_MembershipId { get; set; }
        public int MC_UserId { get; set; }
        public System.DateTime MC_Caducidad { get; set; }
    
        public virtual MB_Membresia MB_Membresia { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
