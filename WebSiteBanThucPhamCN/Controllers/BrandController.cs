using Microsoft.AspNetCore.Http;
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
    public class BrandController : ControllerBase
    {
        BrandSv Brand = new BrandSv();
        WebsiteBanThucPhamCNContext context = new WebsiteBanThucPhamCNContext();
        [HttpGet("getBrand")]
        public IEnumerable GetBrand()
        {
            List<TblBrand> brands = new List<TblBrand>();
            brands = Brand.GetBrand();
            return brands.ToList();
        }
        [HttpGet("getBrandById/{Tid}")]
        public TblBrand GetBrandById(int Tid)
        {
            return Brand.GetBrandById(Tid);  
        }
        [HttpGet("getBrandByName/{BrandName}")]
        public IEnumerable GetBrandByName(string BrandName)
        {
            return Brand.GetBrandByName(BrandName);
        }
        [HttpGet("getTrashBrandByName/{BrandNameTrash}")]
        public IEnumerable GetBrandByNameTrash(string BrandNameTrash)
        {
            return Brand.GetBrandByNameTrash(BrandNameTrash);
        }
        [HttpGet("getTrashBrand")]
        public IEnumerable GetTrashBrand()
        {
            List<TblBrand> brands = new List<TblBrand>();
            brands = Brand.GetTrashBrand();
            return brands.ToList();
        }
        [HttpPost("{brand}")]
              
        public bool CreateBrand(TblBrand brand)
        {
            return Brand.CreateBrand(brand);
        }
        [HttpPut("{Tbrand}")]
        public bool Put(TblBrand Tbrand)
        {
            return Brand.Put(Tbrand);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return Brand.Delete(id);
        }
    }
}
