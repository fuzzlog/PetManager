//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Animal
    {
        public int AnimalsID { get; set; }
        public string Moniker { get; set; }
        public Nullable<int> PetId { get; set; }
        public string City { get; set; }
        public Nullable<System.DateTime> Located { get; set; }
        public int AnimalStatusID { get; set; }
    }
}
