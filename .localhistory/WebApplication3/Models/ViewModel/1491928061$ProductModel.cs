using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.ViewModel
{
    public class ProductInfo
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductManufacturer { get; set; }
        public string PhysicalForm { get; set; }
        public string ProductControlMethod { get; set; }
        public string ProductUsage { get; set; }
        public string ProductCoverage { get; set; }
        public string ProductUrl { get; set; }
        public string ImageUrl { get; set; }
    }

    public class ProductDataView
    {
        public IEnumerable<ProductInfo> Products { get; set; }
    }

    //-----------------------treatment2--------------------------------------

    public class ProductInfo2
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductManufacturer { get; set; }
        public string PhysicalForm { get; set; }
        public string ProductControlMethod { get; set; }
        public List<string> ProductTreatmentMethod { get; set; }
        public string ActiveIngredient { get; set; }
        public double ProductMinUseRate { get; set; }
        public double ProductMaxUseRate { get; set; }
        public string ProductMeasurementUnit { get; set; }
        public double B_ProductMinUseRate { get; set; }
        public double B_ProductMaxUseRate { get; set; }
        public string B_ProductMeasurementUnit { get; set; }
        public double M_ProductMinUseRate { get; set; }
        public double M_ProductMaxUseRate { get; set; }
        public string M_ProductMeasurementUnit { get; set; }
        public List<string> ProductMeasurementUnit2 { get; set; }
        public string ProductUrl { get; set; }
        public string IsSynthetic { get; set; }
        public List<string> TreatmentSites { get; set; }
        public List<string> UrbanTreatmentSites { get; set; }
        public List<string> UrbanTreatmentSitesBroadcast { get; set; }
        public List<string> UrbanTreatmentSitesMound { get; set; }
        public string UrbanTreatmentSites2 { get; set; }
        public List<string> AgriTreatmentSites { get; set; }
        public List<string> AgriTreatmentSitesBroadcast { get; set; }
        public List<string> AgriTreatmentSitesMound { get; set; }
        public string AgriTreatmentSites2 { get; set; }
        public List<string> TypeOfLand2 { get; set; }
        public string TypeOfLand { get; set; }
    }

    public class ProductDataView2
    {
        public IEnumerable<ProductInfo2> Products { get; set; }
    }


    public class AddProducts
    {
        public string ProductName {get; set;}
        public string ActiveIngredient { get; set; }
        public string Manufacturer { get; set; }
        public string PhysicalForm { get; set; }
        public string PesticideClassification { get; set; }
        public Boolean IsSynthetic { get; set; }
        public string ProductControlMethod { get; set; }
        public string TreatmentMethod { get; set; }
        public double ProductMinUseRate { get; set; }
        public double ProductMaxUseRate { get; set; }
        public string ProductMeasurementUnit { get; set; }
        public string ProductUrl { get; set; }
        public string Amount { get; set; }
        public int MoundNumber { get; set; }
        public string TypeOfAgri { get; set; }
        public string TypeOfUrban { get; set; }
        public string TypeOfLand { get; set; }
        public string Notes { get; set; }

    }
}