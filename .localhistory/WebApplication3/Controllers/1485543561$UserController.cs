﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Models.ViewModel;
using WebApplication3.Models.EntityManager;
using WebApplication3.Security;
using System.Net.Mail;

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

         [HttpPost]
         public ActionResult ForgotPassword(string EmailId)
         {
             string x2 = EmailId;
             string y = x2;
             if (ModelState.IsValid)
             {
                 string reset_password = Guid.NewGuid().ToString().Substring(0, 8); ;
                 UserManager UM = new UserManager();
                 string username=User.Identity.Name;
                 int result = UM.ResetForgotPassword(EmailId, reset_password);

                 int x = result;

                 if (result == 1)
                 {

                     MailMessage mail = new MailMessage();
                     mail.To.Add(EmailId);
                     mail.From = new MailAddress("fasidstamu@gmail.com");
                     mail.Subject = "[FASIDS] Your password has been reset";
                     string Body = "Your request of reseting your password has been processed. Your password is reset as " + reset_password;
                     mail.Body = Body;
                     mail.IsBodyHtml = true;

                     SmtpClient smtp = new SmtpClient();
                     smtp.Host = "smtp.gmail.com";
                     smtp.Port = 587;
                     smtp.UseDefaultCredentials = false;
                     smtp.Credentials = new System.Net.NetworkCredential
                     ("fasidstamu@gmail.com", "fasids_123");// Enter senders User name and password
                     smtp.EnableSsl = true;
                     smtp.Send(mail);

                     return RedirectToAction("ResetForgotPassword", "User");
                 }
                 else
                 {
                     ViewBag.Message = "Email Id does not exist. Please re-enter the email id"; 
                     return View();
                 }
             }
             else
             {
                 ViewBag.Message = "Server Error"; 
                 return View();
             }
         }

         public ActionResult ResetForgotPassword()
         {
             return View();
         }

    }
}