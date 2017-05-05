using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace WebApplication3.Models.ViewModel
{
    public class SaveUserPolygon
    {
        public int UserId { get; set; }
        public string GeoJsonId { get; set; }
        public string Type { get; set; }
        public string GeometryType { get; set; }
        public string PolygonName { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public double TotalArea { get; set; }
        public decimal MoundDensity { get; set; }
        public int MoundNumber { get; set; }
        public string TypeOfUse { get; set; }
        public string ControlMethod { get; set; }
        public string Usage { get; set; }
        public Boolean IsOutdoor { get; set; }
        public Boolean NeedOrganic { get; set; }
        public Boolean NeedSafeForPets { get; set; }
        public string EnvMapTypeId { get; set; }
        public int EnvMapTilt { get; set; }
        public double Bounds_SW_Lat { get; set; }
        public double Bounds_SW_Lng { get; set; }
        public double Bounds_NE_Lat { get; set; }
        public double Bounds_NE_Lng { get; set; }
        public DbGeometry Coordinates { get; set; }
    }

    public class DisplayUserPolygon
    {
        
        public int UserId { get; set; }
        public string GeoJsonId { get; set; }
        public string Type { get; set; }
        public string GeometryType { get; set; }
        public string PolygonName { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public double TotalArea { get; set; }
        public decimal MoundDensity { get; set; }
        public int MoundNumber { get; set; }
        public string TypeOfUse { get; set; }
        public string ControlMethod { get; set; }
        public string Usage { get; set; }
        public Boolean IsOutdoor { get; set; }
        public Boolean NeedOrganic { get; set; }
        public Boolean NeedSafeForPets { get; set; }
        public string EnvMapTypeId { get; set; }
        public int EnvMapTilt { get; set; }
        public double Bounds_SW_Lat { get; set; }
        public double Bounds_SW_Lng { get; set; }
        public double Bounds_NE_Lat { get; set; }
        public double Bounds_NE_Lng { get; set; }
        public DbGeometry Coordinates { get; set; }
        public String coordinates_str { get; set; }
    }

    public class ProductTreatmentInfo
    {
        public string GeoJsonId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductManufacturer { get; set; }
        public string PhysicalForm { get; set; }
        public string ProductControlMethod { get; set; }
        public string ProductUsage { get; set; }
        public string ProductCoverage { get; set; }
        public string ProductUrl { get; set; }
        public string ImageUrl { get; set; }
        public Array TypeOfUses { get; set; }
        public Boolean IsOutdoor { get; set; }
        public Boolean NeedOrganic { get; set; }
        public Boolean NeedSafeForPets { get; set; }
        public double Amount { get; set; }
        public int MoundNumber { get; set; }
    }

    public class ProductTreatmentDataView
    {
        public IEnumerable<ProductTreatmentInfo> Products { get; set; }
        
    }


    //-----------------treatment 2------------------------------
    public class SaveUserPolygon2
    {
        public int UserId { get; set; }
        public string GeoJsonId { get; set; }
        public string Type { get; set; }
        public string GeometryType { get; set; }
        public string PolygonName { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public double TotalArea { get; set; }
        public double MoundDensity { get; set; }
        public int MoundNumber { get; set; }
        public string TypeOfLand { get; set; }
        public string TypeOfUrban { get; set; }
        public string TypeOfAgri { get; set; }
        public string TypeOfTreatment { get; set; }
        public string TypeOfControlMethod { get; set; }
        public string EnvMapTypeId { get; set; }
        public int EnvMapTilt { get; set; }
        public double Bounds_SW_Lat { get; set; }
        public double Bounds_SW_Lng { get; set; }
        public double Bounds_NE_Lat { get; set; }
        public double Bounds_NE_Lng { get; set; }
        public DbGeometry Coordinates { get; set; }
    }

    public class DisplayUserPolygon2
    {

        public int UserId { get; set; }
        public string GeoJsonId { get; set; }
        public string Type { get; set; }
        public string GeometryType { get; set; }
        public string PolygonName { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public double TotalArea { get; set; }
        public double MoundDensity { get; set; }
        public int MoundNumber { get; set; }
        public string TypeOfLand { get; set; }
        public string TypeOfUrban { get; set; }
        public string TypeOfAgri { get; set; }
        public string TypeOfTreatment { get; set; }
        public string TypeOfControlMethod { get; set; }
        public string EnvMapTypeId { get; set; }
        public int EnvMapTilt { get; set; }
        public double Bounds_SW_Lat { get; set; }
        public double Bounds_SW_Lng { get; set; }
        public double Bounds_NE_Lat { get; set; }
        public double Bounds_NE_Lng { get; set; }
        public DbGeometry Coordinates { get; set; }
        public String coordinates_str { get; set; }
    }

    public class ProductTreatmentInfo2
    {
        public string GeoJsonId { get; set; }
        public int ProductId { get; set; }
        public string ActiveIngredient { get; set; }
        public string ProductName { get; set; }
        public string ProductManufacturer { get; set; }
        public string PhysicalForm { get; set; }
        public string PesticideClassification { get; set; }
        public Boolean IsSynthetic { get; set; }
        public string ProductControlMethod { get; set; }
        public string ProductTreatmentMethod { get; set; }
        public double ProductMinUseRate { get; set; }
        public double ProductMaxUseRate { get; set; }
        public string ProductMeasurementUnit { get; set; }
        public string ProductUrl { get; set; }
        public string Amount { get; set; }
        public int MoundNumber { get; set; }
        public string TypeOfAgri { get; set; }
        public string TypeOfUrban { get; set; }
    }

    public class ProductTreatmentDataView2
    {
        public IEnumerable<ProductTreatmentInfo2> Products { get; set; }

    }
    
}