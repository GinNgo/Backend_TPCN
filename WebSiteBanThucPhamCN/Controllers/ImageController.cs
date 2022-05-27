
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebSiteBanThucPhamCN.Models;
using WebSiteBanThucPhamCN.Services;

namespace WebSiteBanThucPhamCN.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        ImageSv Image = new ImageSv();
        
        [HttpGet]
        public IEnumerable GetAllImage()
        {
            List<TblImage> images = new List<TblImage>();
            images = Image.GetAllImage();
            return images.ToList();
        }
        //get one pro
     
        [HttpGet("{id}")]
        public IEnumerable GetImageById(int id)
        {
            List<TblImage> images = new List<TblImage>();
            images = Image.GetAllImage(id);
            return  images.ToList();
        }

        [HttpPost("{imagePost}")]
        public bool CreateImage(TblImage imagePost)
        {
           return Image.CreateImage(imagePost);
        }

        [HttpPut("{imagePut}")]
        public bool UpdateImage(TblImage imagePut)
        {
            return Image.UpdateImage(imagePut);
        }


        [HttpDelete("{image}")]
        public bool DeleteImage(int image)
        { 
            return Image.DeleteImage(image);
        }
    }
}
