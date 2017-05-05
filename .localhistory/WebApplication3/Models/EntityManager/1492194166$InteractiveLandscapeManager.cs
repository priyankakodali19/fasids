using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication3.Models.DB;
using WebApplication3.Models.ViewModel;
using Newtonsoft.Json;
using System.Data.Entity.Spatial;
using System.Text;
using Newtonsoft.Json.Linq;

namespace WebApplication3.Models.EntityManager
{
    public class InteractiveLandscapeManager
    {
        
        public string AddUserPolygon(String polygonJson, string UserId)
        {
            try
            {
                using (FASIDSEntities db = new FASIDSEntities())
                {

                    //PolygonGeoJson PG = new PolygonGeoJson();
                    //----treatment2---------------
                    NewPolygonGeoJson PG = new NewPolygonGeoJson();
                    dynamic dynObj = JsonConvert.DeserializeObject(polygonJson);
                    System.Diagnostics.Debug.WriteLine("userpv=" + polygonJson);


                    string xyz = Guid.NewGuid().ToString().Substring(0, 8);
                    //PG.UserId = UserId;
                    //PG.GeoJsonId = xyz;
                    //PG.Type = dynObj.type;
                    //PG.GeometryType = dynObj.geometry.type;
                    //PG.PolygonName = dynObj.properties.polygon_name;
                    //PG.Address = dynObj.properties.address;
                    //PG.Bounds_NE_Lng = dynObj.properties.bounds.ne.lng;
                    //PG.Bounds_NE_Lat = dynObj.properties.bounds.ne.lat;
                    //PG.Bounds_SW_Lat = dynObj.properties.bounds.sw.lat;
                    //PG.Bounds_SW_Lng = dynObj.properties.bounds.sw.lng;
                    //PG.ControlMethod = dynObj.properties.control_method;
                    //PG.EnvMapTypeId = dynObj.properties.environment_map.MapTypeId;
                    //PG.EnvMapTilt = dynObj.properties.environment_map.tilt;
                    //PG.IsOutdoor = dynObj.properties.is_outdoor;
                    //PG.MoundDensity = dynObj.properties.mound_density;
                    //PG.MoundNumber = dynObj.properties.mound_number;
                    //PG.NeedOrganic = dynObj.properties.need_organic;
                    //PG.NeedSafeForPets = dynObj.properties.need_safe_for_pets;
                    //PG.Notes = dynObj.properties.notes;
                    //PG.TotalArea = dynObj.properties.total_area;
                    //PG.TypeOfUse = dynObj.properties.type_of_use;
                    //PG.Usage = dynObj.properties.usage;

                    //-----------------------------treatment2--------------------------------
                    PG.UserId = UserId;
                    PG.GeoJsonId = xyz;
                    PG.Type = dynObj.type;
                    PG.GeometryType = dynObj.geometry.type;
                    PG.PolygonName = dynObj.properties.polygon_name;
                    PG.Address = dynObj.properties.address;
                    PG.Bounds_NE_Lng = dynObj.properties.bounds.ne.lng;
                    PG.Bounds_NE_Lat = dynObj.properties.bounds.ne.lat;
                    PG.Bounds_SW_Lat = dynObj.properties.bounds.sw.lat;
                    PG.Bounds_SW_Lng = dynObj.properties.bounds.sw.lng;
                    //PG.ControlMethod = dynObj.properties.control_method;
                    PG.EnvMapTypeId = dynObj.properties.environment_map.MapTypeId;
                    PG.EnvMapTilt = dynObj.properties.environment_map.tilt;
                    //PG.IsOutdoor = dynObj.properties.is_outdoor;
                    PG.MoundDensity = dynObj.properties.mound_density;
                    PG.MoundNumber = dynObj.properties.mound_number;
                    //PG.NeedOrganic = dynObj.properties.need_organic;
                    //PG.NeedSafeForPets = dynObj.properties.need_safe_for_pets;
                    PG.Notes = dynObj.properties.notes;
                    PG.TotalArea = dynObj.properties.total_area;
                    //PG.TypeOfUse = dynObj.properties.type_of_use;
                    //PG.Usage = dynObj.properties.usage;
                    PG.TypeOfLand = dynObj.properties.type_of_land;
                    PG.TypeOfUrban = dynObj.properties.type_of_urban;
                    PG.TypeOfAgri = dynObj.properties.type_of_agri;
                    PG.TypeOfTreatment = dynObj.properties.type_of_treatment;
                    PG.TypeOfControlMethod = dynObj.properties.type_of_control_method;


                    //-----------------------------treatment2--------------------------------

                    dynamic x = JsonConvert.SerializeObject(polygonJson);

                    dynamic z = JsonConvert.SerializeObject(dynObj.geometry.coordinates);

                    dynamic y = dynObj.geometry.coordinates;
                    dynamic mic = y;
                    var sb = new StringBuilder();

                    sb.Append(@"POLYGON(");
                    if (dynObj.geometry.coordinates.Count == 1)
                    {
                        sb.Append(@"(");
                        for (int i = 0; i < dynObj.geometry.coordinates[0].Count; i++)
                        {
                            if (i == 0)
                            {

                                sb.Append(dynObj.geometry.coordinates[0][i][0] + " " + dynObj.geometry.coordinates[0][i][1]);
                            }
                            else
                            {
                                sb.Append("," + dynObj.geometry.coordinates[0][i][0] + " " + dynObj.geometry.coordinates[0][i][1]);
                            }

                        }
                        sb.Append(@")");
                    }
                    else
                    {
                        int k = 0;
                        k = dynObj.geometry.coordinates.Count;
                        for (int j = 0; j < k; j++)
                        {
                            if (j == 0)
                            { sb.Append(@"("); }
                            else
                            { sb.Append(@", ("); }
                            for (int i = 0; i < dynObj.geometry.coordinates[j].Count; i++)
                            {
                                if (i == 0)
                                {

                                    sb.Append(dynObj.geometry.coordinates[j][i][0] + " " + dynObj.geometry.coordinates[j][i][1]);
                                }
                                else
                                {
                                    sb.Append("," + dynObj.geometry.coordinates[j][i][0] + " " + dynObj.geometry.coordinates[j][i][1]);
                                }
                            }
                            sb.Append(@")");
                        }
                    }
                    sb.Append(@")");
                    String sy = sb.ToString();
                    String sx = sy;
                    PG.Coordinates = DbGeometry.PolygonFromText(sb.ToString(), 4326);

                    db.NewPolygonGeoJsons.Add(PG);
                    db.SaveChanges();

                    return PG.GeoJsonId;


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

        public int IsGeoJsonIdExist(int id)
        {
            var flag = 0;

            using (FASIDSEntities db = new FASIDSEntities())
            {
                if (db.PolygonGeoJsons.Where(o => o.GeoJsonId.Equals(id)).Any())
                {
                    flag = 1;
                }
            }
            return flag;
        }

        public DisplayUserPolygon2 GetUserDataView(string polygonid)
        {
            DisplayUserPolygon2 DUP = new DisplayUserPolygon2();
            DUP.coordinates_str = "";
            // int userID = GetUserID(loginName);
            System.Diagnostics.Debug.WriteLine("useris=" + polygonid);
            using (FASIDSEntities db = new FASIDSEntities())
            {
                var polygon = db.NewPolygonGeoJsons.Where(o => o.GeoJsonId.Equals(polygonid));
                if (polygon.Any())
                {
                    DUP.UserId = polygon.FirstOrDefault().UserId;
                    DUP.GeoJsonId = polygon.FirstOrDefault().GeoJsonId;
                    DUP.Type = polygon.FirstOrDefault().Type;
                    DUP.GeometryType = polygon.FirstOrDefault().GeometryType;
                    DUP.PolygonName = polygon.FirstOrDefault().PolygonName;
                    DUP.Address = polygon.FirstOrDefault().Address;
                    DUP.Bounds_NE_Lng =  Convert.ToDouble(polygon.FirstOrDefault().Bounds_NE_Lng);
                    DUP.Bounds_NE_Lat =  Convert.ToDouble(polygon.FirstOrDefault().Bounds_NE_Lat);
                    DUP.Bounds_SW_Lat =  Convert.ToDouble(polygon.FirstOrDefault().Bounds_SW_Lat);
                    DUP.Bounds_SW_Lng =  Convert.ToDouble(polygon.FirstOrDefault().Bounds_SW_Lng);
                    DUP.TypeOfLand = polygon.FirstOrDefault().TypeOfLand;
                    DUP.TypeOfUrban = polygon.FirstOrDefault().TypeOfUrban;
                    DUP.TypeOfAgri = polygon.FirstOrDefault().TypeOfAgri;
                    DUP.TypeOfTreatment = polygon.FirstOrDefault().TypeOfTreatment;
                    DUP.TypeOfControlMethod = polygon.FirstOrDefault().TypeOfControlMethod;
                    DUP.EnvMapTypeId = polygon.FirstOrDefault().EnvMapTypeId;
                    DUP.EnvMapTilt = polygon.FirstOrDefault().EnvMapTilt;
                    DUP.MoundDensity = Convert.ToDouble(polygon.FirstOrDefault().MoundDensity);
                    DUP.MoundNumber = Convert.ToInt32(polygon.FirstOrDefault().MoundNumber);
                    DUP.Notes = polygon.FirstOrDefault().Notes;
                    DUP.TotalArea = Convert.ToDouble(polygon.FirstOrDefault().TotalArea)*10.76;
                    
                   
                    DUP.Coordinates = polygon.FirstOrDefault().Coordinates;

                    DUP.coordinates_str = DUP.Coordinates.AsText();
                }
                //var asv = result;
               // var gh = result.ToList();
                //var th = gh;

                var result2 = DUP.coordinates_str;
                var sd = result2;
            }
            // System.Diagnostics.Debug.WriteLine("userpv=" + UPV.FirstName);
            return DUP;
        }

        public double getAmount(string usage, string prodcoverage, int mound_number, double total_area)
        {
            double coverage = Convert.ToDouble(prodcoverage);
            double amount = 0;
            
                switch (usage)
                {    // "usage" field of geoJsonObject is a must-be-filled field.
                    case "imt":
                        {
                            amount = (mound_number / coverage);
                            break;
                        }
                    case "broadcast":
                        {
                            amount = (total_area / coverage);
                            break;
                        }
                    case "broadcastimt":
                        {
                            amount = (total_area / coverage);
                            break;
                        }
                      
                }
            
            return Math.Round(amount,3);
        }
        public List<ProductTreatmentInfo> GetAllProductsTreatmentInfo(string polygonid)
        {
            ProductTreatmentInfo PTI = new ProductTreatmentInfo();
            List<ProductTreatmentInfo> products = new List<ProductTreatmentInfo>();
            

            using (FASIDSEntities db = new FASIDSEntities())
            {
                System.Diagnostics.Debug.WriteLine("useris=" + polygonid);
                //Boolean IsOutdoor = false, NeedOrganic = false, NeedSafeForPets = false;
                var polygon = db.PolygonGeoJsons.Where(o => o.GeoJsonId.Equals(polygonid));
                
                if (polygon.Any())
                {
                    PTI.IsOutdoor = Convert.ToBoolean(polygon.FirstOrDefault().IsOutdoor);
                    PTI.NeedOrganic = Convert.ToBoolean(polygon.FirstOrDefault().NeedOrganic);
                    PTI.NeedSafeForPets = Convert.ToBoolean(polygon.FirstOrDefault().NeedSafeForPets);
                    string ControlMethod = polygon.FirstOrDefault().ControlMethod;
                    string Usage = polygon.FirstOrDefault().Usage;
                    double TotalArea = Convert.ToDouble(polygon.FirstOrDefault().TotalArea);
                    int MoundNumber = Convert.ToInt32(polygon.FirstOrDefault().MoundNumber);
                    
                    var treatment_products = db.ProductDatas.Where(o => o.ProductControlMethod.Equals(ControlMethod) && o.ProductUsage.Equals(Usage));
                    if (treatment_products.Any())
                    {
                        foreach (ProductData u in treatment_products)
                        {
                            PTI = new ProductTreatmentInfo();
                            PTI.ProductId = u.ProductId;
                            PTI.ProductName = u.ProductName;
                            PTI.ProductManufacturer = u.ProductManufacturer;
                            PTI.PhysicalForm = u.PhysicalForm;
                            PTI.ProductControlMethod = u.ProductControlMethod;
                            PTI.ProductUsage = u.ProductUsage;
                            PTI.ProductUrl = u.ProductUrl;
                            PTI.ImageUrl = u.ImageUrl;
                            PTI.ProductCoverage = u.ProductCoverage;
                            PTI.Amount = getAmount(u.ProductUsage, u.ProductCoverage, MoundNumber, TotalArea);
                            products.Add(PTI);
                        }
                     }
                }
            }
            return products;
        }

        public ProductTreatmentDataView GetProductTreatmentInfo(string polygon_id)
        {
            ProductTreatmentDataView PTDV = new ProductTreatmentDataView();
            List<ProductTreatmentInfo> products = GetAllProductsTreatmentInfo(polygon_id);

            PTDV.Products = products;
            System.Diagnostics.Debug.WriteLine("productpdvv=" + PTDV.Products);
            return PTDV;
        }

        public void DeleteUserPolygon(string polygon_id)
        {
            System.Diagnostics.Debug.WriteLine("productpdvv=" + polygon_id);
            using (FASIDSEntities db = new FASIDSEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var polygon = db.PolygonGeoJsons.Where(o => o.GeoJsonId == polygon_id);
                        if (polygon.Any())
                        {

                            db.PolygonGeoJsons.Remove(polygon.FirstOrDefault());
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

        public bool IsUserInRole(string loginName, string roleName)
        {
            using (FASIDSEntities db = new FASIDSEntities())
            {

                var user = db.UserDatas.Where(o => o.UserName.Equals(loginName));
                if (user != null)
                {
                    var roles = db.UserDatas.Where(o => o.UserCategory.Equals(roleName));
                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }

                return false;
            }
        }


        //-------------------------------treatment2----------------------------------------------
        public List<ProductTreatmentInfo2> GetAllProductsTreatmentInfo2(string polygonid)
        {
            ProductTreatmentInfo2 PTI = new ProductTreatmentInfo2();
            List<ProductTreatmentInfo2> products = new List<ProductTreatmentInfo2>();


            using (FASIDSEntities db = new FASIDSEntities())
            {
                System.Diagnostics.Debug.WriteLine("useris=" + polygonid);
                //Boolean IsOutdoor = false, NeedOrganic = false, NeedSafeForPets = false;
                var polygon = db.NewPolygonGeoJsons.Where(o => o.GeoJsonId.Equals(polygonid));
                

                if (polygon.Any())
                {
                    //PTI.IsOutdoor = Convert.ToBoolean(polygon.FirstOrDefault().IsOutdoor);
                    //PTI.NeedOrganic = Convert.ToBoolean(polygon.FirstOrDefault().NeedOrganic);
                    //PTI.NeedSafeForPets = Convert.ToBoolean(polygon.FirstOrDefault().NeedSafeForPets);
                    string TypeOfLand = polygon.FirstOrDefault().TypeOfLand;
                    PTI.TypeOfLand = TypeOfLand;
                    string TypeOfUrban, TypeOfAgri;
                    double TotalArea = Convert.ToDouble(polygon.FirstOrDefault().TotalArea)*10.76;
                    int MoundNumber = Convert.ToInt32(polygon.FirstOrDefault().MoundNumber);
                    string ControlMethod = polygon.FirstOrDefault().TypeOfControlMethod;
                    string TreatmentMethod = polygon.FirstOrDefault().TypeOfTreatment;
                    Boolean IsBroadcastValue=false, IsMoundValue=false, IsUrbanHome_Broadcast, IsUrbanHome_Mound, IsUrbanPerimeter_P, IsUrbanRecArea_Broadcast,
                        IsUrbanRecArea_Mound, IsUrbanRightOfWay_Broadcast, IsUrbanRightOfWay_Mound, IsAgriPasture_Broadcast, IsAgriPasture_Mound, 
                        IsAgriPoultry_Broadcast, IsAgriPoultry_Mound, IsAgriCropAreas_Broadcast, IsAgriCropAreas_Mound, IsAgriOthers_Broadcast, IsAgriOthers_Mound,
                        IsAgriSod_Broadcast, IsAgriSod_Mound, IsAgriNurseryContainer_Broadcast,IsAgriNurseryContainer_Mound,IsAgriNurseryBB_Broadcast,IsAgriNurseryBB_Mound ;
                    var treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod));
                    if (TreatmentMethod.Equals("broadcast"))
                    {
                        IsBroadcastValue = true;
                        if (TypeOfLand.Equals("urban"))
                        {
                            
                            TypeOfUrban = polygon.FirstOrDefault().TypeOfUrban;
                            PTI.TypeOfUrban = TypeOfUrban;
                            if (TypeOfUrban.Equals("home_lawns"))
                            {
                                IsUrbanHome_Broadcast = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsBroadcast.Equals(IsBroadcastValue) 
                                    && o.IsUrbanHome_Broadcast.Equals(IsUrbanHome_Broadcast));
                            }
                            else if (TypeOfUrban.Equals("perimeter"))
                            {
                                IsUrbanPerimeter_P = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsBroadcast.Equals(IsBroadcastValue)
                                    && o.IsUrbanPerimeter_P.Equals(IsUrbanPerimeter_P));
                            }
                            else if (TypeOfUrban.Equals("rec"))
                            {
                                IsUrbanRecArea_Broadcast = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsBroadcast.Equals(IsBroadcastValue)
                                     && o.IsUrbanRecArea_Broadcast.Equals(IsUrbanRecArea_Broadcast));
                            }
                            else
                            {
                                IsUrbanRightOfWay_Broadcast = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsBroadcast.Equals(IsBroadcastValue)
                                     && o.IsUrbanRightOfWay_Broadcast.Equals(IsUrbanRightOfWay_Broadcast));
                            }
                           
                        
                        }
                        else
                        {
                            TypeOfAgri = polygon.FirstOrDefault().TypeOfAgri;
                            PTI.TypeOfAgri = TypeOfAgri;
                            if (TypeOfAgri.Equals("pasture"))
                            {
                                IsAgriPasture_Broadcast = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsBroadcast.Equals(IsBroadcastValue)
                                    && o.IsAgriPasture_Broadcast.Equals(IsAgriPasture_Broadcast));
                            }
                            else if (TypeOfAgri.Equals("poultry"))
                            {
                                IsAgriPoultry_Broadcast = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsBroadcast.Equals(IsBroadcastValue)
                                   && o.IsAgriPoultry_Broadcast.Equals(IsAgriPoultry_Broadcast));
                            }
                            else if (TypeOfAgri.Equals("crop"))
                            {
                                IsAgriCropAreas_Broadcast = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsBroadcast.Equals(IsBroadcastValue)
                                   && o.IsAgriCropAreas_Broadcast.Equals(IsAgriCropAreas_Broadcast));
                            }
                            else if (TypeOfAgri.Equals("sod"))
                            {
                                IsAgriSod_Broadcast = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsBroadcast.Equals(IsBroadcastValue)
                                   && o.IsAgriSod_Broadcast.Equals(IsAgriSod_Broadcast));
                            }
                            else if (TypeOfAgri.Equals("nursery_container"))
                            {
                                IsAgriNurseryContainer_Broadcast = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsBroadcast.Equals(IsBroadcastValue)
                                   && o.IsAgriNurseryContainer_Broadcast.Equals(IsAgriNurseryContainer_Broadcast));
                            }
                            else if (TypeOfAgri.Equals("nursery_bb"))
                            {
                                IsUrbanRecArea_Broadcast = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsBroadcast.Equals(IsBroadcastValue)
                                   && o.IsUrbanRecArea_Broadcast.Equals(IsUrbanRecArea_Broadcast));
                            }
                            else
                            {
                                IsAgriOthers_Broadcast = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsBroadcast.Equals(IsBroadcastValue)
                                   && o.IsAgriOthers_Broadcast.Equals(IsAgriOthers_Broadcast));
                            }
                        }
                    }
                    else
                    {
                        IsMoundValue = true;
                        TypeOfUrban = polygon.FirstOrDefault().TypeOfUrban;
                         PTI.TypeOfUrban = TypeOfUrban;
                        if (TypeOfLand.Equals("urban"))
                        {
                            if (TypeOfUrban.Equals("home_lawns"))
                            {
                                IsUrbanHome_Mound = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsMound.Equals(IsMoundValue)
                                   && o.IsUrbanHome_Mound.Equals(IsUrbanHome_Mound));
                            }
                            //else if (TypeOfUrban.Equals("perimeter"))
                            //{
                            //    IsUrbanPerimeter_P = true;
                            //}
                            else if (TypeOfUrban.Equals("rec"))
                            {
                                IsUrbanRecArea_Mound = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsMound.Equals(IsMoundValue)
                                   && o.IsUrbanRecArea_Mound.Equals(IsUrbanRecArea_Mound));
                            }
                            else
                            {
                                IsUrbanRightOfWay_Mound = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsMound.Equals(IsMoundValue)
                                   && o.IsUrbanRightOfWay_Mound.Equals(IsUrbanRightOfWay_Mound));
                            }

                        }
                        else
                        {
                            TypeOfAgri = polygon.FirstOrDefault().TypeOfAgri;
                                 PTI.TypeOfAgri = TypeOfAgri;
                            if (TypeOfAgri.Equals("pasture"))
                            {
                                IsAgriPasture_Mound = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsMound.Equals(IsMoundValue)
                                   && o.IsAgriPasture_Mound.Equals(IsAgriPasture_Mound));
                            }
                            else if (TypeOfAgri.Equals("poultry"))
                            {
                                IsAgriPoultry_Mound = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsMound.Equals(IsMoundValue)
                                   && o.IsAgriPoultry_Mound.Equals(IsAgriPoultry_Mound));
                            }
                            else if (TypeOfAgri.Equals("crop"))
                            {
                                IsAgriCropAreas_Mound = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsMound.Equals(IsMoundValue)
                                   && o.IsAgriCropAreas_Mound.Equals(IsAgriCropAreas_Mound));
                            }
                            else if (TypeOfAgri.Equals("sod"))
                            {
                                IsAgriSod_Mound = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsMound.Equals(IsMoundValue)
                                   && o.IsAgriSod_Mound.Equals(IsAgriSod_Mound));
                            }
                            else if (TypeOfAgri.Equals("nursery_container"))
                            {
                                IsAgriNurseryContainer_Mound = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsMound.Equals(IsMoundValue)
                                   && o.IsAgriNurseryContainer_Mound.Equals(IsAgriNurseryContainer_Mound));
                            }
                            else if (TypeOfAgri.Equals("nursery_bb"))
                            {
                                IsUrbanRecArea_Mound = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsMound.Equals(IsMoundValue)
                                   && o.IsUrbanRecArea_Mound.Equals(IsUrbanRecArea_Mound));
                            }
                            else
                            {
                                IsAgriOthers_Mound = true;
                                 treatment_products = db.Product_list.Where(o => o.ControlMethod.Equals(ControlMethod) && o.IsMound.Equals(IsMoundValue)
                                  && o.IsAgriOthers_Mound.Equals(IsAgriOthers_Mound));
                            }
                        } 
                    }

                   
                    if (treatment_products.Any())
                    {
                        foreach (Product_list u in treatment_products)
                        {
                            PTI = new ProductTreatmentInfo2();
                            PTI.ProductId = u.ProductId;
                            PTI.ActiveIngredient = u.ActiveIngredient;
                            PTI.ProductName = u.ProductName;
                            PTI.ProductManufacturer = u.Manufacturer_;
                            PTI.PhysicalForm = u.PhysicalForm;
                            PTI.PesticideClassification = u.PesticideClassification;
                            PTI.ProductControlMethod = u.ControlMethod;
                            PTI.IsSynthetic=u.IsSynthetic_;

                            if (IsMoundValue == true)
                            {
                                PTI.ProductTreatmentMethod = "Individual Mound Treatment";
                                PTI.ProductMinUseRate = Convert.ToDouble(u.Broadcast_MinUseRate);
                                PTI.ProductMaxUseRate = Convert.ToDouble(u.Broadcast_MaxUseRate);
                                PTI.ProductMeasurementUnit = u.Mound_MeasurementUnit;


                            }
                            else
                            {
                                PTI.ProductTreatmentMethod = "Broadcast";
                                PTI.ProductMinUseRate = Convert.ToDouble(u.Mound_MinUseRate);
                                PTI.ProductMaxUseRate = Convert.ToDouble(u.Mound_MaxUseRate);
                                PTI.ProductMeasurementUnit = u.Broadcast_MeasurementUnit;
                            }
                            PTI.ProductUrl = u.MaunfacturerUrl;

                            PTI.Amount = getAmount2(PTI.ProductTreatmentMethod, PTI.ProductMinUseRate, PTI.ProductMaxUseRate, PTI.ProductMeasurementUnit, MoundNumber, TotalArea);
                            products.Add(PTI);

                            
                        }
                    }
                }
            }
            return products;
        }

        public string getAmount2(string treatment, double MinRate, double MaxRate, string MeasurementUnit, int mound_number, double area)
        {
           // double coverage = Convert.ToDouble(prodcoverage);
            string amount = "";
            double min_amount, max_amount;
            switch (treatment)
            {    // "usage" field of geoJsonObject is a must-be-filled field.
                case "Individual Mound Treatment":
                    {
                        //amount = (mound_number / coverage);
                        min_amount = MinRate * mound_number;
                        max_amount = MaxRate * mound_number;

                        if (MeasurementUnit == "TSP/mound")
                        {
                            if (min_amount == 0)
                            {
                                min_amount = 0;
                            }
                            else
                            {
                                min_amount = min_amount / 3;    
                            }
                           
                            max_amount = max_amount / 3;
                        }

                        if (min_amount == 0)
                        {
                            amount = Math.Round(max_amount, 2) + " TSBPs";
                        }
                        else
                        {
                            amount = Math.Round(min_amount, 2) + " - " + Math.Round(max_amount, 2)+ " TSBPs";
                        }
                        
                        break;
                    }
                case "Broadcast":
                    {
                        //if (MeasurementUnit == "lb/acre")
                        //{
                            if (MinRate == 0)
                            {
                                min_amount = 0;

                            }
                            else
                            {
                                min_amount = (MinRate * area) / 43560;
                            }

                            max_amount = (MaxRate * area) / 43560;
                        //}

                        if (MinRate == 0)
                        {
                            amount = Math.Round(max_amount, 2) + " lb";
                        }
                        else
                        {
                            amount = Math.Round(min_amount, 2) + " - " + Math.Round(max_amount, 2) + " lb ";
                        }
                        break;
                    }
                //case "broadcastimt":
                //    {
                //        amount = (total_area / coverage);
                //        break;
                //    }

            }

            return amount;
        }

        public ProductTreatmentDataView2 GetProductTreatmentInfo2(string polygon_id)
        {
            ProductTreatmentDataView2 PTDV = new ProductTreatmentDataView2();
            List<ProductTreatmentInfo2> products = GetAllProductsTreatmentInfo2(polygon_id);

            PTDV.Products = products;
            System.Diagnostics.Debug.WriteLine("productpdvv=" + PTDV.Products);
            return PTDV;
        }

        //--------------------------------treatment 3----------------------------------
        public List<ProductTreatmentInfo2> GetAllProductsTreatmentInfo3(string polygonid)
        {
            ProductTreatmentInfo2 PTI = new ProductTreatmentInfo2();
            List<ProductTreatmentInfo2> products = new List<ProductTreatmentInfo2>();


            using (FASIDSEntities db = new FASIDSEntities())
            {
                System.Diagnostics.Debug.WriteLine("useris=" + polygonid);
                //Boolean IsOutdoor = false, NeedOrganic = false, NeedSafeForPets = false;
                var polygon = db.NewPolygonGeoJsons.Where(o => o.GeoJsonId.Equals(polygonid));


                if (polygon.Any())
                {
                    
                    string TypeOfLand = polygon.FirstOrDefault().TypeOfLand;
                    string TypeOfUrban, TypeOfAgri;
                    double TotalArea = Convert.ToDouble(polygon.FirstOrDefault().TotalArea) * 10.76;
                    int MoundNumber = Convert.ToInt32(polygon.FirstOrDefault().MoundNumber);
                    string ControlMethod = polygon.FirstOrDefault().TypeOfControlMethod;
                    string TreatmentMethod = "";
                    if(polygon.FirstOrDefault().TypeOfTreatment.Equals("broadcast"){
                        TreatmentMethod = "Broadcast";
                    }
                    else{
                         TreatmentMethod = "Mound";
                    }
                    var final_treatment_products = db.ProductList_new.Where(o => o.ControlMethod.ToLower().Equals(ControlMethod.ToLower());
                    var treatment_products = db.ProductList_new.Where(o => o.ControlMethod.ToLower().Equals(ControlMethod.ToLower()) && o.TreatmentMethod.Equals("BroadcastMound") || o.TreatmentMethod.ToLower().Equals(TreatmentMethod.ToLower()));
                    var land_type_codes=db.TreatmentSiteCodes.Where(o => o.TreatmentType == "UrbanBroadcast");
                    if (TypeOfLand.ToLower() == "urban")
                    {
                        if (TreatmentMethod.ToLower() == "broadcast")
                        {
                            land_type_codes = db.TreatmentSiteCodes.Where(o => o.TreatmentType == "UrbanBroadcast");
                        }
                        else
                        {
                            land_type_codes = db.TreatmentSiteCodes.Where(o => o.TreatmentType == "UrbanMound");
                        }
                    }
                    else
                    {
                        if (TreatmentMethod.ToLower() == "broadcast")
                        {
                            land_type_codes = db.TreatmentSiteCodes.Where(o => o.TreatmentType == "AgriBroadcast");
                        }
                        else
                        {
                           land_type_codes = db.TreatmentSiteCodes.Where(o => o.TreatmentType == "AgriMound");
                        }
                    }
                   
                   var site_code="";
                   foreach (TreatmentSiteCode obj in land_type_codes)
                    {
                        if (TypeOfLand.ToLower() == "urban")
                        {
                            if (TypeOfUrban.Equals(obj.SiteType))
                            {
                                site_code = obj.Code;
                               
                            }
                        }
                        else
                        {
                            if (TypeOfAgri.Equals(obj.SiteType))
                            {
                                site_code = obj.Code;
                               
                            }
                        }
                    }

                   if (TreatmentMethod.ToLower() == "broadcast" && TypeOfLand.ToLower() == "urban" )
                    {
                        int temp1 = 0; 
                        temp1=site_code.IndexOf('1');
                        final_treatment_products = treatment_products.Where(o => o.UrbanBroadcastSites.Substring(temp1,1).Equals('1'));                           
                    }

                   else if (TreatmentMethod.ToLower() == "mound" && TypeOfLand.ToLower() == "urban" )
                   {
                        int temp1 = 0; 
                        temp1=site_code.IndexOf('1');
                        final_treatment_products = treatment_products.Where(o => o.UrbanMoundSites.Substring(temp1,1).Equals('1'));                                               
                   }
                    else if (TreatmentMethod.ToLower() == "broadcast" && TypeOfLand.ToLower() == "agricultural" )
                   {
                        int temp1 = 0; 
                        temp1=site_code.IndexOf('1');
                        final_treatment_products = treatment_products.Where(o => o.AgriBroadcastSites.Substring(temp1,1).Equals('1'));                                               
                   }
                    else if (TreatmentMethod.ToLower() == "mound" && TypeOfLand.ToLower() == "agricultural" )
                   {
                        int temp1 = 0; 
                        temp1=site_code.IndexOf('1');
                        final_treatment_products = treatment_products.Where(o => o.AgriMoundSites.Substring(temp1,1).Equals('1'));                                               
                   }
                   

                    if (treatment_products.Any())
                    {
                        foreach (ProductList_new u in final_treatment_products)
                        {
                            PTI = new ProductTreatmentInfo2();
                            PTI.ProductId = u.ProductId;
                            PTI.ActiveIngredient = u.ActiveIngredient;
                            PTI.ProductName = u.ProductName;
                            PTI.ProductManufacturer = u.Manufacturer_;
                            PTI.PhysicalForm = u.PhysicalForm;
                            PTI.IsSynthetic = u.IsSynthetic_;
                            PTI.PesticideClassification = u.PesticideClassification;
                            PTI.ProductControlMethod = u.ControlMethod;
                            PTI.TypeOfLand = TypeOfLand;
                            PTI.ProductTreatmentMethod =TreatmentMethod;
                           

                            if (u.TreatmentMethod=="Mound" || u.TreatmentMethod=="BroadcastMound")
                            {
                                PTI.ProductTreatmentMethod = "Individual Mound Treatment";
                                PTI.ProductMinUseRate = Convert.ToDouble(u.Mound_MinUseRate);
                                PTI.ProductMaxUseRate = Convert.ToDouble(u.Mound_MaxUseRate);
                                PTI.ProductMeasurementUnit = u.Mound_MeasurementUnit;


                            }
                            else 
                            {
                                PTI.ProductTreatmentMethod = "Broadcast";
                                PTI.ProductMinUseRate = Convert.ToDouble(u.Broadcast_MinUseRate);
                                PTI.ProductMaxUseRate = Convert.ToDouble(u.Broadcast_MaxUseRate);
                                PTI.ProductMeasurementUnit = u.Broadcast_MeasurementUnit;
                            }
                            PTI.ProductUrl = u.MaunfacturerUrl;

                            PTI.Amount = getAmount3(PTI.ProductTreatmentMethod, PTI.ProductMinUseRate, PTI.ProductMaxUseRate, PTI.ProductMeasurementUnit, MoundNumber, TotalArea);
                            products.Add(PTI);


                        }
                    }
                }
            }
            return products;
        }

        public string getAmount3(string treatment, double MinRate, double MaxRate, string MeasurementUnit, int mound_number, double area)
        {
            // double coverage = Convert.ToDouble(prodcoverage);
            string amount = "";
            double min_amount, max_amount;
            switch (treatment)
            {    // "usage" field of geoJsonObject is a must-be-filled field.
                case "Individual Mound Treatment":
                    {
                        //amount = (mound_number / coverage);
                        min_amount = MinRate * mound_number;
                        max_amount = MaxRate * mound_number;

                        if (MeasurementUnit == "TSP/mound")
                        {
                            if (min_amount == 0)
                            {
                                min_amount = 0;
                            }
                            else
                            {
                                min_amount = min_amount / 3;
                            }

                            max_amount = max_amount / 3;
                        }

                        if (min_amount == 0)
                        {
                            amount = Math.Round(max_amount, 2) + " TSBPs";
                        }
                        else
                        {
                            amount = Math.Round(min_amount, 2) + " - " + Math.Round(max_amount, 2) + " TSBPs";
                        }

                        break;
                    }
                case "Broadcast":
                    {
                        //if (MeasurementUnit == "lb/acre")
                        //{
                        if (MinRate == 0)
                        {
                            min_amount = 0;

                        }
                        else
                        {
                            min_amount = (MinRate * area) / 43560;
                        }

                        max_amount = (MaxRate * area) / 43560;
                        //}

                        if (MinRate == 0)
                        {
                            amount = Math.Round(max_amount, 2) + " lb";
                        }
                        else
                        {
                            amount = Math.Round(min_amount, 2) + " - " + Math.Round(max_amount, 2) + " lb ";
                        }
                        break;
                    }
                //case "broadcastimt":
                //    {
                //        amount = (total_area / coverage);
                //        break;
                //    }

            }

            return amount;
        }

        public ProductTreatmentDataView2 GetProductTreatmentInfo3(string polygon_id)
        {
            ProductTreatmentDataView2 PTDV = new ProductTreatmentDataView2();
            List<ProductTreatmentInfo2> products = GetAllProductsTreatmentInfo3(polygon_id);

            PTDV.Products = products;
            System.Diagnostics.Debug.WriteLine("productpdvv=" + PTDV.Products);
            return PTDV;
        }
    }
}