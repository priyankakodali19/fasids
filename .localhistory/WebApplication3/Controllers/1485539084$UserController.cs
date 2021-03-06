﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Models.ViewModel;
using WebApplication3.Models.EntityManager;
using WebApplication3.Security;
using System.Web.Helpers;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {


        // GET: User
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserSignUp USV)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                if (!UM.IsLoginNameExist(USV.UserName))
                {
                    UM.AddUserAccount(USV);
                    FormsAuthentication.SetAuthCookie(USV.UserName, false);
                    return RedirectToAction("Index", "Home");

                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(UserSignIn ULV, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                string password = UM.GetUserPassword(ULV.UserName);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "User name does not exist");
                else
                {
                    if (ULV.Password.Equals(password))
                    {
                        Session["UserName"] = ULV.UserName;
                        FormsAuthentication.SetAuthCookie(ULV.UserName, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password provided is incorrect");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(ULV);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserAccount()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                string loginName = User.Identity.Name;

                UserManager UM = new UserManager();
                UserProfileView UPV = UM.GetUserDataView(loginName);
                return View(UPV);
            }
            return View();
        }

        [HttpPost]
        public ActionResult UserAccount(UserProfileView profile)
        {

           
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                TempData["Message"] = "Update Sucessful!";
            
            return View(profile);
        }

        //public ActionResult UserAccountSecurity()
        //{

        //    return View();
        //}

        [HttpPost]
        public ActionResult UserAccountSecurity(UserProfileView RP)
        {
            int x = 0;
            string user_name = User.Identity.Name;
            UserManager UM = new UserManager();
            x= UM.UpdateUserPassword(RP, user_name);

            if (x == 1)
            {
                TempData["Value"] = 0;
                return RedirectToAction("SignIn", "User");
            }
            else
            {
                TempData["Value"] = 1;
                TempData["Message"] = "Password not Updated Sucessfully!";
                return RedirectToAction("UserAccount", "User");
            }
       
        }
        
        
        [AuthorizeRoles("user")]
        public ActionResult AdminOnly()
        {
            return View();
        }

        public ActionResult UnAuthorized()
        {
            return View();
        }

        [AuthorizeRoles("user")]
        public ActionResult UserDashboard()
        {
            string UserName = "";
            UserManager UM = new UserManager();

            if (User.Identity.IsAuthenticated)
            {
                UserName = User.Identity.Name;
            }
            UserSavedPolygonsView USDV = UM.GetUserSavedPolygonsView(UserName);
            return View(USDV);
        }

         [AuthorizeRoles("user")]
        public ActionResult DeleteDashboardPolygon()
        {
            string path = System.Web.HttpContext.Current.Request.Url.PathAndQuery;
            string polygonId = path.Substring(path.LastIndexOf("/") + 1);
            string x = polygonId;
            InteractiveLandscapeManager ILM = new InteractiveLandscapeManager();
            ILM.DeleteUserPolygon(x);
            return RedirectToAction("UserDashboard", "User");
        }

         public ActionResult ForgotPassword()
         {
             return View();
         }

    }
}