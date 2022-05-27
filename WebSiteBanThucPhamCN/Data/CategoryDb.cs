using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Data
{
    public class CategoryDb
    {
        WebsiteBanThucPhamCNContext context = new WebsiteBanThucPhamCNContext();
        public List<TblCategory> GetCategory()
        {
            List<TblCategory> catList = new List<TblCategory>();

            var catListDB = context.TblCategory.Where(e => e.ParentId == 0 && e.Status == true&&e.IsDeleted==false).ToList();
            catListDB.ForEach(e =>
            {
                TblCategory category = new TblCategory();
                category.CatId = e.CatId;
                category.CatName = e.CatName;
                category.ParentId = (int)e.ParentId;
                category.IsDeleted = e.IsDeleted;
                category.Status = e.Status;
                var catListFirstDB = context.TblCategory.Where(h => h.ParentId == e.CatId && e.Status == true).ToList();
                catListFirstDB.ForEach(h =>
                {
                    TblCategory First = new TblCategory();
                    First.CatId = h.CatId;
                    First.CatName = h.CatName;
                    First.ParentId = (int)h.ParentId;
                    First.IsDeleted = h.IsDeleted;
                    First.Status = h.Status;
                    var catListSecondDB = context.TblCategory.Where(k => k.ParentId == h.CatId && h.Status == true).ToList();
                    catListSecondDB.ForEach(k =>
                    {
                        TblCategory categoryBOSecond = new TblCategory();
                        categoryBOSecond.CatId = k.CatId;
                        categoryBOSecond.CatName = k.CatName;
                        categoryBOSecond.ParentId = (int)k.ParentId;
                        categoryBOSecond.IsDeleted = k.IsDeleted;
                        categoryBOSecond.Status = k.Status;
                        First.CategoryChild.Add(categoryBOSecond);
                    });
                    category.CategoryChild.Add(First);
                });

                catList.Add(category);
            });
            return catList;
        }

        public List<TblCategory> GetCategoryByParentId(int id)
        {
            List<TblCategory> catList = new List<TblCategory>();

            catList = context.TblCategory.Where(e => e.ParentId == id && e.Status == true && e.IsDeleted == false).ToList();
           
            return catList;
        }
        public List<TblCategory> GetCategoryAll()
        {
            List<TblCategory> catList = new List<TblCategory>();
            var catListDB = context.TblCategory.Where(e => e.ParentId == 0 && e.IsDeleted == false).OrderByDescending(e=>e.CatId).ToList();
            catListDB.ForEach(e =>
            {
                catList.Add(e);
                TblCategory category = new TblCategory();
                category.CatId = e.CatId;
                category.CatName = e.CatName;
                category.ParentId = (int)e.ParentId;
                category.IsDeleted = e.IsDeleted;
                category.Status = e.Status;
                var catListFirstDB = context.TblCategory.Where(h => h.ParentId == e.CatId && h.IsDeleted == false).ToList();
                catListFirstDB.ForEach(h =>
                {
                  
                    TblCategory First = new TblCategory();
                    First.CatId = h.CatId;
                    First.CatName = e.CatName+">>"+h.CatName;
                    First.ParentId = (int)h.ParentId;
                    First.IsDeleted = h.IsDeleted;
                    First.Status = h.Status;
                    catList.Add(First);
                    var catListSecondDB = context.TblCategory.Where(k => k.ParentId == h.CatId && k.IsDeleted == false).ToList();
                    catListSecondDB.ForEach(k =>
                    {
                        TblCategory categoryBOSecond = new TblCategory();
                        categoryBOSecond.CatId = k.CatId;
                        categoryBOSecond.CatName = First.CatName+">>" + k.CatName;
                        categoryBOSecond.ParentId = (int)k.ParentId;
                        categoryBOSecond.IsDeleted = k.IsDeleted;
                        categoryBOSecond.Status = k.Status;
                        First.CategoryChild.Add(categoryBOSecond);
                        catList.Add(categoryBOSecond);
                    });
                    category.CategoryChild.Add(First);
                });

               
            });
            return catList;
        }

        public List<TblCategory> GetCategoryAllCreate()
        {
            List<TblCategory> catList = new List<TblCategory>();
            var catListDB = context.TblCategory.Where(e => e.ParentId == 0 && e.Status == true).ToList();
            catListDB.ForEach(e =>
            {
                catList.Add(e);
                TblCategory category = new TblCategory();
                category.CatId = e.CatId;
                category.CatName = e.CatName;
                category.ParentId = (int)e.ParentId;
                category.IsDeleted = e.IsDeleted;
                category.Status = e.Status;
                var catListFirstDB = context.TblCategory.Where(h => h.ParentId == e.CatId && h.Status == true).ToList();
                catListFirstDB.ForEach(h =>
                {

                    TblCategory First = new TblCategory();
                    First.CatId = h.CatId;
                    First.CatName = e.CatName + ">>" + h.CatName;
                    First.ParentId = (int)h.ParentId;
                    First.IsDeleted = h.IsDeleted;
                    First.Status = h.Status;
                    catList.Add(First);
               
                    
                   
                });


            });
            return catList;
        }
        public List<TblCategory> GetCategoryByName(string name)
        {

            List<TblCategory> catList = new List<TblCategory>();
            TblCategory tblCat = new TblCategory();
            var ListProListDb = context.TblCategory.Where(e => e.Status == true && e.IsDeleted == false && e.CatName.Contains(name)).ToList();
            ListProListDb.ForEach(k => {
                tblCat = k;
                var h = k.ParentId;
                while (h > 0)
                {
                    TblCategory tblCategory = new TblCategory();
                    tblCategory = context.TblCategory.Where(e => e.CatId == h).FirstOrDefault();
                    
                    h = tblCategory.ParentId;
                    tblCat.CatName = tblCategory.CatName + ">>" + tblCat.CatName;
                }
                catList.Add(tblCat);

            });


            return catList;
        }
        public List<TblCategory> GetCategoryByNameTrash(string name)
        {

            List<TblCategory> ListPro = new List<TblCategory>();

            var ListProListDb = context.TblCategory.Where(e => e.IsDeleted == true && e.CatName.Contains(name)).ToList();

            ListProListDb.ForEach(k => {
                var h = k.ParentId;
                while (h > 0)
                {
                    TblCategory tblCategory = new TblCategory();
                    tblCategory = context.TblCategory.Where(e => e.CatId==h).FirstOrDefault();
                    h=tblCategory.ParentId;
                    k.CatName = tblCategory.CatName + ">>" + k.CatName;
                }
                ListPro.Add(k);

            });

            return ListPro;
        }
        public List<TblCategory> BreadCrumb(int id)
        {

            int catId = id;
            List<TblCategory> breadCrumb = new List<TblCategory>();
            while (catId > 0)
            {
                var catDb = context.TblCategory.Where(e => e.CatId == catId && e.Status == true).FirstOrDefault();
                breadCrumb.Add(catDb);
                catId = (int)catDb.ParentId;
            }
            return breadCrumb;
        }
        public List<int> GetIdCatForProduct(int  CatId)
        {
            List<int> catList = new List<int>();
        
            var CatDb = context.TblCategory.Where(e => e.ParentId == CatId).ToList();
           if (CatDb.Count == 0)
            {
                catList.Add(CatId);
                return catList;
            }
            else
            {
                CatDb.ForEach(e =>
                {
                    var CatDb1 = context.TblCategory.Where(h => h.ParentId == e.CatId).ToList();
                    if (CatDb1.Count==0)
                    {
                        catList.Add(e.CatId);
                    }
                    else
                    {
                        CatDb1.ForEach(k =>
                        {
                            catList.Add(k.CatId);
                        });
                    }
                });
            }
            return catList;
        }
         public List<TblCategory> GetCatAddProduct()
        {
            List<TblCategory> catList = new List<TblCategory>();
            List<TblCategory> catList1 = new List<TblCategory>();
            var CatDb = context.TblCategory.Where(e=>e.ParentId==0).ToList();
            CatDb.ForEach(e =>
            {
                var CatDb1 = context.TblCategory.Where(h => h.ParentId == e.CatId).ToList();
                CatDb1.ForEach(k =>
                {
                    var CatDb2 = context.TblCategory.Where(i => i.ParentId == k.CatId).ToList();
                    if (CatDb2.Count == 0)
                    {
                        catList1.Add(k);
                    }
                    else
                    {
                        CatDb2.ForEach(j =>
                        {
                            catList1.Add(j);
                        });
                    
                    }

                });
               
            });

            return catList1;
        }
        public List<TblCategory> GetTrashCat()
        {
            List<TblCategory> tblCategory = new List<TblCategory>();
          var catListDB = context.TblCategory.Where(e => e.IsDeleted == true).ToList();
            catListDB.ForEach(e =>
            {
                tblCategory.Add(e);
                TblCategory category = new TblCategory();
                category.CatId = e.CatId;
                category.CatName = e.CatName;
                category.ParentId = (int)e.ParentId;
                category.IsDeleted = e.IsDeleted;
                category.Status = e.Status;
                var catListFirstDB = context.TblCategory.Where(h => h.ParentId == e.CatId && h.IsDeleted == false).ToList();
                catListFirstDB.ForEach(h =>
                {

                    TblCategory First = new TblCategory();
                    First.CatId = h.CatId;
                    First.CatName = e.CatName + ">>" + h.CatName;
                    First.ParentId = (int)h.ParentId;
                    First.IsDeleted = h.IsDeleted;
                    First.Status = h.Status;
                    tblCategory.Add(First);
                    var catListSecondDB = context.TblCategory.Where(k => k.ParentId == h.CatId && k.IsDeleted == false).ToList();
                    catListSecondDB.ForEach(k =>
                    {
                        TblCategory categoryBOSecond = new TblCategory();
                        categoryBOSecond.CatId = k.CatId;
                        categoryBOSecond.CatName = First.CatName + ">>" + k.CatName;
                        categoryBOSecond.ParentId = (int)k.ParentId;
                        categoryBOSecond.IsDeleted = k.IsDeleted;
                        categoryBOSecond.Status = k.Status;
                        First.CategoryChild.Add(categoryBOSecond);
                        tblCategory.Add(categoryBOSecond);
                    });
                    category.CategoryChild.Add(First);
                });


            });
            return tblCategory;
        }
        public TblCategory GetCategoryById(int id)
        {
            TblCategory tblCategory = new TblCategory();
            tblCategory = context.TblCategory.Where(e => e.CatId == id).FirstOrDefault();
         
            return tblCategory;

        }
        public bool CreateCat(TblCategory category)
        {
            try
            {


                context.TblCategory.Add(category);
                context.SaveChanges();


                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Put(TblCategory TblCategory)
        {
            try
            {
                context.Entry(TblCategory).State = EntityState.Modified;

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
                TblCategory tbl = context.TblCategory.Where(e => e.CatId == Id).FirstOrDefault();

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



