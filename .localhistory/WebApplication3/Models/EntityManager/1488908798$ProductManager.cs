﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.DB;
using WebApplication3.Models.ViewModel;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

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
                    PI.ProductTreatmentMethod = new List<string>();
                    PI.ProductMeasurementUnit2 = new List<string>();

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
                            string x =  u.Broadcast_MinUseRate + " - " + u.Broadcast_MaxUseRate + u.Broadcast_MeasurementUnit;
                            PI.ProductMeasurementUnit2.Add(x);
                        }
                        else 
                        {
                            PI.ProductTreatmentMethod.Add("Mound");
                            //PI.ProductMinUseRate = Convert.ToDouble(u.Mound_MinUseRate);
                            //PI.ProductMaxUseRate = Convert.ToDouble(u.Mound_MaxUseRate);
                            //PI.ProductMeasurementUnit = u.Mound_MeasurementUnit;
                            string y =  u.Mound_MinUseRate + " - " + u.Mound_MaxUseRate + u.Mound_MeasurementUnit;
                            PI.ProductMeasurementUnit2.Add(y);

                        }
                    }
                    
                    PI.ProductUrl = u.MaunfacturerUrl;
                    if (u.IsUrbanLand == true)
                    {
                        PI.TypeOfLand = "Urban";
                    }
                    else
                    {
                        PI.TypeOfLand = "Agricultural";
                    }
                   
                    if (PI.TypeOfLand == "Urban")
                    {
                        if (u.IsUrbanHome_Broadcast == true || u.IsUrbanHome_Mound == true)
                        {
                            PI.TreatmentSites.Add("Home Lawns / Ornamentals");
                            
                        }
                        if (u.IsUrbanPerimeter_P == true)
                        {
                            PI.TreatmentSites.Add("Perimeter");
                        }
                        if (u.IsUrbanRecArea_Broadcast == true || u.IsUrbanRecArea_Mound == true)
                        {
                            PI.TreatmentSites.Add("Recreational Areas");
                        }
                        if (u.IsUrbanRightOfWay_Broadcast == true || u.IsUrbanRightOfWay_Mound == true)
                        {
                            PI.TreatmentSites.Add("Right of Way");
                        }
                    }
                    else
                    {
                        if (u.IsAgriPasture_Broadcast == true || u.IsAgriPasture_Mound == true)
                        {
                            PI.TreatmentSites.Add("Pasture Land");
                        }
                        if (u.IsAgriPoultry_Broadcast == true || u.IsAgriPoultry_Mound == true)
                        {
                           PI.TreatmentSites.Add("Poultry Houses");
                        }
                        if (u.IsAgriCropAreas_Broadcast == true || u.IsAgriCropAreas_Mound == true)
                        {
                            PI.TreatmentSites.Add("Crop Areas");
                        }
                        if (u.IsAgriSod_Broadcast == true || u.IsAgriSod_Mound == true)
                        {
                            PI.TreatmentSites.Add("Sod / Turf");
                        }
                       if (u.IsAgriOthers_Broadcast == true || u.IsAgriOthers_Mound == true)
                        {
                            PI.TreatmentSites.Add("Other ( Fences / Rows / Ditches / Out Buildings)");
                        }

                        if (u.IsAgriNurseryContainer_Broadcast == true || u.IsAgriNurseryContainer_Mound == true)
                        {
                           PI.TreatmentSites.Add("Nursery Container");
                        }
                        if (u.IsAgriNurseryBB_Broadcast == true || u.IsAgriNurseryBB_Mound == true)
                        {
                            PI.TreatmentSites.Add("Nursery B & B (Ball & Burlap) ");
                        }
                    }

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

        public Boolean AddProductDetails(String product_details)
        {
            try
            {
                using (FASIDSEntities4 db = new FASIDSEntities4())
                {
                    Product_list PL = new Product_list();
                    dynamic dynObj = JsonConvert.DeserializeObject(product_details);
                    PL.ProductId = Convert.ToInt32(Guid.NewGuid());
                    PL.ProductName = 
                    PL.ActiveIngredient=
                    PL.Manufacturer_=
                    PL.MaunfacturerUrl=null;
                    PL.PesticideClassification =
                    PL.IsSynthetic_ =
                    PL.PhysicalForm =
                    PL.ControlMethod =
                    PL.IsBroadcast =
                    PL.IsMound =
                    PL.Broadcast_MinUseRate =
                    PL.Broadcast_MinUseRate =
                    PL.Broadcast_MeasurementUnit = "hjg" ;
                    PL.Mound_MinUseRate =
                    PL.Mound_MaxUseRate =
                    PL.Mound_MeasurementUnit ="jh";
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
            return true;
        }

    }
}