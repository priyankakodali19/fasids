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
    
    public partial class PolygonGeoJson
    {
        public int UserId { get; set; }
        public string Type { get; set; }
        public string GeometryType { get; set; }
        public string PolygonName { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public decimal TotalArea { get; set; }
        public Nullable<decimal> MoundDensity { get; set; }
        public Nullable<int> MoundNumber { get; set; }
        public string TypeOfUse { get; set; }
        public string ControlMethod { get; set; }
        public string Usage { get; set; }
        public Nullable<bool> IsOutdoor { get; set; }
        public Nullable<bool> NeedOrganic { get; set; }
        public Nullable<bool> NeedSafeForPets { get; set; }
        public string EnvMapTypeId { get; set; }
        public int EnvMapTilt { get; set; }
        public decimal Bounds_SW_Lat { get; set; }
        public decimal Bounds_SW_Lng { get; set; }
        public decimal Bounds_NE_Lat { get; set; }
        public decimal Bounds_NE_Lng { get; set; }
        public string GeoJsonId { get; set; }
        public System.Data.Spatial.DbGeometry Coordinates { get; set; }
    
        public virtual UserData UserData { get; set; }
    }
}
