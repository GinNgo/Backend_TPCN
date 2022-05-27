using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebSiteBanThucPhamCN.Models;
using WebSiteBanThucPhamCN.Services;

namespace WebSiteBanThucPhamCN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Pro_Map_CatController : ControllerBase
    {
        Pro_Map_CatSv Pro_Map_CatSv = new Pro_Map_CatSv();
        [HttpGet("{id}")]
        public List<TblProMappingCat> GetCatByProductId(int Id)
        {
            List<TblProMappingCat> tblProMappingCats = Pro_Map_CatSv.GetCatByProductId(Id);
            return tblProMappingCats;
        }
        [HttpPut("{tblProMappingCat}")]
        public bool UpdateProMappingCat(TblProMappingCat tblProMappingCat)
        {
            return Pro_Map_CatSv.UpdateProMappingCat(tblProMappingCat);
        }
        [HttpPost("{ProMappingCat}")]
        public bool CreateProMappingCat(TblProMappingCat ProMappingCat)
        {
            return Pro_Map_CatSv.CreateProMappingCat(ProMappingCat);
        }

        [HttpDelete("{CatId}")]
        public bool DeleteProMappingCat(int CatId)
        {
            return Pro_Map_CatSv.DeleteProMappingCat(CatId);
        }
    }
}
