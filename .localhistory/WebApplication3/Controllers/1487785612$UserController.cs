using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Models.ViewModel;
using WebApplication3.Models.EntityManager;
using WebApplication3.Security;
using System.Net.Mail;
using WebApplication3.Models.DB;


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
            ViewBag.message = TempData["Id"];
            return View();
        }
        public ActionResult Timeout()
        {
            TempData["Id"] = 1;
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
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
            int count= UM.UpdateUserAccount(profile);

            if (count == 1)
            {
                TempData["Message"] = "Account Updated Sucessfully!";
            }
            else
            {
                TempData["Message"] = "Error: Account not updated. Please try again!";
            }

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
                FormsAuthentication.SignOut();
                return RedirectToAction("SignIn", "User");
            }
            else
            {
                TempData["Value"] = 1;
                TempData["Message"] = "Error: Password not updated. Please try again!";
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
         public ActionResult ForgotPassword(UserProfileView UPV)
         {
             string x2 = UPV.EmailId;
             string y = x2;
             
                 string reset_password = Guid.NewGuid().ToString().Substring(0, 8); ;
                 UserManager UM = new UserManager();
                 string username=User.Identity.Name;
                 int result = UM.ResetForgotPassword(UPV.EmailId, reset_password);

                 int x = result;

                 if (result == 1)
                 {

                     MailMessage mail = new MailMessage();
                     mail.To.Add(UPV.EmailId);
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
                     FormsAuthentication.SignOut();
                     return RedirectToAction("ResetForgotPassword", "User");
                 }
                 else
                 {
                     ViewBag.Message = "Email Id does not exist. Please re-enter the email id"; 
                     return View();
                 }
           
         }

         public ActionResult ResetForgotPassword()
         {
             return View();
         }

         public ActionResult UserImage()
         {
             return PartialView();
         }

        [HttpPost]
         public ActionResult UserImage(UserImageModel img, HttpPostedFileBase file)
         {
             if (ModelState.IsValid)
             {
                 if (file != null)
                 {
                     file.SaveAs(HttpContext.Server.MapPath("~/UserImages/")
                                                           + file.FileName);
                     img.ImagePath = file.FileName;
                 }
                 using (FASIDSEntities4 db = new FASIDSEntities4())
                 {
                     UserManager UM = new UserManager();
                     UserImage UI = new UserImage();
                     int user_id = UM.GetUserID(User.Identity.Name);
                     UI.UserId = user_id;
                     UI.ImagePath = img.ImagePath;
                     string xyz = Guid.NewGuid().ToString().Substring(0, 8);
                     UI.ImageId = xyz;

                     db.UserImages.Add(UI);
                     db.SaveChanges();
                     
                 }
             }
             return View(img);
         }
    }
}