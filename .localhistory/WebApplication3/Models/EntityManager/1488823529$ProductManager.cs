using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.DB;
using WebApplication3.Models.ViewModel;

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

                foreach (Product_list u in db.ProductDatas)
                {
                    PI = new ProductInfo2();
                    PI.ProductId = u.ProductId;
                    PI.ActiveIngredient = u.ActiveIngredient;
                    PI.ProductName = u.ProductName;
                    PI.ProductManufacturer = u.Manufacturer_;
                    PI.PhysicalForm = u.PhysicalForm;
                    PI.ProductControlMethod = u.ControlMethod;
                    if (u.IsBroadcast == true)
                    {
                        PI.ProductTreatmentMethod = "Broadcast";
                        PI.ProductMinUseRate =Convert.ToDouble(u.Broadcast_MinUseRate) ;
                        PI.ProductMaxUseRate =Convert.ToDouble(u.Broadcast_MaxUseRate);
                        PI.ProductMeasurementUnit = u.Broadcast_MeasurementUnit;
                    }
                    else
                    {
                        PI.ProductTreatmentMethod = "Mound";
                        PI.ProductMinUseRate = Convert.ToDouble(u.Mound_MinUseRate);
                        PI.ProductMaxUseRate = Convert.ToDouble(u.Mound_MaxUseRate);
                        PI.ProductMeasurementUnit = u.Mound_MeasurementUnit;
                    
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
                        if (u.IsUrbanHome_Broadcast || u.IsUrbanHome_Mound == true)
                        {
                            PI.TypeOfTreatmentSite = "Home Lawns / Ornamentals";
                        }
                        else if (u.IsUrbanPerimeter_P == true)
                        {
                            PI.TypeOfTreatmentSite = "Perimeter";
                        }
                        else if (u.IsUrbanRecArea_Broadcast || u.IsUrbanRecArea_Mound == true)
                        {
                            PI.TypeOfTreatmentSite = "Recreational Areas";
                        }
                        else
                        {
                            PI.TypeOfTreatmentSite = "Right of Way";
                        }
                    }
                    else
                    {
                        if (u.IsAgriPasture_Broadcast == true || u.IsAgriPasture_Mound == true)
                        {
                            PI.TypeOfTreatmentSite = "Home Lawns / Ornamentals";
                        }
                        else if (u.IsAgriPoultry_Broadcast == true || u.IsAgriPoultry_Mound == true)
                        {
                            PI.TypeOfTreatmentSite = "Perimeter";
                        }
                        else if (u.IsAgriCropAreas_Broadcast == true || u.IsAgriCropAreas_Mound == true)
                        {
                            PI.TypeOfTreatmentSite = "Recreational Areas";
                        }
                    }

                    System.Diagnostics.Debug.WriteLine("productpv=" + PI.ProductId);
                    products.Add(PI);
                }
            }
            System.Diagnostics.Debug.WriteLine("productpv=" + products);

            return products;
        }


        public ProductDataView GetProductDataView2()
        {
            ProductDataView2 PDV = new ProductDataView2();
            List<ProductInfo2> products = GetAllProductsInfo2();

            PDV.Products = products;
            System.Diagnostics.Debug.WriteLine("productpdvv=" + PDV.Products);
            return PDV;
        }
    }
}