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
        public string connectionString = ".\\SQLEXPRESS; Initial-Catalog=FASIDS; Integrated-Security=true";
        public string AddUserPolygon(String polygonJson)
        {

            using (FASIDSEntities4 db = new FASIDSEntities4())
            {

                PolygonGeoJson PG = new PolygonGeoJson();
                dynamic dynObj = JsonConvert.DeserializeObject(polygonJson);
                System.Diagnostics.Debug.WriteLine("userpv=" + polygonJson);


                string xyz = Guid.NewGuid().ToString().Substring(0, 8); ;
                PG.UserId = 1;
                PG.GeoJsonId = xyz;
                PG.Type = dynObj.type;
                PG.GeometryType = dynObj.geometry.type;
                PG.PolygonName = dynObj.properties.polygon_name;
                PG.Address = dynObj.properties.address;
                PG.Bounds_NE_Lng = dynObj.properties.bounds.ne.lng;
                PG.Bounds_NE_Lat = dynObj.properties.bounds.ne.lat;
                PG.Bounds_SW_Lat = dynObj.properties.bounds.sw.lat;
                PG.Bounds_SW_Lng = dynObj.properties.bounds.sw.lng;
                PG.ControlMethod = dynObj.properties.control_method;
                PG.EnvMapTypeId = dynObj.properties.environment_map.MapTypeId;
                PG.EnvMapTilt = dynObj.properties.environment_map.tilt;
                PG.IsOutdoor = dynObj.properties.is_outdoor;
                PG.MoundDensity = dynObj.properties.mound_density;
                PG.MoundNumber = dynObj.properties.mound_number;
                PG.NeedOrganic = dynObj.properties.need_organic;
                PG.NeedSafeForPets = dynObj.properties.need_safe_for_pets;
                PG.Notes = dynObj.properties.notes;
                PG.TotalArea = dynObj.properties.total_area;
                PG.TypeOfUse = dynObj.properties.type_of_use;
                PG.Usage = dynObj.properties.usage;

                dynamic x = JsonConvert.SerializeObject(polygonJson);

                dynamic z = JsonConvert.SerializeObject(dynObj.geometry.coordinates);

                dynamic y = x;
                dynamic mic = z;
                var sb = new StringBuilder();

                sb.Append(@"POLYGON((");
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
                sb.Append(@"))");
                PG.Coordinates = DbGeometry.PolygonFromText(sb.ToString(), 4326);

                db.PolygonGeoJsons.Add(PG);
                db.SaveChanges();

                return PG.GeoJsonId;


            }
        }

        public int IsGeoJsonIdExist(int id)
        {
            var flag = 0;

            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                if (db.PolygonGeoJsons.Where(o => o.GeoJsonId.Equals(id)).Any())
                {
                    flag = 1;
                }
            }
            return flag;
        }

        public DisplayUserPolygon GetUserDataView(string polygonid)
        {
            DisplayUserPolygon DUP = new DisplayUserPolygon();
            DUP.coordinates_str = "";
            // int userID = GetUserID(loginName);
            System.Diagnostics.Debug.WriteLine("useris=" + polygonid);
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                var polygon = db.PolygonGeoJsons.Where(o => o.GeoJsonId.Equals(polygonid));
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
                    DUP.ControlMethod = polygon.FirstOrDefault().ControlMethod;
                    DUP.EnvMapTypeId = polygon.FirstOrDefault().EnvMapTypeId;
                    DUP.EnvMapTilt = polygon.FirstOrDefault().EnvMapTilt;
                    DUP.IsOutdoor = Convert.ToBoolean(polygon.FirstOrDefault().IsOutdoor);
                    DUP.MoundDensity = Convert.ToDecimal(polygon.FirstOrDefault().MoundDensity);
                    DUP.MoundNumber = Convert.ToInt32(polygon.FirstOrDefault().MoundNumber);
                    DUP.NeedOrganic = Convert.ToBoolean(polygon.FirstOrDefault().NeedOrganic);
                    DUP.NeedSafeForPets = Convert.ToBoolean(polygon.FirstOrDefault().NeedSafeForPets);
                    DUP.Notes = polygon.FirstOrDefault().Notes;
                    DUP.TotalArea = Convert.ToDouble(polygon.FirstOrDefault().TotalArea);
                    DUP.TypeOfUse = polygon.FirstOrDefault().TypeOfUse;
                    DUP.Usage = polygon.FirstOrDefault().Usage;
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
       

        public ProductTreatmentInfo GetProductTreatmentInfo(string polygonid)
        {
            ProductTreatmentInfo PTI = new ProductTreatmentInfo();
          
            using (FASIDSEntities4 db = new FASIDSEntities4())
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
                        PTI.ProductControlMethod = polygon.FirstOrDefault().ProductControlMethod;
                    }
                }

                
            }
            return PTI;
        }

    }
}