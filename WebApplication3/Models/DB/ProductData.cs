//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductData
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductManufacturer { get; set; }
        public string PhysicalForm { get; set; }
        public bool IsOutDoor { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsSafeForPets { get; set; }
        public string ProductControlMethod { get; set; }
        public string ProductUsage { get; set; }
        public string ProductCoverage { get; set; }
        public string ProductUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
