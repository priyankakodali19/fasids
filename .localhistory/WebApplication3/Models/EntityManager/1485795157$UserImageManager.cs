using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.DB;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Models.EntityManager
{
    public class UserImageManager
    {
        public int UploadImageInDataBase(HttpPostedFileBase file, UserImageModel contentViewModel, string user_name) 
        {
            contentViewModel.ImageData = ConvertToBytes(file);
            
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                UserImageModel UIM = new UserImageModel();
                UIM.UserId = contentViewModel.UserId;
                UIM.ImageData=contentViewModel.ImageData;
                UIM.ImageId = 1;

                db.UserImages.Add(UIM);
                int i = db.SaveChanges();
            }
            
            if (i == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}