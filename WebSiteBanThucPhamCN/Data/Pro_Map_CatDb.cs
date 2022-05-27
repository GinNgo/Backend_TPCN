using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Data
{
    public class Pro_Map_CatDb
    {
        WebsiteBanThucPhamCNContext context = new WebsiteBanThucPhamCNContext();

        public List<TblProMappingCat> GetCatByProductId(int Id)
        {
            List<TblProMappingCat> tblProMappingCat = new List<TblProMappingCat>();
            tblProMappingCat = context.TblProMappingCat.Where(e => e.ProductId == Id).ToList();
            return tblProMappingCat;
        }

        public bool CreateProMappingCat(TblProMappingCat tblProMappingCat)
        {
            try
            {


                context.TblProMappingCat.Add(tblProMappingCat);
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProMappingCat(TblProMappingCat tblProMappingCat)
        {
            try
            {

                context.Entry(tblProMappingCat).State = EntityState.Modified;

                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteProMappingCat(int Id)
        {
            try
            {
                List<TblProMappingCat> tblProMappingCats = context.TblProMappingCat.ToList();
                tblProMappingCats.ForEach(e =>
                {
                    if (e.ProductId == Id)
                    {
                        context.Entry(e).State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                });
 

             

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
