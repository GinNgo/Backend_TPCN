
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
    public class ProductController : ControllerBase
    {
        ProductSv Product = new ProductSv();
        ImageSv ImageSv = new ImageSv();
       
        [HttpGet]

        public IEnumerable GetAllProduct()
        {
            List<TblProduct> products = new List<TblProduct>();
            products = Product.GetAllProduct();
            return products.ToList();
        }

        [HttpGet("getAllProductForDashboard")]
        public List<TblProduct> GetAllProductForDashboard()
        {
            List<TblProduct> ListProduct = new List<TblProduct>();
            ListProduct = Product.GetAllProductForDashboard();
            return ListProduct;
        }
        [HttpGet("getAllProductIsTrash")]
        public IEnumerable GetAllProductIsTrash()
        {
            List<TblProduct> products = new List<TblProduct>();
            products = Product.GetAllProductIsTrash();
            return products.ToList();
        }
        [HttpGet("getProductName")]
        public List<string> GetProductName()
        {
            return Product.GetProductName();
        }
        [HttpGet("getProductByName/{name}")]
        public List<TblProduct> GetProductByNameList(string name)
        {
            return Product.GetProductByNameList(name);
        }
        [HttpGet("getProductByNameTrash/{Tname}")]
        public List<TblProduct> GetProductByNameTrashList(string Tname)
        {
            return Product.GetProductByNameTrashList(Tname);
        }
        [HttpGet("new")]


        public IEnumerable GetFiveProduct()
        {
            List<TblProduct> products = new List<TblProduct>();
            products = Product.GetFiveProduct();
            return products.ToList();
        }
        [HttpGet("random")]

        public IEnumerable GetFiveProductRandom()
        {
            List<TblProduct> products = new List<TblProduct>();
            products = Product.GetFiveProductRandom();
            return products.ToList();
        }
        [HttpGet("{id}")]
        public TblProduct GetProductById(int Id)
        {
            TblProduct product = new TblProduct();
            product = Product.GetProductById(Id);
            return  product;
        }
        [HttpGet("percent/{percent}")]

        public List<TblProduct> GetProductbyPercent(int percent)
        {
            List<TblProduct> tblProducts = new List<TblProduct>();
            tblProducts = Product.GetProductbyPercent(percent);
            return tblProducts;
        }
        [HttpGet("percentAll/{Kpercent}")]
        public List<TblProduct> GetProductbyPercentAll(int Kpercent)
        {
            List<TblProduct> tblProducts = new List<TblProduct>();
            tblProducts = Product.GetProductbyPercentAll(Kpercent);
            return tblProducts;
        }

        [HttpGet("percentHome/{Tpercent}")]

        public List<TblProduct> GetProductbyPercentHome(int Tpercent)
        {
            List<TblProduct> tblProducts = new List<TblProduct>();
            tblProducts = Product.GetProductbyPercent(Tpercent);
            return tblProducts;
        }
        [HttpGet("getProductByCat/{CatId}")]
        public List<TblProduct> GetProductByCat(int CatId)
        {
            return  Product.GetProductByCat(CatId).ToList();
        }

        [HttpPost("createProduct/{tblProduct}")]
        public int Post(TblProduct tblProduct)
        {

            TblProduct product =Product.Post(tblProduct);
            if(product != null)
            {
                TblImage tblImage = new TblImage();
                tblImage.Title = product.ProductName;
                tblImage.ImageName = product.Image;
                tblImage.Status = true;
                tblImage.ProuctId= product.ProductId;
                tblImage.IsDeleted = false;
                tblImage.DisplayOrder = 1;

                ImageSv.CreateImage(tblImage);
                return product.ProductId;
            }
            return 0;
        }
        [HttpPut("editProduct/{TProduct}")]
        public bool Put(TblProduct TProduct)
        {
            return Product.Put(TProduct);
        }

    

        [HttpDelete("deleteProduct/{ProductId}")]
        public bool Delete(int ProductId)
        {
            return Product.Delete(ProductId);
        }
    }
}
