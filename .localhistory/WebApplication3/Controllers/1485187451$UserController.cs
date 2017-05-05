﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Models.ViewModel;
using WebApplication3.Models.EntityManager;
using WebApplication3.Security; 

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

            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        public PartialViewResult UserAccountSecurity()
        {
            System.Diagnostics.Debug.WriteLine("usernew2pvshello");
            return PartialView();
        }
        /*
        [HttpPost]
        public PartialViewResult UserAccountSecurity(ResetPassword user)
        {
            System.Diagnostics.Debug.WriteLine("usernew2pv="+user.ConfirmNewPassword);
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserPassword(user);
                ViewBag.Status = "Password Update Sucessful!";
                return PartialView();
            }
            return PartialView();
        }
        */

        [AuthorizeRoles("admin")]
        public ActionResult AdminOnly()
        {
            return View();
        }

        public ActionResult UnAuthorized()
        {
            return View();
        }

    }
}