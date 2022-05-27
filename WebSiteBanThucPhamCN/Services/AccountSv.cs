using System.Collections.Generic;
using WebSiteBanThucPhamCN.Data;
using WebSiteBanThucPhamCN.Models;

namespace WebSiteBanThucPhamCN.Services
{
    public class AccountSv
    {
        AccountDb account = new AccountDb();
        
        public TblAccount GetAccount(string UserName)
        {
            return account.GetAccount(UserName);
        }
        public List<TblAccount> GetAllAccount()
        {
            return account.GetAllAccount();
        }
        public List<TblAccount> GetAllAccountTrash()
        {
            return account.GetAllAccountTrash();
        }
        public TblAccount GetAccountById(string Id)
        {
            return account.GetAccountById(Id);
        }

        public TblAccount GetAccountByUserId(string Id)
        {
            return account.GetAccountByUserId(Id);
        }
        //check 
        public bool CheckAccount(string UserName)
        {
            return account.CheckAccount(UserName);
        }
        //create
        public bool CreateAccount(TblAccount tblAccount)
        {
            return account.CreateAccount(tblAccount);
        }
      //update
        public bool UpdatePassword(TblAccount tblAccount)
        {
            return account.UpdatePassword(tblAccount);

        }

        public bool ToggleAccount(string Id)
        {
           
            return account.ToggleAccount(Id);
        }
        public bool TrashAccount(string  Id)
        {
           
            return account.TrashAccount(Id);
        }

        public bool Delete(int Id)
        {
            return account.Delete(Id);
        }

    }
}
