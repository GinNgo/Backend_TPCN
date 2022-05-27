using System.Collections.Generic;
using WebSiteBanThucPhamCN.Data;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Services
{
    public class CategorySv
    {
        public readonly CategoryDb Category = new CategoryDb();
        public List<TblCategory> GetCategory()
        {
            return Category.GetCategory();
        }

        public List<TblCategory> GetCategoryByParentId(int id)
        {
            return Category.GetCategoryByParentId(id);
        }
        public List<TblCategory> GetCategoryAll()
        {
            return Category.GetCategoryAll();
        }
        public List<TblCategory> GetCategoryAllCreate()
        {
            return Category.GetCategoryAllCreate();
        }
        public TblCategory GetCategoryById(int id)
        {
            return Category.GetCategoryById(id);
        }
        public List<TblCategory> GetCategoryByName(string CategoryName)
        {
            return Category.GetCategoryByName(CategoryName);
        }
        public List<TblCategory> GetCategoryByNameTrash(string CategoryName)
        {
            return Category.GetCategoryByNameTrash(CategoryName);
        }
        public List<TblCategory> GetTrashCat()
        {
            return Category.GetTrashCat();
        }
        public List<TblCategory> BreadCrumb(int id)
        {
            return Category.BreadCrumb(id);
        }
        public List<int> GetIdCatForProduct(int Cat)
        {
            return Category.GetIdCatForProduct(Cat);
        }
        public List<TblCategory> GetCatAddProduct()
        {
            return Category.GetCatAddProduct();
        }
        public bool CreateCategory(TblCategory TblCategory)
        {
            return Category.CreateCat(TblCategory);
        }

        public bool Put(TblCategory TblCategory)
        {
            return Category.Put(TblCategory);
        }
        public bool Delete(int id)
        {
            return Category.Delete(id);
        }
    }
}
