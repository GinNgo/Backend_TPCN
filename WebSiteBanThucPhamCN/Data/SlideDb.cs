using System.Collections.Generic;
using System.Linq;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Data
{
    public class SlideDb
    {
        WebsiteBanThucPhamCNContext context = new WebsiteBanThucPhamCNContext();
        public List<TblSlide> GetAllSlide()
        {
            List<TblSlide> ListSlideBO = new List<TblSlide>();
            var ListSlideDB = context.TblSlide.Where(e => e.Status == true).ToList();
            ListSlideDB.ForEach(e =>
            {
                TblSlide slideBO = new TblSlide();
                slideBO.Id = e.Id;
                slideBO.Title = e.Title;
                slideBO.ImageName = e.ImageName;
                slideBO.Status = e.Status;
                slideBO.IsDeleted = e.IsDeleted;
                ListSlideBO.Add(slideBO);

            });
            return ListSlideBO;
        }
    }
}
