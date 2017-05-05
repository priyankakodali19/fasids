using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.DB;
using WebApplication3.Models.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Text;


namespace WebApplication3.Models.EntityManager
{
    public class ProductManager
    {
        public List<ProductInfo> GetAllProductsInfo()
        {
            List<ProductInfo> products = new List<ProductInfo>();
            using (FASIDSEntities db = new FASIDSEntities())
            {
                ProductInfo PI;
                //var users = db.ProductDatas.ToList();

                foreach (ProductData u in db.ProductDatas)
                {
                    PI = new ProductInfo();
                    PI.ProductId = u.ProductId;
                    PI.ProductName = u.ProductName;
                    PI.ProductManufacturer = u.ProductManufacturer;
                    PI.PhysicalForm = u.PhysicalForm;
                    PI.ProductControlMethod = u.ProductControlMethod;
                    PI.ProductUsage = u.ProductUsage;
                    PI.ProductUrl = u.ProductUrl;
                    PI.ImageUrl = u.ImageUrl;
                    PI.ProductCoverage = u.ProductCoverage;
                    System.Diagnostics.Debug.WriteLine("productpv=" + PI.ProductId);
                    products.Add(PI);
                }
            }
            System.Diagnostics.Debug.WriteLine("productpv=" + products);

            return products;
        }


        public ProductDataView GetProductDataView()
        {
            ProductDataView PDV = new ProductDataView();
            List<ProductInfo> products = GetAllProductsInfo();

            PDV.Products = products;
            System.Diagnostics.Debug.WriteLine("productpdvv=" + PDV.Products);
            return PDV;
        }



       
        //--------------------------------treatment 3-----------------------------------------------------------
        public List<ProductInfo2> GetAllProductsInfo3()
        {
            List<ProductInfo2> products = new List<ProductInfo2>();


            using (FASIDSEntities db = new FASIDSEntities())
            {
                ProductInfo2 PI;

                //var users = db.ProductDatas.ToList();
                var ProductList_new = db.ProductList_new.OrderBy(o => o.ActiveIngredient);
                foreach (ProductList_new u in ProductList_new)
                {
                    PI = new ProductInfo2();
                    PI.TreatmentSites = new List<string>();
                    PI.UrbanTreatmentSites = new List<string>();
                    PI.UrbanTreatmentSitesBroadcast = new List<string>();
                    PI.UrbanTreatmentSitesMound = new List<string>();
                    PI.AgriTreatmentSites = new List<string>();
                    PI.AgriTreatmentSitesBroadcast = new List<string>();
                    PI.AgriTreatmentSitesMound = new List<string>();
                    PI.ProductTreatmentMethod = new List<string>();
                    PI.ProductMeasurementUnit2 = new List<string>();
                    PI.TypeOfLand2 = new List<string>();

                    PI.IsSynthetic = u.IsSynthetic_;
                    PI.ProductUrl = u.MaunfacturerUrl;
                    PI.ProductId = u.ProductId;
                    PI.ActiveIngredient = u.ActiveIngredient;
                    PI.ProductName = u.ProductName;
                    PI.ProductManufacturer = u.Manufacturer_;
                    PI.PhysicalForm = u.PhysicalForm;
                    PI.ProductControlMethod = u.ControlMethod;

                    switch (u.TreatmentMethod)
                    {
                        case "BroadcastMound":
                            PI.ProductTreatmentMethod.Add("Broadcast");
                            PI.ProductTreatmentMethod.Add("Mound");
                            PI.B_ProductMinUseRate = Convert.ToDouble(u.Broadcast_MinUseRate);
                            PI.B_ProductMaxUseRate = Convert.ToDouble(u.Broadcast_MaxUseRate);
                            PI.B_ProductMeasurementUnit = u.Broadcast_MeasurementUnit;
                            PI.M_ProductMinUseRate = Convert.ToDouble(u.Mound_MinUseRate);
                            PI.M_ProductMaxUseRate = Convert.ToDouble(u.Mound_MaxUseRate);
                            PI.M_ProductMeasurementUnit = u.Mound_MeasurementUnit;
                            string temp_x = "Broadcast: " + u.Broadcast_MinUseRate + " - " + u.Broadcast_MaxUseRate + " " + u.Broadcast_MeasurementUnit;
                            string temp_y = "Mound: " + u.Mound_MinUseRate + " - " + u.Mound_MaxUseRate + " " + u.Mound_MeasurementUnit;
                            PI.ProductMeasurementUnit2.Add(temp_x);
                            PI.ProductMeasurementUnit2.Add(temp_y);
                            break;

                        case "Broadcast":
                            PI.ProductTreatmentMethod.Add("Broadcast");
                            PI.B_ProductMinUseRate = Convert.ToDouble(u.Broadcast_MinUseRate);
                            PI.B_ProductMaxUseRate = Convert.ToDouble(u.Broadcast_MaxUseRate);
                            PI.B_ProductMeasurementUnit = u.Broadcast_MeasurementUnit;
                            string temp_z = "Broadcast: " + u.Broadcast_MinUseRate + " - " + u.Broadcast_MaxUseRate + u.Broadcast_MeasurementUnit;
                            PI.ProductMeasurementUnit2.Add(temp_z);
                            break;

                        case "Mound":
                            PI.ProductTreatmentMethod.Add("Mound");
                            PI.M_ProductMinUseRate = Convert.ToDouble(u.Mound_MinUseRate);
                            PI.M_ProductMaxUseRate = Convert.ToDouble(u.Mound_MaxUseRate);
                            PI.M_ProductMeasurementUnit = u.Mound_MeasurementUnit;
                            string y = "Mound: " + u.Mound_MinUseRate + " - " + u.Mound_MaxUseRate + u.Mound_MeasurementUnit;
                            PI.ProductMeasurementUnit2.Add(y);
                            break;
                    }

                    switch (u.LandType)
                    {
                        case "UrbanAgri":
                            PI.TypeOfLand2.Add("Urban");
                            PI.TypeOfLand2.Add("Agricultural");
                            break;

                        case "Urban":
                            PI.TypeOfLand2.Add("Urban");
                            break;

                        case "Agri":
                            PI.TypeOfLand2.Add("Agricultural");
                            break;

                    }

                    var urban_broadcast_codes = db.TreatmentSiteCodes.Where(o => o.TreatmentType == "UrbanBroadcast");
                    var urban_mound_codes = db.TreatmentSiteCodes.Where(o => o.TreatmentType == "UrbanMound");
                    var agri_broadcast_codes = db.TreatmentSiteCodes.Where(o => o.TreatmentType == "AgriBroadcast");
                    var agri_mound_codes = db.TreatmentSiteCodes.Where(o => o.TreatmentType == "AgriMound");

                    char[] urban_broadcast_array = u.UrbanBroadcastSites.ToCharArray();
                    char[] urban_mound_array = u.UrbanMoundSites.ToCharArray();
                    char[] agri_broadcast_array = u.AgriBroadcastSites.ToCharArray();
                    char[] agri_mound_array = u.AgriMoundSites.ToCharArray();

                    for (int i = 0; i < urban_broadcast_array.Count(); i++)
                    {
                       if (urban_broadcast_array[i] == '1')
                        {
                            foreach (TreatmentSiteCode p in urban_broadcast_codes)
                            {
                                int temp = 0;
                                temp = p.Code.IndexOf('1');
                                if (temp == i)
                                {
                                    PI.UrbanTreatmentSitesBroadcast.Add(p.SiteType);
                                    PI.UrbanTreatmentSites.Add(p.SiteType);
                                    break;
                                }                                
                            }
                        }
                    }
                    for (int i = 0; i < urban_mound_array.Count(); i++)
                    {
                        if (urban_mound_array[i] == '1')
                        {
                            foreach (TreatmentSiteCode p in urban_mound_codes)
                            {
                                int temp = 0;
                                temp = p.Code.IndexOf('1');
                                if (temp == i)
                                {
                                    PI.UrbanTreatmentSitesMound.Add(p.SiteType);
                                    PI.UrbanTreatmentSites.Add(p.SiteType);
                                    break;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < agri_broadcast_array.Count(); i++)
                    {
                        if (agri_broadcast_array[i] == '1')
                        {
                            foreach (TreatmentSiteCode p in agri_broadcast_codes)
                            {
                                int temp = 0;
                                temp = p.Code.IndexOf('1');
                                if (temp == i)
                                {
                                    PI.AgriTreatmentSitesBroadcast.Add(p.SiteType);
                                    PI.AgriTreatmentSites.Add(p.SiteType);
                                    break;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < agri_mound_array.Count(); i++)
                    {
                        if (agri_mound_array[i] == '1')
                        {
                            foreach (TreatmentSiteCode p in agri_mound_codes)
                            {
                                int temp = 0;
                                temp = p.Code.IndexOf('1');
                                if (temp == i)
                                {
                                    PI.AgriTreatmentSitesMound.Add(p.SiteType);
                                    PI.AgriTreatmentSites.Add(p.SiteType);
                                    break;
                                }
                            }
                        }
                    }
                    

                    
                    PI.UrbanTreatmentSites2 = new JavaScriptSerializer().Serialize("UrbanTreatmentSites");
                    PI.AgriTreatmentSites2 = new JavaScriptSerializer().Serialize("AgriTreatmentSites");
                    

                    products.Add(PI);
                }
            }
            System.Diagnostics.Debug.WriteLine("productpv=" + products);

            return products;
        }


        public ProductDataView2 GetProductDataView3()
        {
            ProductDataView2 PDV = new ProductDataView2();
            List<ProductInfo2> products = GetAllProductsInfo3();

            PDV.Products = products;
            System.Diagnostics.Debug.WriteLine("productpdvv=" + PDV.Products);
            return PDV;
        }

        public Boolean AddProductDetails3(String ProductDetails)
        {
            try
            {
                using (FASIDSEntities db = new FASIDSEntities())
                {
                    int i = 0;
                    ProductList_new PL = new ProductList_new();
                    dynamic dynObj = JsonConvert.DeserializeObject(ProductDetails);

                    PL.ProductName = dynObj.ProductName;
                    PL.ActiveIngredient = dynObj.ActiveIngredient;
                    PL.Manufacturer_ = dynObj.ProductManufacturer;
                    PL.MaunfacturerUrl = dynObj.ProductUrl;
                    PL.PesticideClassification = dynObj.PesticideClassification;
                    PL.IsSynthetic_ = dynObj.IsSyntheticValue;
                    PL.PhysicalForm = dynObj.PhysicalForm;
                    PL.ControlMethod = dynObj.ProductControlMethod;
                    PL.Broadcast_MinUseRate = 0;
                    PL.Broadcast_MinUseRate = 0;
                    PL.Broadcast_MeasurementUnit = "";
                    PL.Mound_MinUseRate = 0;
                    PL.Mound_MaxUseRate = 0;
                    PL.Mound_MeasurementUnit = "";
                    PL.Note = null;
                    PL.UrbanBroadcastSites = "0000";
                    PL.UrbanMoundSites = "000";
                    PL.AgriBroadcastSites = "0000000";
                    PL.AgriMoundSites = "0000000";



                    if (dynObj.ProductTreatmentMethod.Count==2)
                    {
                        PL.TreatmentMethod = "BroadcastMound";
                        PL.Broadcast_MinUseRate = dynObj.B_ProductMinUseRate;
                        PL.Broadcast_MinUseRate = dynObj.B_ProductMaxUseRate;
                        PL.Broadcast_MeasurementUnit = dynObj.B_ProductMeasurementUnit;
                        PL.Mound_MinUseRate = dynObj.M_ProductMinUseRate;
                        PL.Mound_MaxUseRate = dynObj.M_ProductMaxUseRate;
                        PL.Mound_MeasurementUnit = dynObj.M_ProductMeasurementUnit;
                    }
                    else{
                        if (dynObj.ProductTreatmentMethod[0].value == "broadcast")
                        {
                            PL.TreatmentMethod = "Broadcast";
                            PL.Broadcast_MinUseRate = dynObj.B_ProductMinUseRate;
                            PL.Broadcast_MaxUseRate = dynObj.B_ProductMaxUseRate;
                            PL.Broadcast_MeasurementUnit = dynObj.B_ProductMeasurementUnit;
                        }
                        else if (dynObj.ProductTreatmentMethod[0].value == "imt")
                        {
                            PL.TreatmentMethod = "Mound";
                            PL.Mound_MinUseRate = dynObj.M_ProductMinUseRate;
                            PL.Mound_MaxUseRate = dynObj.M_ProductMaxUseRate;
                            PL.Mound_MeasurementUnit = dynObj.M_ProductMeasurementUnit;
                        }
                    }

                    if (dynObj.TypeOfLand.Count == 2)
                    {
                        PL.LandType = "UrbanAgri";
                    }
                    else
                    {
                        if (dynObj.TypeOfLand[0].value == "urban")
                        {
                            PL.LandType = "Urban";
                        }
                        else if (dynObj.TypeOfLand[0].value == "agricultural")
                        {
                            PL.LandType = "Agri";
                        }
                    }
                    var urban_broadcast_codes = db.TreatmentSiteCodes.Where(o => o.TreatmentType == "UrbanBroadcast");
                    var urban_mound_codes = db.TreatmentSiteCodes.Where(o => o.TreatmentType == "UrbanMound");
                    var agri_broadcast_codes = db.TreatmentSiteCodes.Where(o => o.TreatmentType == "AgriBroadcast");
                    var agri_mound_codes = db.TreatmentSiteCodes.Where(o => o.TreatmentType == "AgriMound");

                    
                    for (int y = 0; y < dynObj.UrbanTreatmentSitesBroadcast.Count; y++)
                    {

                        foreach (TreatmentSiteCode obj in urban_broadcast_codes)
                        {
                            if (dynObj.UrbanTreatmentSitesBroadcast[y].optionText == obj.SiteType)
                            {
                                int temp = 0;
                                temp=obj.Code.IndexOf('1');
                                PL.UrbanBroadcastSites = PL.UrbanBroadcastSites.Remove(temp, 1).Insert(temp, "1") ;
                               
                                break;
                            }
                        }
                    }

                    for (int y = 0; y < dynObj.UrbanTreatmentSitesMound.Count; y++)
                    {
                        foreach (TreatmentSiteCode obj in urban_mound_codes)
                        {
                            if (dynObj.UrbanTreatmentSitesMound[y].optionText == obj.SiteType)
                            {
                                int temp = 0;
                                temp = obj.Code.IndexOf('1');
                                PL.UrbanMoundSites = PL.UrbanMoundSites.Remove(temp, 1).Insert(temp, "1");

                            }
                        }
                    }

                    for (int y = 0; y < dynObj.AgriTreatmentSitesBroadcast.Count; y++)
                    {
                        foreach (TreatmentSiteCode obj in agri_broadcast_codes)
                        {
                            if (dynObj.AgriTreatmentSitesBroadcast[y].optionText == obj.SiteType)
                            {
                                int temp = 0;
                                temp = obj.Code.IndexOf('1');
                                PL.AgriBroadcastSites = PL.AgriBroadcastSites.Remove(temp, 1).Insert(temp, "1"); 
                              
                            }
                        }
                    }

                    for (int y = 0; y < dynObj.AgriTreatmentSitesMound.Count; y++)
                    {
                        foreach (TreatmentSiteCode obj in agri_mound_codes)
                        {
                        if (dynObj.AgriTreatmentSitesMound[y].optionText == obj.SiteType)
                        {
                            int temp = 0;
                            temp = obj.Code.IndexOf('1');
                            PL.AgriMoundSites = PL.AgriMoundSites.Remove(temp, 1).Insert(temp, "1");
                         }
                    }
                }


                    db.ProductList_new.Add(PL);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;

            }

        }

        public Boolean EditProductDetails3(string product_details)
        {
            Boolean x = false;
            using (FASIDSEntities db = new FASIDSEntities())
            {
                dynamic dynObj = JsonConvert.DeserializeObject(product_details);
                int product_id = dynObj.ProductId;
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var product = db.ProductList_new.Where(o => o.ProductId == product_id);
                        if (product.Any())
                        {
                            db.ProductList_new.Remove(product.FirstOrDefault());
                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                        x = AddProductDetails3(product_details);
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return x;
        }

        public void DeleteProduct3(int ProductId)
        {
            using (FASIDSEntities db = new FASIDSEntities())
            {

                int product_id = ProductId;
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var product = db.ProductList_new.Where(o => o.ProductId == product_id);
                        if (product.Any())
                        {
                            db.ProductList_new.Remove(product.FirstOrDefault());
                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();

                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}