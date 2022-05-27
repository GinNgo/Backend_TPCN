using System.Collections.Generic;
using WebSiteBanThucPhamCN.Data;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Services
{
    public class Pro_Map_CatSv
    {
        Pro_Map_CatDb pro_Map_CatDb = new Pro_Map_CatDb();
        public List<TblProMappingCat> GetCatByProductId(int Id)
        {
            return pro_Map_CatDb.GetCatByProductId(Id);
        }
        public bool CreateProMappingCat(TblProMappingCat tblProMappingCat)
        {
            return pro_Map_CatDb.CreateProMappingCat(tblProMappingCat);
        }
        public bool UpdateProMappingCat(TblProMappingCat tblProMappingCat)
        {
            return pro_Map_CatDb.UpdateProMappingCat(tblProMappingCat);
        }
        public bool DeleteProMappingCat(int Id)
        {
            return pro_Map_CatDb.DeleteProMappingCat(Id);
        }
    }
}
