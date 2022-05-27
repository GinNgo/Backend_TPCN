using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Data
{
    public class AccountDb
    {
        WebsiteBanThucPhamCNContext context = new WebsiteBanThucPhamCNContext();
        public TblAccount GetAccount(string UserName)
        {
            TblAccount account = new TblAccount();
          
            return account = context.TblAccount.Where(e => e.Username.Equals(UserName)).FirstOrDefault();
        }

        public List<TblAccount> GetAllAccount()
        {
            List<TblAccount> account = new List<TblAccount>();
            account = context.TblAccount.Where(e => e.IsDeleted == false).OrderByDescending(e => e.AccId).ToList();

            return account;
        }

        public List<TblAccount> GetAllAccountTrash()
        {
            List<TblAccount> account = new List<TblAccount>();

            return account = context.TblAccount.Where(e => e.IsDeleted == true).OrderByDescending(e => e.AccId).ToList();
        }
        public TblAccount GetAccountById(string Id)
        {
            TblAccount account = new TblAccount();
           
            return account = context.TblAccount.Where(e => e.AccId.ToString().Equals(Id)).FirstOrDefault();
        }

        public TblAccount GetAccountByUserId(string Id)
        {
            TblAccount account = new TblAccount();

            return account = context.TblAccount.Where(e => e.UserId.ToString().Equals(Id)).FirstOrDefault();
        }

        //check IsHave
        public bool CheckAccount(string UserName)
        {

            TblAccount account = new TblAccount();
            account = context.TblAccount.Where(e => e.Username.Equals(UserName)).FirstOrDefault();
            if(account == null) return false;
            return true;
        }

        //post
        public bool CreateAccount(TblAccount tblAccount)
        {
            try
            {

            TblAccount account = new TblAccount();
            account.UserId = tblAccount.UserId;
            account.Username = tblAccount.Username;
            account.Password = tblAccount.Password;
            account.CreateDate = DateTime.Now;
            account.Status = true;
            account.IsDeleted = false;
          
            account.Role = tblAccount.Role;
            context.TblAccount.Add(account);
            context.SaveChanges();
            return true;

        }
            catch (Exception)
            {
                return false;
            }
}
        //put
        public bool UpdatePassword(TblAccount tblAccount)
        {
            try
            {
           
                TblAccount account = new TblAccount();
                account.AccId = tblAccount.AccId;
                account.UserId = tblAccount.UserId;
                account.Username = tblAccount.Username;
                account.Password = tblAccount.Password;
                account.Status = tblAccount.Status;
                account.IsDeleted = tblAccount.IsDeleted;
                account.Role = tblAccount.Role;
                context.Entry(account).State = EntityState.Modified;
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ToggleAccount(string Id)
        {
            try
            {
                TblAccount acc = GetAccountByUserId(Id);

                acc.Status = !acc.Status;



                context.Entry(acc).State = EntityState.Modified;
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
  
        public bool TrashAccount(string Id)
        {
            try
            {
                TblAccount acc = GetAccountByUserId(Id);
               
                if (acc.IsDeleted == false)
                {
                    acc.IsDeleted = true;
                    acc.Status = false;

                }
                else
                {
                    acc.Status = true;
                    acc.IsDeleted = false;
                   
                   
                }
                

            
               
                context.Entry(acc).State = EntityState.Modified;
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
                TblAccount tblAccount = context.TblAccount.Where(e => e.UserId == Id).FirstOrDefault();

                context.Entry(tblAccount).State = EntityState.Deleted;
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
