using System.Collections.Generic;
using WebSiteBanThucPhamCN.Data;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Services
{
    public class BrandSv
    {
        public readonly BrandDb brandDb = new BrandDb();
        public List<TblBrand> GetBrand()
        {
            return brandDb.GetBrand();
        }
        public TblBrand GetBrandById(int id)
        {
            return brandDb.GetBrandById(id);
        }

        public List<TblBrand> GetBrandByName(string BrandName)
        {
            return brandDb.GetBrandByName(BrandName);
        }
        public List<TblBrand> GetBrandByNameTrash(string BrandName)
        {
            return brandDb.GetBrandByNameTrash(BrandName);
        }
        public List<TblBrand> GetTrashBrand()
        {
            return brandDb.GetTrashBrand();
        }
        public bool CreateBrand(TblBrand brand)
        {
            return brandDb.CreateBrand(brand);
        }

        public bool Put(TblBrand TblBrand)
        {
            return brandDb.Put(TblBrand);
        }
        public bool Delete(int id)
        {
            return brandDb.Delete(id);
        }
    }
}
