using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Data
{
    public class UserDb
    {
        WebsiteBanThucPhamCNContext context = new WebsiteBanThucPhamCNContext();
       
        public TblUser GetProfileById(string Id)
        {
            TblUser tblUser = new TblUser();

            return tblUser = context.TblUser.Where(e => e.UserId.ToString().Equals(Id)).FirstOrDefault();
        }
        public int GetUserId(TblUser user)
        {
            TblUser tblUser = new TblUser();
            tblUser = context.TblUser.Where(e => e.Fullname.Equals(user.Fullname) && e.Address.Equals(user.Address) && e.Email.Equals(user.Email) && e.Phone.Equals(user.Phone)).FirstOrDefault();

            return tblUser.UserId;
        }
        public int GetNumberUser()
        {

            List<TblUser> tblUser = new List<TblUser>();
            tblUser = context.TblUser.Where(e=>e.IsDeleted==false).ToList();
            int number = tblUser.Count;
            return number;
        }
        public bool CheckEmail(string email)
        {
            TblUser tblUser = new TblUser();
            tblUser = context.TblUser.Where(e => e.Email.Equals(email)).FirstOrDefault();
            if (tblUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //post
        
        //create
        public int CreateUser(TblUser user)
        {
            try
            {

                TblUser tblUser = new TblUser();
           
                tblUser.Fullname = user.Fullname;
                tblUser.Address = user.Address;
                tblUser.Phone = user.Phone;
                tblUser.Email = user.Email;
                tblUser.CreateDate=DateTime.Now;
                tblUser.IsDeleted =false;
          
                context.TblUser.Add(tblUser);
                context.SaveChanges();
                
                return GetUserId(user);

            }
            catch (Exception)
            {
                return 0;
            }

        }
        //upate
        public bool TrashUser(string user)
        {

            try
            {

                TblUser tblUser = GetProfileById(user);
               if(tblUser.IsDeleted==false)
                tblUser.IsDeleted = true;
               else
                    tblUser.IsDeleted = false;
                context.Entry(tblUser).State = EntityState.Modified;
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }



        }
        public bool UpdateProfile(TblUser user)
        {
           
            try
            {

                TblUser tblUser = new TblUser();
                tblUser.UserId = user.UserId;
                tblUser.Fullname = user.Fullname;
                tblUser.Address = user.Address;
                tblUser.Phone = user.Phone;
                tblUser.Email = user.Email;
                tblUser.IsDeleted = user.IsDeleted;
                tblUser.CreateDate = user.CreateDate;
                context.Entry(tblUser).State = EntityState.Modified;
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
                TblUser tblUser = context.TblUser.Where(e => e.UserId == Id).FirstOrDefault();

                context.Entry(tblUser).State = EntityState.Deleted;
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
