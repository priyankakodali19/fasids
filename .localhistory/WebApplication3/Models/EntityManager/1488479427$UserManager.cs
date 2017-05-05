﻿using System;
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

            using (FASIDSEntities4 db = new FASIDSEntities4())
            {

                UserData SU = new UserData();
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

        public bool IsLoginNameExist(string loginName)
        {
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                return db.UserDatas.Where(o => o.UserName.Equals(loginName)).Any();
            }
        }

        public string GetUserPassword(string loginName)
        {
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                var user = db.UserDatas.Where(o => o.UserName.ToLower().Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().Password;
                else
                    return string.Empty;
            }
        }

        public int GetUserID(string loginName)
        {
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                var user = db.UserDatas.Where(o => o.UserName.Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().UserId;
            }
            return 0;
        }

        public UserProfileView GetUserDataView(string loginName)
        {
            UserProfileView UPV = new UserProfileView();

            int userID = GetUserID(loginName);
            System.Diagnostics.Debug.WriteLine("useris=" + userID);
            using (FASIDSEntities4 db = new FASIDSEntities4())
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
            using (FASIDSEntities4 db = new FASIDSEntities4())
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
            int user_id = GetUserID(user_name);
            using (FASIDSEntities4 db = new FASIDSEntities4())
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
            using (FASIDSEntities4 db = new FASIDSEntities4()) {
               
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

        public List<UserSavedPolygonsInfo> GetUserSavedPolygonsInfo(int UserId)
        {
            List<UserSavedPolygonsInfo> polygons = new List<UserSavedPolygonsInfo>();

            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                UserSavedPolygonsInfo PI;
                var user_polygons = db.PolygonGeoJsons.Where(o => o.UserId.Equals(UserId));
               
                if(user_polygons.Any()){
                    foreach (PolygonGeoJson u in user_polygons)
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
            int UserId = 0;
            UserId = GetUserID(UserName);
            UserSavedPolygonsView USDV = new UserSavedPolygonsView();
            List<UserSavedPolygonsInfo> polygons = GetUserSavedPolygonsInfo(UserId);

            USDV.UserPolygons = polygons;
            return USDV;
        }

        public int ResetForgotPassword(string EmailId, string password)
        {
            int count = 0;
            using (FASIDSEntities4 db = new FASIDSEntities4())
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