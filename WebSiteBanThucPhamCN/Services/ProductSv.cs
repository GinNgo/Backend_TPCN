using System;
using System.Collections.Generic;
using WebSiteBanThucPhamCN.Data;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Services
{
    public class ProductSv
    {
        ProductDb Product = new ProductDb();
        public List<TblProduct> GetAllProduct()
        {
            List<TblProduct> ListProduct = new List<TblProduct>();
            ListProduct = Product.GetAllProduct();
            return ListProduct;
        }
        public List<TblProduct> GetAllProductForDashboard()
        {
            List<TblProduct> ListProduct = new List<TblProduct>();
            ListProduct = Product.GetAllProductForDashboard();
            return ListProduct;
        }
        public List<TblProduct> GetAllProductIsTrash()
        {
            List<TblProduct> ListProduct = new List<TblProduct>();
            ListProduct = Product.GetAllProductIsTrash();
            return ListProduct;
        }
        public List<string> GetProductName()
        {
            return Product.GetProductName();
        }
        public List<TblProduct> GetFiveProduct()
        {
            List<TblProduct> ListProduct = new List<TblProduct>();
            ListProduct = Product.GetFiveProduct();
            return ListProduct;
        }
        public TblProduct GetProductByName(string name)
        {
            return Product.GetProductByName(name);
        }
        
              public List<TblProduct> GetProductByNameList(string name)
        {
            return Product.GetProductByNameList(name);
        }
        public List<TblProduct> GetProductByNameTrashList(string name)
        {
            return Product.GetProductByNameTrashList(name);
        }
        public List<TblProduct> GetFiveProductRandom()
        {
            List<TblProduct> ListProduct = new List<TblProduct>();
            ListProduct = Product.GetFiveProductRandom();
            return ListProduct;
        }
        public TblProduct GetProductById(int ProductId)
        {
            TblProduct TblProduct = new TblProduct();
            TblProduct = Product.GetProductById(ProductId);
            return TblProduct;
        }
        public List<TblProduct> GetProductbyPercentAll(int percent)
        {
            List<TblProduct> tblProducts = new List<TblProduct>();
            tblProducts = Product.GetProductbyPercentAll(percent);
            return tblProducts;
        }
        public List<TblProduct> GetProductbyPercent(int percent)
        {
            List<TblProduct> tblProducts = new List<TblProduct>();
            tblProducts = Product.GetProductbyPercent(percent);
            return tblProducts;
        }
        public List<TblProduct> GetProductbyPercentHome(int percent)
        {
            List<TblProduct> tblProducts = new List<TblProduct>();
            tblProducts = Product.GetProductbyPercentHome(percent);
            return tblProducts;
        }
        public List<TblProduct> GetProductByCat(int CatId)
        {
            return Product.GetProductByCat(CatId);
        }
        public TblProduct Post(TblProduct TblProduct)
        {

            return Product.Post(TblProduct);
        }
        public bool Put(TblProduct TblProduct)
        {
            return Product.Put(TblProduct);
        }
        public bool Delete(int Id)
        {


            return Product.Delete(Id);
        }

      
    }
}
