using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Data
{
    public class ImageDb
    {
        WebsiteBanThucPhamCNContext context = new WebsiteBanThucPhamCNContext();
        public List<TblImage> GetAllImage()
        {

            List<TblImage> ListImg = new List<TblImage>();

            var ListImgDB = context.TblImage.ToList();
            TblImage product = new TblImage();


            ListImgDB.ForEach(e =>
            {
                TblImage imageBo = new TblImage();
                imageBo.Id = e.Id;
                imageBo.ProuctId = e.ProuctId;
                imageBo.Title = e.Title;
                imageBo.ImageName = e.ImageName;
                imageBo.DisplayOrder = e.DisplayOrder;

                ListImg.Add(imageBo);
            });



            return ListImg;
        }
        public List<TblImage> GetImageById(int id)
        {

            List<TblImage> ListImg = new List<TblImage>();

            var ListImgDB = context.TblImage.Where(e => e.ProuctId == id).ToList();
            TblImage product = new TblImage();


            ListImgDB.ForEach(e =>
            {
                TblImage imageBo = new TblImage();
                imageBo.Id = e.Id;
                imageBo.ProuctId = e.ProuctId;
                imageBo.Title = e.Title;
                imageBo.ImageName = e.ImageName;
                imageBo.DisplayOrder = e.DisplayOrder;

                ListImg.Add(imageBo);
            });



            return ListImg;
        }
        public bool CreateImage(TblImage image)
        {
            try
            {


                context.TblImage.Add(image);
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateImage(TblImage image)
        {
            try
            {

                context.Entry(image).State = EntityState.Modified;

                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteImage(int Id)
        {
            try
            {
                TblImage image = context.TblImage.Where(e => e.Id == Id).FirstOrDefault();

                context.Entry(image).State = EntityState.Deleted;
                context.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
   
}
}
