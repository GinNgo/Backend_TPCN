using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Data
{
    public class ProductDb
    {

        WebsiteBanThucPhamCNContext context = new WebsiteBanThucPhamCNContext();
        public List<TblProduct> GetAllProduct()
        {
        
            List<TblProduct> ListPro = new List<TblProduct>();

             ListPro = context.TblProduct.Where(e=>e.IsDeleted==false&&e.Status==true).OrderByDescending(e=>e.ProductId ).ToList();



            return ListPro;
        }
        public List<TblProduct> GetAllProductForDashboard()
        {

            List<TblProduct> ListPro = new List<TblProduct>();

            ListPro = context.TblProduct.Where(e => e.IsDeleted == false).OrderByDescending(e => e.ProductId).ToList();



            return ListPro;
        }
        public List<TblProduct> GetAllProductIsTrash()
        {

            List<TblProduct> ListPro = new List<TblProduct>();

            ListPro = context.TblProduct.Where(e => e.IsDeleted == true && e.Status == false).ToList();



            return ListPro;
        }
        public List<string> GetProductName()
        {

            List<string> ListPro = new List<string>();

            var ListProListDb = context.TblProduct.Where(e => e.IsDeleted == false && e.Status == true).Select(e=>e.ProductName).ToList();

            //ListProListDb.ForEach(e =>
            //{
            //    TblProduct TblProduct = new TblProduct();
            //    TblProduct.ProductId = e.ProductId;
            //    TblProduct.ProductName = e.ProductName;
            //    TblProduct.Image = e.Image;
            //    TblProduct.Price = (float)e.Price;
            //    TblProduct.PriceDiscount = (float)e.PriceDiscount;
            //    TblProduct.BrandId = e.BrandId;
            //    TblProduct.Origin = e.Origin;
            //    TblProduct.CategoryId = e.CategoryId;
            //    ListPro.Add(TblProduct);
            //});

            ListPro = ListProListDb;

            return ListPro;
        }
        public List<TblProduct> GetProductByNameList(string name)
        {

            List<TblProduct> ListPro = new List<TblProduct>();

            var ListProListDb = context.TblProduct.Where(e => e.Status == true&&e.IsDeleted==false && e.ProductName.Contains( name)).ToList();
            ListPro = ListProListDb;


            return ListProListDb;
        }
        
        public TblProduct GetProductByName(string name)
        {

            TblProduct ListPro = new TblProduct();

            var ListProListDb = context.TblProduct.Where(e=> e.IsDeleted==true &&e.ProductName==name).FirstOrDefault();

         

            return ListProListDb;
        }
        public List<TblProduct> GetProductByNameTrashList(string name)
        {

            List<TblProduct> ListPro = new List<TblProduct>();

            var ListProListDb = context.TblProduct.Where(e => e.IsDeleted == true && e.ProductName.Contains(name)).ToList();
            ListPro = ListProListDb;


            return ListPro;
        }
        public List<TblProduct> GetFiveProduct()
        {

            List<TblProduct> ListPro = new List<TblProduct>();

            var ListProListDb = context.TblProduct.Where(e=> e.Status == true).OrderByDescending(e => e.ProductId).Take(5).ToList();

            ListProListDb.ForEach(e =>
            {
                TblProduct TblProduct = new TblProduct();
                TblProduct.ProductId = e.ProductId;
                TblProduct.ProductName = e.ProductName;
                TblProduct.Image = e.Image;
                TblProduct.Price = (float)e.Price;
                TblProduct.PriceDiscount = (float)e.PriceDiscount;
                TblProduct.BrandId = e.BrandId;
                TblProduct.Origin = e.Origin;
                TblProduct.CategoryId = e.CategoryId;
                ListPro.Add(TblProduct);
            });



            return ListPro;
        }

        public List<TblProduct> GetFiveProductRandom()
        {

            List<TblProduct> ListPro = new List<TblProduct>();

            var ListProListDb = context.TblProduct.Where(e=>e.Status==true).OrderBy(e => Guid.NewGuid()).Take(5).ToList();

            ListProListDb.ForEach(e =>
            {
                TblProduct TblProduct = new TblProduct();
                TblProduct.ProductId = e.ProductId;
                TblProduct.ProductName = e.ProductName;
                TblProduct.Image = e.Image;
                TblProduct.Price = (float)e.Price;
                TblProduct.PriceDiscount = (float)e.PriceDiscount;
                TblProduct.BrandId = e.BrandId;
                TblProduct.Origin = e.Origin;
                TblProduct.CategoryId = e.CategoryId;
                ListPro.Add(TblProduct);
            });



            return ListPro;
        }
        public TblProduct GetProductById(int ProductId)
        {


           
            var ProListDb = context.TblProduct.ToList().Where(e => e.ProductId == ProductId& e.Status == true).FirstOrDefault();
            if (ProListDb == null) return null;
            TblProduct product = new TblProduct();

            product.ProductId = ProListDb.ProductId;
            product.ProductName = ProListDb.ProductName;
            product.ShortDesc = ProListDb.ShortDesc;
            product.FullDesc = ProListDb.FullDesc;
            product.Image = ProListDb.Image;
            product.Price = (float)ProListDb.Price;
            product.PriceDiscount = (float)ProListDb.PriceDiscount;
            product.BrandId = ProListDb.BrandId;
            product.Origin = ProListDb.Origin;
            product.CategoryId = ProListDb.CategoryId;
            product.Status = ProListDb.Status; product.IsDeleted = ProListDb.IsDeleted;

            return product;
        }
        public List<TblProduct> GetProductbyPercent(int percent)
        {

            List<TblProduct> tblProducts = new List<TblProduct>();

            var ProListDb = context.TblProduct.Where(e => (e.Price-e.PriceDiscount)/e.Price*100 >= percent& e.Status == true).Take(5).ToList();
            if (ProListDb == null) return null;
            ProListDb.ForEach(e =>
            {
                TblProduct product = new TblProduct();

                product.ProductId = e.ProductId;
                product.ProductName = e.ProductName;
                product.Image = e.Image;
                product.Price = (float)e.Price;
                product.PriceDiscount = (float)e.PriceDiscount;
                product.Origin = e.Origin;
                product.CategoryId = e.CategoryId;
                tblProducts.Add(product);
            });


            return tblProducts;
        }

        public List<TblProduct> GetProductbyPercentAll(int percent)
        {

            List<TblProduct> tblProducts = new List<TblProduct>();

            var ProListDb = context.TblProduct.Where(e => (e.Price - e.PriceDiscount) / e.Price * 100 >= percent & e.Status == true).ToList();
            if (ProListDb == null) return null;
            ProListDb.ForEach(e =>
            {
                TblProduct product = new TblProduct();

                product.ProductId = e.ProductId;
                product.ProductName = e.ProductName;
                product.Image = e.Image;
                product.Price = (float)e.Price;
                product.PriceDiscount = (float)e.PriceDiscount;
                product.Origin = e.Origin;
                product.CategoryId = e.CategoryId;
                tblProducts.Add(product);
            });


            return tblProducts;
        }
        public List<TblProduct> GetProductbyPercentHome(int percent)
        {

            List<TblProduct> tblProducts = new List<TblProduct>();

            var ProListDb = context.TblProduct.Where(e => (e.Price - e.PriceDiscount) / e.Price * 100 >= percent& e.Status == true).Take(5).ToList();
            if (ProListDb == null) return null;
            ProListDb.ForEach(e =>
            {
                TblProduct product = new TblProduct();

                product.ProductId = e.ProductId;
                product.ProductName = e.ProductName;
                product.Image = e.Image;
                product.Price = (float)e.Price;
                product.PriceDiscount = (float)e.PriceDiscount;
                product.Origin = e.Origin;
                product.CategoryId = e.CategoryId;
                tblProducts.Add(product);
            });


            return tblProducts;
        }

        public List<TblProduct> GetProductByCat(int CatId)
        {
            List<TblProduct> listProducts = new List<TblProduct>();
           
                var ProductDb = context.TblProduct.Where(e=>e.CategoryId==CatId&e.Status == true).ToList();
            ProductDb.ForEach(e =>
            {
                listProducts.Add(e);
            });
            return listProducts.ToList();

        }
        public TblProduct Post(TblProduct TblProduct)
        {
            try
            {
                context.TblProduct.Add(TblProduct);
                context.SaveChanges();

                TblProduct tblProduct= GetProductByName(TblProduct.ProductName);

                return tblProduct;


            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Put(TblProduct TblProduct)
        {
            try
            {

                TblProduct tbl_Product = new TblProduct();
                tbl_Product.ProductId = TblProduct.ProductId;
                tbl_Product.ProductName = TblProduct.ProductName;
                tbl_Product.ShortDesc = TblProduct.ShortDesc;
                tbl_Product.FullDesc = TblProduct.FullDesc;
                tbl_Product.Price = (float)TblProduct.Price;
                tbl_Product.PriceDiscount = (float)TblProduct.PriceDiscount;
                tbl_Product.Image = TblProduct.Image;
                tbl_Product.BrandId = TblProduct.BrandId;
                tbl_Product.Origin = TblProduct.Origin;
                tbl_Product.CategoryId = TblProduct.CategoryId;
                tbl_Product.IsDeleted = TblProduct.IsDeleted;
                tbl_Product.Status = TblProduct.Status;
                context.Entry(tbl_Product).State = EntityState.Modified;

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
                TblProduct tbl_Product = context.TblProduct.Where(e=>e.ProductId==Id).FirstOrDefault();

                context.Entry(tbl_Product).State = EntityState.Deleted;
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
