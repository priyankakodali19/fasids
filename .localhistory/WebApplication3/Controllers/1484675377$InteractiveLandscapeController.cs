using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Models.ViewModel;
using WebApplication3.Models.EntityManager;

namespace WebApplication3.Controllers
{
    public class InteractiveLandscapeController : Controller
    {
        // GET: InteractiveLandscape
        public ActionResult LandscapeManagement(string id)
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
        }


        public ActionResult Instructions()
        {
            return View();
        }

        public ActionResult Treatment(string id)
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
        }

        [HttpPost]
        public string SavePolygon(String UserPolygonJson)
        {

            System.Diagnostics.Debug.WriteLine("userpv=" + UserPolygonJson);
            //var PolygonObject = JSON.parse(UserPolygonJson);

            if (ModelState.IsValid)
            {
                InteractiveLandscapeManager ILM = new InteractiveLandscapeManager();

                string PolygonId = ILM.AddUserPolygon(UserPolygonJson);
                return PolygonId;
            }
            return "not succesful";
        }

        [HttpPost]
        public string PolygonTreatment(String PolygonId)
        {

           // System.Diagnostics.Debug.WriteLine("userpv=" + UserPolygonJson);
            //var PolygonObject = JSON.parse(UserPolygonJson);

            if (ModelState.IsValid)
            {
                InteractiveLandscapeManager ILM = new InteractiveLandscapeManager();

                DisplayUserPolygon DUP = ILM.GetUserDataView(PolygonId);
                return PolygonId;
            }
            return "not succesful";
        }
    }
}