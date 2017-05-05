using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.DB;
using WebApplication3.Models.ViewModel;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
namespace WebApplication3.Models.EntityManager
{
    public class ProductManager
    {
        public List<ProductInfo> GetAllProductsInfo()
        {
            List<ProductInfo> products = new List<ProductInfo>();
            using (FASIDSEntities4 db = new FASIDSEntities4())
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



        //---------------------------------------treatment2------------------------------
        public List<ProductInfo2> GetAllProductsInfo2()
        {
            List<ProductInfo2> products = new List<ProductInfo2>();
            

            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                ProductInfo2 PI;
                
                //var users = db.ProductDatas.ToList();

                foreach (Product_list u in db.Product_list)
                {
                    PI = new ProductInfo2();
                    PI.TreatmentSites = new List<string>();
                    PI.UrbanTreatmentSites = new List<string>();
                    PI.AgriTreatmentSites = new List<string>();
                    PI.ProductTreatmentMethod = new List<string>();
                    PI.ProductMeasurementUnit2 = new List<string>();
                    PI.TypeOfLand2 = new List<string>();

                    PI.ProductId = u.ProductId;
                    PI.ActiveIngredient = u.ActiveIngredient;
                    PI.ProductName = u.ProductName;
                    PI.ProductManufacturer = u.Manufacturer_;
                    PI.PhysicalForm = u.PhysicalForm;
                    PI.ProductControlMethod = u.ControlMethod;
                    if (u.IsBroadcast == true && u.IsMound == true)
                    {
                        PI.ProductTreatmentMethod.Add("Broadcast");
                        PI.ProductTreatmentMethod.Add("Mound");
                        PI.B_ProductMinUseRate = Convert.ToDouble(u.Broadcast_MinUseRate);
                        PI.B_ProductMaxUseRate=Convert.ToDouble(u.Broadcast_MaxUseRate);
                        PI.B_ProductMeasurementUnit = u.Broadcast_MeasurementUnit;
                        PI.M_ProductMinUseRate = Convert.ToDouble(u.Mound_MinUseRate);
                        PI.M_ProductMaxUseRate = Convert.ToDouble(u.Mound_MaxUseRate);
                        PI.M_ProductMeasurementUnit = u.Mound_MeasurementUnit;
                        string x = "Broadcast: " + u.Broadcast_MinUseRate + " - " + u.Broadcast_MaxUseRate + " "+u.Broadcast_MeasurementUnit;
                        string y = "Mound: " + u.Mound_MinUseRate + " - " + u.Mound_MaxUseRate + " "+ u.Mound_MeasurementUnit;
                        PI.ProductMeasurementUnit2.Add(x);
                        PI.ProductMeasurementUnit2.Add(y);

                    }
                    else
                    {
                        if (u.IsBroadcast == true)
                        {
                            PI.ProductTreatmentMethod.Add("Broadcast");
                            //PI.ProductMinUseRate = Convert.ToDouble(u.Broadcast_MinUseRate);
                            //PI.ProductMaxUseRate = Convert.ToDouble(u.Broadcast_MaxUseRate);
                            //PI.ProductMeasurementUnit = u.Broadcast_MeasurementUnit;
                            PI.B_ProductMinUseRate = Convert.ToDouble(u.Broadcast_MinUseRate);
                            PI.B_ProductMaxUseRate = Convert.ToDouble(u.Broadcast_MaxUseRate);
                            PI.B_ProductMeasurementUnit = u.Broadcast_MeasurementUnit;
                            string x =  u.Broadcast_MinUseRate + " - " + u.Broadcast_MaxUseRate + u.Broadcast_MeasurementUnit;
                            PI.ProductMeasurementUnit2.Add(x);
                        }
                        else 
                        {
                            PI.ProductTreatmentMethod.Add("Mound");
                            PI.M_ProductMinUseRate = Convert.ToDouble(u.Mound_MinUseRate);
                            PI.M_ProductMaxUseRate = Convert.ToDouble(u.Mound_MaxUseRate);
                            PI.M_ProductMeasurementUnit = u.Mound_MeasurementUnit;
                            //PI.ProductMinUseRate = Convert.ToDouble(u.Mound_MinUseRate);
                            //PI.ProductMaxUseRate = Convert.ToDouble(u.Mound_MaxUseRate);
                            //PI.ProductMeasurementUnit = u.Mound_MeasurementUnit;
                            string y =  u.Mound_MinUseRate + " - " + u.Mound_MaxUseRate + u.Mound_MeasurementUnit;
                            PI.ProductMeasurementUnit2.Add(y);

                        }
                    }
                    
                    PI.ProductUrl = u.MaunfacturerUrl;
                    if (u.IsUrbanLand == true && u.IsAgricultureLand == true)
                    {
                        PI.TypeOfLand2.Add("Urban");
                        PI.TypeOfLand2.Add("Agricultural");

                    }
                    else
                    {
                        if (u.IsUrbanLand == true)
                        {
                            PI.TypeOfLand="Urban";
                        }
                        else
                        {
                            PI.TypeOfLand="Agricultural";
                        }
                    }

                    if (PI.TypeOfLand2.Count == 2)
                    {
                        if (u.IsUrbanHome_Broadcast == true || u.IsUrbanHome_Mound == true)
                        {
                            PI.TreatmentSites.Add("Home Lawns / Ornamentals");
                            PI.UrbanTreatmentSites.Add("Home Lawns / Ornamentals");

                        }
                        if (u.IsUrbanPerimeter_P == true)
                        {
                            PI.TreatmentSites.Add("Perimeter");
                            PI.UrbanTreatmentSites.Add("Perimeter");
                        }
                        if (u.IsUrbanRecArea_Broadcast == true || u.IsUrbanRecArea_Mound == true)
                        {
                            PI.TreatmentSites.Add("Recreational Areas");
                            PI.UrbanTreatmentSites.Add("Recreational Areas");
                        }
                        if (u.IsUrbanRightOfWay_Broadcast == true || u.IsUrbanRightOfWay_Mound == true)
                        {
                            PI.TreatmentSites.Add("Right of Way");
                            PI.UrbanTreatmentSites.Add("Right of Way");
                        }
                        if (u.IsAgriPasture_Broadcast == true || u.IsAgriPasture_Mound == true)
                        {
                            PI.TreatmentSites.Add("Pasture Land");
                            PI.AgriTreatmentSites.Add("Pasture Land");
                        }
                        if (u.IsAgriPoultry_Broadcast == true || u.IsAgriPoultry_Mound == true)
                        {
                            PI.TreatmentSites.Add("Poultry Houses");
                            PI.AgriTreatmentSites.Add("Poultry Houses");
                        }
                        if (u.IsAgriCropAreas_Broadcast == true || u.IsAgriCropAreas_Mound == true)
                        {
                            PI.TreatmentSites.Add("Crop Areas");
                            PI.AgriTreatmentSites.Add("Crop Areas");
                        }
                        if (u.IsAgriSod_Broadcast == true || u.IsAgriSod_Mound == true)
                        {
                            PI.TreatmentSites.Add("Sod / Turf");
                            PI.AgriTreatmentSites.Add("Sod / Turf");
                        }
                        if (u.IsAgriOthers_Broadcast == true || u.IsAgriOthers_Mound == true)
                        {
                            PI.TreatmentSites.Add("Other ( Fences / Rows / Ditches / Out Buildings)");
                            PI.AgriTreatmentSites.Add("Other ( Fences / Rows / Ditches / Out Buildings)");
                        }

                        if (u.IsAgriNurseryContainer_Broadcast == true || u.IsAgriNurseryContainer_Mound == true)
                        {
                            PI.TreatmentSites.Add("Nursery Container");
                            PI.AgriTreatmentSites.Add("Nursery Container");
                        }
                        if (u.IsAgriNurseryBB_Broadcast == true || u.IsAgriNurseryBB_Mound == true)
                        {
                            PI.TreatmentSites.Add("Nursery B & B (Ball & Burlap) ");
                            PI.AgriTreatmentSites.Add("Nursery B & B (Ball & Burlap) ");
                        }
                    }
                    else
                    {
                        if (PI.TypeOfLand == "Urban")
                        {
                            if (u.IsUrbanHome_Broadcast == true || u.IsUrbanHome_Mound == true)
                            {
                                PI.TreatmentSites.Add("Home Lawns / Ornamentals");
                                PI.UrbanTreatmentSites.Add("Home Lawns / Ornamentals");

                            }
                            if (u.IsUrbanPerimeter_P == true)
                            {
                                PI.TreatmentSites.Add("Perimeter");
                                PI.UrbanTreatmentSites.Add("Perimeter");
                            }
                            if (u.IsUrbanRecArea_Broadcast == true || u.IsUrbanRecArea_Mound == true)
                            {
                                PI.TreatmentSites.Add("Recreational Areas");
                                PI.UrbanTreatmentSites.Add("Recreational Areas");
                            }
                            if (u.IsUrbanRightOfWay_Broadcast == true || u.IsUrbanRightOfWay_Mound == true)
                            {
                                PI.TreatmentSites.Add("Right of Way");
                                PI.UrbanTreatmentSites.Add("Right of Way");
                            }
                        }
                        else
                        {
                            if (u.IsAgriPasture_Broadcast == true || u.IsAgriPasture_Mound == true)
                            {
                                PI.TreatmentSites.Add("Pasture Land");
                                PI.AgriTreatmentSites.Add("Pasture Land");
                            }
                            if (u.IsAgriPoultry_Broadcast == true || u.IsAgriPoultry_Mound == true)
                            {
                                PI.TreatmentSites.Add("Poultry Houses");
                                PI.AgriTreatmentSites.Add("Poultry Houses");
                            }
                            if (u.IsAgriCropAreas_Broadcast == true || u.IsAgriCropAreas_Mound == true)
                            {
                                PI.TreatmentSites.Add("Crop Areas");
                                PI.AgriTreatmentSites.Add("Crop Areas");
                            }
                            if (u.IsAgriSod_Broadcast == true || u.IsAgriSod_Mound == true)
                            {
                                PI.TreatmentSites.Add("Sod / Turf");
                                PI.AgriTreatmentSites.Add("Sod / Turf");
                            }
                            if (u.IsAgriOthers_Broadcast == true || u.IsAgriOthers_Mound == true)
                            {
                                PI.TreatmentSites.Add("Other ( Fences / Rows / Ditches / Out Buildings)");
                                PI.AgriTreatmentSites.Add("Other ( Fences / Rows / Ditches / Out Buildings)");
                            }

                            if (u.IsAgriNurseryContainer_Broadcast == true || u.IsAgriNurseryContainer_Mound == true)
                            {
                                PI.TreatmentSites.Add("Nursery Container");
                                PI.AgriTreatmentSites.Add("Nursery Container");
                            }
                            if (u.IsAgriNurseryBB_Broadcast == true || u.IsAgriNurseryBB_Mound == true)
                            {
                                PI.TreatmentSites.Add("Nursery B & B (Ball & Burlap) ");
                                PI.AgriTreatmentSites.Add("Nursery B & B (Ball & Burlap) ");
                            }
                        }
                    }

                    PI.UrbanTreatmentSites2 = new JavaScriptSerializer().Serialize("UrbanTreatmentSites");
                    PI.AgriTreatmentSites2 = new JavaScriptSerializer().Serialize("AgriTreatmentSites");
                    if (u.IsSynthetic_ == true)
                    {
                        PI.IsSynthetic = "Synthetic";
                    }
                    else
                    {
                        PI.IsSynthetic = "Natural";
                    }
                    
                    products.Add(PI);
                }
            }
            System.Diagnostics.Debug.WriteLine("productpv=" + products);

            return products;
        }


        public ProductDataView2 GetProductDataView2()
        {
            ProductDataView2 PDV = new ProductDataView2();
            List<ProductInfo2> products = GetAllProductsInfo2();

            PDV.Products = products;
            System.Diagnostics.Debug.WriteLine("productpdvv=" + PDV.Products);
            return PDV;
        }

        public Boolean AddProductDetails(String ProductDetails)
        {
            try
            {
                using (FASIDSEntities4 db = new FASIDSEntities4())
                {
                    int i = 0;
                    Product_list PL = new Product_list();
                    dynamic dynObj = JsonConvert.DeserializeObject(ProductDetails);
                    
                    PL.ProductName = dynObj.ProductName;
                    PL.ActiveIngredient = dynObj.ActiveIngredient;
                    PL.Manufacturer_ = dynObj.ProductManufacturer;
                    PL.MaunfacturerUrl = dynObj.ProductUrl;
                    PL.PesticideClassification = dynObj.PesticideClassification;
                    PL.IsSynthetic_ = dynObj.IsSyntheticValue;
                    PL.PhysicalForm = dynObj.PhysicalForm;
                    PL.ControlMethod = dynObj.ProductControlMethod;
                    PL.IsBroadcast = false;
                    PL.IsMound = false;
                    PL.Broadcast_MinUseRate = 0;
                    PL.Broadcast_MinUseRate = 0;
                    PL.Broadcast_MeasurementUnit = "" ;
                    PL.Mound_MinUseRate = 0;
                    PL.Mound_MaxUseRate = 0;
                    PL.Mound_MeasurementUnit ="";
                    PL.IsUrbanLand = false;
                    PL.IsUrbanHome_Broadcast = false;
                    PL.IsUrbanHome_Mound = false;
                    PL.IsUrbanPerimeter_P = false;
                    PL.IsUrbanRecArea_Broadcast = false;
                    PL.IsUrbanRecArea_Mound = false;
                    PL.IsUrbanRightOfWay_Broadcast = false;
                    PL.IsUrbanRightOfWay_Mound = false;
                    PL.IsAgricultureLand = false;
                    PL.IsAgriNurseryBB_Broadcast = false;
                    PL.IsAgriNurseryBB_Mound = false;
                    PL.IsAgriNurseryContainer_Broadcast = false;
                    PL.IsAgriNurseryContainer_Mound = false;
                    PL.IsAgriOthers_Broadcast = false;
                    PL.IsAgriOthers_Mound = false;
                    PL.IsAgriPasture_Broadcast = false;
                    PL.IsAgriPasture_Mound = false;
                    PL.IsAgriPoultry_Broadcast = false;
                    PL.IsAgriPoultry_Mound = false;
                    PL.IsAgriSod_Broadcast = false;
                    PL.IsAgriSod_Mound = false;
                    PL.IsAgriCropAreas_Broadcast = false;
                    PL.IsAgriCropAreas_Mound = false;
                    PL.IsAgri_FoodProducing = false;
                    PL.IsAgri_NonFoodProducing = false;
                    PL.AgriFoodProducingSites = null;
                    PL.AgriNonFoodProducingSites = null;
                    PL.Note = null;

                    if (dynObj.ProductTreatmentMethod.Count == 2)
                    {
                        PL.IsBroadcast = true;
                        PL.IsMound = true;
                        PL.Broadcast_MinUseRate = dynObj.B_ProductMinUseRate;
                        PL.Broadcast_MinUseRate = dynObj.B_ProductMaxUseRate;
                        PL.Broadcast_MeasurementUnit = dynObj.B_ProductMeasurementUnit;
                        PL.Mound_MinUseRate = dynObj.M_ProductMinUseRate;
                        PL.Mound_MaxUseRate = dynObj.M_ProductMaxUseRate;
                        PL.Mound_MeasurementUnit = dynObj.M_ProductMeasurementUnit;
                    }
                    else
                    {
                        if (dynObj.ProductTreatmentMethod[0].value == "broadcast")
                        {
                            PL.IsBroadcast = true;
                            PL.Broadcast_MinUseRate = dynObj.B_ProductMinUseRate;
                            PL.Broadcast_MaxUseRate = dynObj.B_ProductMaxUseRate;
                            PL.Broadcast_MeasurementUnit = dynObj.B_ProductMeasurementUnit;
                        }
                        else
                        {
                            PL.IsMound = true;
                            PL.Mound_MinUseRate = dynObj.M_ProductMinUseRate;
                            PL.Mound_MaxUseRate = dynObj.M_ProductMaxUseRate;
                            PL.Mound_MeasurementUnit = dynObj.M_ProductMeasurementUnit;
                        }
                    }

                    if (dynObj.TypeOfLand.Count == 2)
                    {
                        PL.IsUrbanLand = true;
                        PL.IsAgricultureLand = true;
                        
                        if (dynObj.ProductTreatmentMethod[0].value == "broadcast")
                        {
                            for (i = 0; i < dynObj.UrbanTreatmentSites.Count; i++)
                            {
                                if (dynObj.UrbanTreatmentSites[i].value == "home_lawns")
                                {
                                    PL.IsUrbanHome_Broadcast = true;
                                }
                                else if (dynObj.UrbanTreatmentSites[i].value == "perimeter")
                                {
                                    PL.IsUrbanPerimeter_P = true;
                                }
                                else if (dynObj.UrbanTreatmentSites[i].value == "rec")
                                {
                                    PL.IsUrbanRecArea_Broadcast = true;
                                }
                                else if (dynObj.UrbanTreatmentSites[i].value == "right_of_way")
                                {
                                    PL.IsUrbanRightOfWay_Broadcast = true;
                                }
                             }

                            for (i = 0; i < dynObj.AgriTreatmentSites.Count; i++)
                            {
                                if (dynObj.AgriTreatmentSites[i].value == "pasture")
                                {
                                    PL.IsAgriPasture_Broadcast = true;
                                }
                                else if (dynObj.AgriTreatmentSites[i].value == "poultry")
                                {
                                    PL.IsAgriPoultry_Broadcast = true;
                                }
                                else if (dynObj.AgriTreatmentSites[i].value == "crop")
                                {
                                    PL.IsAgriCropAreas_Broadcast = true;
                                }
                                else if (dynObj.AgriTreatmentSites[i].value == "sod")
                                {
                                    PL.IsAgriSod_Broadcast = true;
                                }
                                else if (dynObj.AgriTreatmentSites[i].value == "nursery_container")
                                {
                                    PL.IsAgriNurseryContainer_Broadcast = true;
                                }
                                else if (dynObj.AgriTreatmentSites[i].value == "nursery_bb")
                                {
                                    PL.IsAgriNurseryBB_Broadcast = true;
                                }
                                else if (dynObj.AgriTreatmentSites[i].value == "other")
                                {
                                    PL.IsAgriOthers_Broadcast = true;
                                }
                            }
                        }
                        else
                        {
                            if (dynObj.ProductTreatmentMethod[0].value == "mound")
                            {
                                for (i = 0; i < dynObj.UrbanTreatmentSites.Count; i++)
                                {
                                    if (dynObj.UrbanTreatmentSites[i].value == "home_lawns")
                                    {
                                        PL.IsUrbanHome_Mound = true;
                                    }
                                    
                                    else if (dynObj.UrbanTreatmentSites[i].value == "rec")
                                    {
                                        PL.IsUrbanRecArea_Mound = true;
                                    }
                                    else if (dynObj.UrbanTreatmentSites[i].value == "right_of_way")
                                    {
                                        PL.IsUrbanRightOfWay_Mound = true;
                                    }
                                 }

                                for (i = 0; i < dynObj.AgriTreatmentSites.Count; i++)
                                {
                                    if (dynObj.AgriTreatmentSites[i].value == "pasture")
                                    {
                                        PL.IsAgriPasture_Mound = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "poultry")
                                    {
                                        PL.IsAgriPoultry_Mound = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "crop")
                                    {
                                        PL.IsAgriCropAreas_Mound = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "sod")
                                    {
                                        PL.IsAgriSod_Mound = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "nursery_container")
                                    {
                                        PL.IsAgriNurseryContainer_Mound = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "nursery_bb")
                                    {
                                        PL.IsAgriNurseryBB_Mound = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "other")
                                    {
                                        PL.IsAgriOthers_Mound = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dynObj.TypeOfLand[0].value == "urban")
                        {
                            PL.IsUrbanLand = true;
                            if (dynObj.ProductTreatmentMethod[0].value == "mound")
                            {
                                for (i = 0; i < dynObj.UrbanTreatmentSites.Count; i++)
                                {
                                    if (dynObj.UrbanTreatmentSites[i].value == "home_lawns")
                                    {
                                        PL.IsUrbanHome_Mound = true;
                                    }

                                    else if (dynObj.UrbanTreatmentSites[i].value == "rec")
                                    {
                                        PL.IsUrbanRecArea_Mound = true;
                                    }
                                    else if (dynObj.UrbanTreatmentSites[i].value == "right_of_way")
                                    {
                                        PL.IsUrbanRightOfWay_Mound = true;
                                    }
                                }
                            }
                            
                            else
                            {
                                for (i = 0; i < dynObj.UrbanTreatmentSites.Count; i++)
                                {
                                    if (dynObj.UrbanTreatmentSites[i].value == "home_lawns")
                                    {
                                        PL.IsUrbanHome_Broadcast = true;
                                    }
                                    else if (dynObj.UrbanTreatmentSites[i].value == "perimeter")
                                    {
                                        PL.IsUrbanPerimeter_P = true;
                                    }
                                    else if (dynObj.UrbanTreatmentSites[i].value == "rec")
                                    {
                                        PL.IsUrbanRecArea_Broadcast = true;
                                    }
                                    else if (dynObj.UrbanTreatmentSites[i].value == "right_of_way")
                                    {
                                        PL.IsUrbanRightOfWay_Broadcast = true;
                                    }
                                }

                            }

                        }
                        else
                        {
                            PL.IsAgricultureLand = true;
                            if (dynObj.ProductTreatmentMethod[0].value == "mound")
                            {
                                for (i = 0; i < dynObj.AgriTreatmentSites.Count; i++)
                                {
                                    if (dynObj.AgriTreatmentSites[i].value == "pasture")
                                    {
                                        PL.IsAgriPasture_Mound = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "poultry")
                                    {
                                        PL.IsAgriPoultry_Mound = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "crop")
                                    {
                                        PL.IsAgriCropAreas_Mound = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "sod")
                                    {
                                        PL.IsAgriSod_Mound = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "nursery_container")
                                    {
                                        PL.IsAgriNurseryContainer_Mound = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "nursery_bb")
                                    {
                                        PL.IsAgriNurseryBB_Mound = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "other")
                                    {
                                        PL.IsAgriOthers_Mound = true;
                                    }
                                }
                            }

                            else
                            {
                                for (i = 0; i < dynObj.AgriTreatmentSites.Count; i++)
                                {
                                    if (dynObj.AgriTreatmentSites[i].value == "pasture")
                                    {
                                        PL.IsAgriPasture_Broadcast = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "poultry")
                                    {
                                        PL.IsAgriPoultry_Broadcast = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "crop")
                                    {
                                        PL.IsAgriCropAreas_Broadcast = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "sod")
                                    {
                                        PL.IsAgriSod_Broadcast = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "nursery_container")
                                    {
                                        PL.IsAgriNurseryContainer_Broadcast = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "nursery_bb")
                                    {
                                        PL.IsAgriNurseryBB_Broadcast = true;
                                    }
                                    else if (dynObj.AgriTreatmentSites[i].value == "other")
                                    {
                                        PL.IsAgriOthers_Broadcast = true;
                                    }
                                }

                            }
                        }
                    }
                    db.Product_list.Add(PL);
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

        public Boolean EditProductDetails(string product_details)
        {
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                dynamic dynObj = JsonConvert.DeserializeObject(product_details);
                int product_id=dynObj.ProductId;
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var product = db.Product_list.Where(o => o.ProductId == product_id);
                        if (product.Any())
                        {
                            db.Product_list.Remove(product.FirstOrDefault());
                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                        Boolean x = AddProductDetails(product_details);
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            
            return true;
        }
    }
}