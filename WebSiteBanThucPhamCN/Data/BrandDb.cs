using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Data
{
    public class BrandDb
    {
        WebsiteBanThucPhamCNContext context = new WebsiteBanThucPhamCNContext();
        public List<TblBrand> GetBrand()
        {
            List<TblBrand> tblBrands = new List<TblBrand>();
            tblBrands = context.TblBrand.Where(e=>e.IsDeleted==false).OrderByDescending(e=>e.BrandId).ToList();
            return tblBrands;
        }
        public TblBrand GetBrandById(int id)
        {
            TblBrand tblBrands = new TblBrand();
            tblBrands = context.TblBrand.Where(e=>e.BrandId==id).FirstOrDefault();
            return tblBrands;
        }
        public List<TblBrand> GetBrandByName(string name)
        {

            List<TblBrand> ListPro = new List<TblBrand>();

            var ListProListDb = context.TblBrand.Where(e => e.Status == true &&e.IsDeleted==false && e.BrandName.Contains(name)).ToList();
            ListPro = ListProListDb;


            return ListProListDb;
        }
        public List<TblBrand> GetBrandByNameTrash(string name)
        {

            List<TblBrand> ListPro = new List<TblBrand>();

            var ListProListDb = context.TblBrand.Where(e => e.IsDeleted==true && e.BrandName.Contains(name)).ToList();
            ListPro = ListProListDb;


            return ListProListDb;
        }

        public List<TblBrand> GetTrashBrand()
        {
            List<TblBrand> tblBrands = new List<TblBrand>();
            tblBrands = context.TblBrand.Where(e => e.IsDeleted==true).ToList();
            return tblBrands;
        }
        public bool CreateBrand(TblBrand brand)
        {
            try
            {


                context.TblBrand.Add(brand);
                context.SaveChanges();


                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Put(TblBrand TblBrand)
        {
            try
            {

               
                context.Entry(TblBrand).State = EntityState.Modified;

                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int Id)
        {
            try
            {
                TblBrand tbl = context.TblBrand.Where(e => e.BrandId == Id).FirstOrDefault();

                context.Entry(tbl).State = EntityState.Deleted;
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
