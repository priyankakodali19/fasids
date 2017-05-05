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
    public class ImageController : Controller
    {
        
        public ActionResult UserImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadUserImage(UserImageModel model)
        {
          //  string user_name = User.Identity.Name();
            HttpPostedFileBase file = Request.Files["ImageData"];
            UserImageManager UIM = new UserImageManager();
           // int i = UIM.UploadImageInDataBase(file, model,user_name);
            if (i == 1)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        

    }
}
