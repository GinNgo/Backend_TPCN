using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebSiteBanThucPhamCN.Models;
using WebSiteBanThucPhamCN.Services;

namespace WebSiteBanThucPhamCN.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        CategorySv Category = new CategorySv();
         WebsiteBanThucPhamCNContext context = new WebsiteBanThucPhamCNContext();
        [HttpGet("getCategory")]
        public IEnumerable GetCategory()
        {
            List<TblCategory> categories = new List<TblCategory>();
            categories = Category.GetCategory();
            return categories.ToList();
        }
        [HttpGet("getCategoryByParentId/{id}")]
        public IEnumerable GetCategoryByParentId(int id)
        {
            List<TblCategory> categories = new List<TblCategory>();
            categories = Category.GetCategoryByParentId(id);
            return categories.ToList();
        }
        [HttpGet("getCategoryAll")]
        public IEnumerable GetCategoryAll()
        {
            List<TblCategory> categories = new List<TblCategory>();
            categories = Category.GetCategoryAll();
            return categories.ToList();
        }
        [HttpGet("getCategoryAllCreate")]
        public IEnumerable GetCategoryAllCreate()
        {
            List<TblCategory> categories = new List<TblCategory>();
            categories = Category.GetCategoryAllCreate();
            return categories.ToList();
        }
        [HttpGet("getTrashCategory")]
        public List<TblCategory> GetTrashCat()
        {
            return Category.GetTrashCat();
        }
        [HttpGet("getCategoryByName/{CategoryName}")]
        public IEnumerable GetCategoryByName(string CategoryName)
        {
            return Category.GetCategoryByName(CategoryName);
        }
        [HttpGet("getTrashCategoryByName/{CategoryNameTrash}")]
        public IEnumerable GetCategoryByNameTrash(string CategoryNameTrash)
        {
            return Category.GetCategoryByNameTrash(CategoryNameTrash);
        }
        [HttpGet("breadCrumb/{Tid}")]
        public List<TblCategory> BreadCrumb(int Tid)
        {
            List<TblCategory> categories = new List<TblCategory>();
            categories = Category.BreadCrumb(Tid);
            categories.Reverse();
            return categories.ToList();
        }
        [HttpGet("getIdCatForProduct/{Cat}")]
        public List<int> GetIdCatForProduct(int Cat)
        {
            return Category.GetIdCatForProduct(Cat);
        }
        [HttpGet("getCatAddProduct")]
        public List<TblCategory> GetCatAddProduct()
        {
            return Category.GetCatAddProduct();
        }
        [HttpGet("getCategoryById/{id}")]
        public TblCategory GetCategoryById(int id)
        {
            return Category.GetCategoryById(id);
        }


        [HttpPost("{category}")]

        public bool CreateBrand(TblCategory category)
        {
            return Category.CreateCategory(category);
        }
        [HttpPut("{cat}")]
        public bool Put(TblCategory cat)
        {
            return Category.Put(cat);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return Category.Delete(id);
        }
    }

}
