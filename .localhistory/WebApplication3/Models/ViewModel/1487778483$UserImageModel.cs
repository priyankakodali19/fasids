using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.ViewModel
{
    public class UserImageModel
    {
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public byte[] ImageData { get; set; }
    }
}