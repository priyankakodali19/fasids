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
    public class InteractiveLandscapeController : Controller
    {
        // GET: InteractiveLandscape
        public ActionResult LandscapeManagement(string id)
        {
            if (id != null)
            {
               
               // ViewBag.message = id;
                InteractiveLandscapeManager ILM = new InteractiveLandscapeManager();
                DisplayUserPolygon2 DUP = ILM.GetUserDataView(id);
                return View(DUP);
            }
            else
            {
                ViewBag.message = 0;
            }
            return View(new DisplayUserPolygon2());
        }

        

        
        public ActionResult Instructions()
        {
            return View();
        }

      /*  public ActionResult Treatment(string id)
        {
            if (id != null)
            {
                ViewBag.message = id;
                InteractiveLandscapeManager ILM = new InteractiveLandscapeManager();
                DisplayUserPolygon DUP = ILM.GetUserDataView(id);
                return View(DUP);
            }
            else
            {
                ViewBag.message = 0;
            }
            return View(new DisplayUserPolygon());
        }*/
       
        [HttpPost]
        public string SavePolygon(String UserPolygonJson, String edit)
        {
           

            System.Diagnostics.Debug.WriteLine("userpv=" + UserPolygonJson);
            //var PolygonObject = JSON.parse(UserPolygonJson);

            if (ModelState.IsValid)
            {
                InteractiveLandscapeManager ILM = new InteractiveLandscapeManager();
                UserManager UM = new UserManager();
                int UserId = UM.GetUserID(User.Identity.Name);

                if (edit != "LandscapeManagement")
                { 
                    ILM.DeleteUserPolygon(edit);
                }
                
                string PolygonId = ILM.AddUserPolygon(UserPolygonJson, UserId);
                return PolygonId;
            }
            return "not succesful";
        }

        //[AuthorizeRoles("user")]
        //public ActionResult Treatment(String PolygonId)
        //{
        //    string path = System.Web.HttpContext.Current.Request.Url.PathAndQuery;
        //    string polygonId = path.Substring(path.LastIndexOf("/") + 1);
        //    string x = polygonId;

        //    InteractiveLandscapeManager ILM = new InteractiveLandscapeManager();
        //    ProductTreatmentDataView PTD = ILM.GetProductTreatmentInfo(polygonId);
        //    DisplayUserPolygon2 DUP = ILM.GetUserDataView(polygonId);
        //    ViewBag.TypeOfUse = DUP.TypeOfUse;
        //    ViewBag.ControlMethod = DUP.ControlMethod;
        //    ViewBag.TotalArea = Math.Round(DUP.TotalArea, 3);
        //    ViewBag.Usage = DUP.Usage;
        //    return View(PTD);

        //}

        //[AuthorizeRoles("user")]
        //public ActionResult PolygonDisplayPartial()
        //{
        //    string path = System.Web.HttpContext.Current.Request.Url.PathAndQuery;
        //    string polygonId = path.Substring(path.LastIndexOf("/") + 1);
        //    string x = polygonId;
        //    InteractiveLandscapeManager ILM = new InteractiveLandscapeManager();
        //    DisplayUserPolygon DUP = ILM.GetUserDataView(polygonId);
        //    return PartialView("PolygonDisplayPartial", DUP);
        //}

        [AuthorizeRoles("user")]
        public ActionResult Treatment(String PolygonId)
        {
            string path = System.Web.HttpContext.Current.Request.Url.PathAndQuery;
            string polygonId = path.Substring(path.LastIndexOf("/") + 1);
            string x = polygonId;

            InteractiveLandscapeManager ILM = new InteractiveLandscapeManager();
            ProductTreatmentDataView2 PTD = ILM.GetProductTreatmentInfo2(polygonId);
            DisplayUserPolygon2 DUP = ILM.GetUserDataView(polygonId);
            ViewBag.TypeOfUse = DUP.TypeOfLand;
            ViewBag.ControlMethod = DUP.TypeOfControlMethod;
            ViewBag.TotalArea = Math.Round(DUP.TotalArea, 3);
            ViewBag.Usage = DUP.Usage;
            return View(PTD);

        }

        [AuthorizeRoles("user")]
        public ActionResult PolygonDisplayPartial()
        {
            string path = System.Web.HttpContext.Current.Request.Url.PathAndQuery;
            string polygonId = path.Substring(path.LastIndexOf("/") + 1);
            string x = polygonId;
            InteractiveLandscapeManager ILM = new InteractiveLandscapeManager();
            DisplayUserPolygon2 DUP = ILM.GetUserDataView(polygonId);
            return PartialView("PolygonDisplayPartial", DUP);
        }

        [AuthorizeRoles("user")]
        public ActionResult DeletePolygon(String PolygonId)
        {
            
            InteractiveLandscapeManager ILM = new InteractiveLandscapeManager();
            ILM.DeleteUserPolygon(PolygonId);
            return Json(new { success = true });
        }

       

        public ActionResult UnAuthorized()
        {
           
            return RedirectToAction("LandscapeManagement", "InteractiveLandscape");
        }

        
        public int CheckUserLogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return 1 ;
            }
            else
                return 0;
        }

        
    }
}