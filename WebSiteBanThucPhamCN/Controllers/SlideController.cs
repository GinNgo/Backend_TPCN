
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebSiteBanThucPhamCN.Models;
using WebSiteBanThucPhamCN.Services;

namespace WebSiteBanThucPhamCN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlideController : ControllerBase
    {
        SlideSv slide = new SlideSv();
        [HttpGet]
        public IEnumerable GetAllImage()
        {
            List<TblSlide> slides = new List<TblSlide>();
            slides = slide.GetAllSlide();
            return slides.ToList();
        }
    }
}
