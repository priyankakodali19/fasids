using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.DB;
using WebApplication3.Models.ViewModel;


namespace WebApplication3.Models.EntityManager
{
    public class UserManager
    {
        public void AddUserAccount(UserSignUp user)
        {
            try
            {
                using (FASIDSEntities66 db = new FASIDSEntities66())
                {

                    UserData SU = new UserData();
                    SU.UserId = Guid.NewGuid().ToString().Substring(0, 8);
                    SU.UserName = user.UserName;
                    SU.Password = user.Password;
                    SU.FirstName = user.FirstName;
                    SU.LastName = user.LastName;
                    SU.EmailId = user.EmailId;
                    SU.UserCategory = user.UserCategory;

                    db.UserDatas.Add(SU);
                    db.SaveChanges();

                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"c:\temp\errors.txt", outputLines);

            }
        }

        public bool IsLoginNameExist(string loginName)
        {
            using (FASIDSEntities66 db = new FASIDSEntities66())
            {
                return db.UserDatas.Where(o => o.UserName.Equals(loginName)).Any();
            }
        }

        public string GetUserPassword(string loginName)
        {
            using (FASIDSEntities66 db = new FASIDSEntities66())
            {
                var user = db.UserDatas.Where(o => o.UserName.ToLower().Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().Password;
                else
                    return string.Empty;
            }
        }

        public string GetUserID(string loginName)
        {
            using (FASIDSEntities66 db = new FASIDSEntities66())
            {
                var user = db.UserDatas.Where(o => o.UserName.Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().UserId;
            }
            return null;
        }
        public string GetUserRole(string user_name)
        {
            string user_id = GetUserID(user_name);
            using (FASIDSEntities66 db = new FASIDSEntities66())
            {
                var user = db.UserDatas.Where(o => o.UserId.Equals(user_id));
                if (user.Any())
                    return user.FirstOrDefault().UserCategory;
            }
            return "user";
        }

        public UserProfileView GetUserDataView(string loginName)
        {
            UserProfileView UPV = new UserProfileView();

            string userID = GetUserID(loginName);
            System.Diagnostics.Debug.WriteLine("useris=" + userID);
            using (FASIDSEntities66 db = new FASIDSEntities66())
            {
                var user = db.UserDatas.Where(o => o.UserId.Equals(userID));
                if (user.Any())
                    UPV.EmailId = user.FirstOrDefault().EmailId;
                UPV.FirstName = user.FirstOrDefault().FirstName;
                UPV.LastName = user.FirstOrDefault().LastName;
                UPV.UserName = user.FirstOrDefault().UserName;
                UPV.UserCategory = user.FirstOrDefault().UserCategory;
                UPV.UserId = user.FirstOrDefault().UserId;

            }
            System.Diagnostics.Debug.WriteLine("userpv=" + UPV.FirstName);
            return UPV;
        }

        public int UpdateUserAccount(UserProfileView user)
        {
            int count = 0;
            using (FASIDSEntities66 db = new FASIDSEntities66())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        UserData SU = db.UserDatas.Find(user.UserId);
                        SU.UserName = user.UserName;
                        SU.FirstName = user.FirstName;
                        SU.LastName = user.LastName;
                        SU.EmailId = user.EmailId;
                        SU.UserCategory = user.UserCategory;
                        System.Diagnostics.Debug.WriteLine("userpv=");
                        db.SaveChanges();
                        dbContextTransaction.Commit();
                        count++;
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return count;
        }

        public int UpdateUserPassword(UserProfileView user, string user_name)
        {
            int count = 0;
            System.Diagnostics.Debug.WriteLine("usernewpv=" + user.NewPassword);
           // int user_id = GetUserID(user_name);
            string user_id = GetUserID(user_name);
            using (FASIDSEntities66 db = new FASIDSEntities66())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        UserData SU = db.UserDatas.Find(user_id);
                        if (user.OldPassword.Equals(SU.Password))
                        {
                            SU.Password = user.NewPassword;
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                            count = 1;
                        }
                        
                        System.Diagnostics.Debug.WriteLine("userpv=");
                        
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return count;
        }

        public bool IsUserInRole(string loginName, string roleName) {  
            using (FASIDSEntities66 db = new FASIDSEntities66()) {
               
                var user = db.UserDatas.Where(o => o.UserName.Equals(loginName));
                var x = loginName;
                var y = roleName;
                var z = user;
                if (user.Any()) {
                    var roles = db.UserDatas.Where(o => o.UserCategory.Equals(roleName));
                    if (roles.Any()) {
                        return roles.Any();
                    }
                }

                return false;
            }
        }

        public List<UserSavedPolygonsInfo> GetUserSavedPolygonsInfo(string UserId)
        {
            List<UserSavedPolygonsInfo> polygons = new List<UserSavedPolygonsInfo>();

            using (FASIDSEntities66 db = new FASIDSEntities66())
            {
                UserSavedPolygonsInfo PI;
                var user_polygons = db.NewPolygonGeoJsons.Where(o => o.UserId.Equals(UserId));
               
                if(user_polygons.Any()){
                    foreach (NewPolygonGeoJson u in user_polygons)
                    {
                        PI = new UserSavedPolygonsInfo();
                        PI.GeoJsonId = u.GeoJsonId;
                        PI.PolygonName = u.PolygonName;
                        polygons.Add(PI);
                    }
                }
            }
            return polygons;
        }

        public UserSavedPolygonsView GetUserSavedPolygonsView(string UserName)
        {
            string UserId = "";
            UserId = GetUserID(UserName);
            UserSavedPolygonsView USDV = new UserSavedPolygonsView();
            List<UserSavedPolygonsInfo> polygons = GetUserSavedPolygonsInfo(UserId);

            USDV.UserPolygons = polygons;
            return USDV;
        }

        public int ResetForgotPassword(string EmailId, string password)
        {
            int count = 0;
            using (FASIDSEntities66 db = new FASIDSEntities66())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var user = db.UserDatas.Where(o => o.EmailId.Equals(EmailId));
                        var y = user;
                        if (user.Any())
                        {

                            UserData SU = db.UserDatas.Find(user.FirstOrDefault().UserId);
                            SU.Password = password;
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                            count = 1;

                        }
                    }
                    catch(Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return count;
        }

       
    }
}