using System.Collections.Generic;
using WebSiteBanThucPhamCN.Data;
using WebSiteBanThucPhamCN.Models;
namespace WebSiteBanThucPhamCN.Services
{
    public class SlideSv
    {
        SlideDb slideDA = new SlideDb();
        public List<TblSlide> GetAllSlide()
        {
            return slideDA.GetAllSlide();
        }
    }
}
