using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.ViewModel;
using System.Xml.Linq;
using System.Net;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult OfficialBlog()
        {
            WebClient wclient = new WebClient();
            string RSSData = wclient.DownloadString("http://articles.extension.org/feeds/content/fire%20ants");

            XDocument xml = XDocument.Parse(RSSData);
            var RSSFeedData = (from x in xml.Descendants("item")
                               select new RSSFeedModel
                               {
                                   Title = ((string)x.Element("title")),
                                   Link = ((string)x.Element("link"))
                            
                               });
            ViewBag.RSSFeed = RSSFeedData;
            ViewBag.URL = RSSURL;
            return View();
        }

        public ActionResult AntActivity()
        {
            return View();
        }

        public ActionResult QA()
        {
            return View();
        }


        public ActionResult AntDistribution()
        {
            return View();
        }






    }
}