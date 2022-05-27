using System.Collections.Generic;
using WebSiteBanThucPhamCN.Data;
using WebSiteBanThucPhamCN.Models;
namespace WebSiteBanThucPhamCN.Services
{
    public class ImageSv
    {
        ImageDb Image = new ImageDb();
        public List<TblImage> GetAllImage()
        {
            return Image.GetAllImage();
        }
        public List<TblImage> GetAllImage(int id)
        {
            return Image.GetImageById(id);
        }
        public bool CreateImage(TblImage image)
        {
           return Image.CreateImage(image);
        }
        
                public bool UpdateImage(TblImage image)
        {
            return Image.UpdateImage(image);
        }
        public bool DeleteImage(int image)
        {
            return Image.DeleteImage(image);
        }
    }
}
