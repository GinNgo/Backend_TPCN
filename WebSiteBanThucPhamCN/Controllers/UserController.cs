using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebSiteBanThucPhamCN.Data;
using WebSiteBanThucPhamCN.Models;
using WebSiteBanThucPhamCN.Services;

namespace WebSiteBanThucPhamCN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        AccountSv accountSv = new AccountSv();
        UserSv userSv = new UserSv();
        WebsiteBanThucPhamCNContext website = new WebsiteBanThucPhamCNContext();
        [HttpGet("getAccount")]
        [Authorize]

        public TblAccount GetAcount()
        {
            string Account = User.Claims.First(e => e.Type == "AccId").Value;
            TblAccount account = accountSv.GetAccountById(Account);


            return account;
        }
        [HttpGet("getAllAccount")]
        public List<TblAccount> GetAllAcount()
        {

            List<TblAccount> account = accountSv.GetAllAccount();


            return account;
        }

        [HttpGet("getAccountByUserId/{UserId}")]
        public TblAccount GetAccountByUserId(string UserId)
        {

            TblAccount account = accountSv.GetAccountByUserId(UserId);


            return account;
        }

        [HttpGet("getAllAccountTrash")]
        public List<TblAccount> GetAllAcountTrash()
        {

            List<TblAccount> account = accountSv.GetAllAccountTrash();


            return account;
        }
        [HttpGet("checkEmail/{email}")]
        public bool CheckEmail(string email)
        {
            return userSv.CheckEmail(email);
        }

        [HttpGet("getProfile")]
        [Authorize]

        public TblUser GetProfile()
        {
            string UserId = User.Claims.First(e => e.Type == "UserId").Value;
            TblUser user = userSv.GetProfileById(UserId);
            return user;
        }


        [HttpGet("getUserById/{UserId}")]
    

        public TblUser GetProfile(string UserId)
        {
           
            TblUser user = userSv.GetProfileById(UserId);
            return user;
        }
        public int GetNumberUser()
        {
            return userSv.GetNumberUser();
        }
        //updateProfle Account
        [HttpPut("updateAccount/{account}")]
        [Authorize]
        public bool UpdatePassword(TblAccount account)
        {
            return accountSv.UpdatePassword(account);
        }
        [HttpPut("updateAccountAdmin/{account}")]
      
        public bool updateAccountAdmin(TblAccount account)
        {
            return accountSv.UpdatePassword(account);
        }

        //updateProfle User
        [HttpPut("updateProfile/{user}")]
        [Authorize]
        public bool UpdateProfile(TblUser user)
        {
            return userSv.UpdateProfile(user);
        }


        [HttpPut("trashAccount/{UserId}")]

        public bool TrashAccount(string UserId)
        {
            var check = accountSv.TrashAccount(UserId);
            if (check)
            {
                return userSv.TrashUser(UserId);
            }
            else
            {
                return accountSv.TrashAccount(UserId);
            }
            
        }
        [HttpPut("toggleAccount/{UserId}")]

        public bool ToggleAccount(string UserId)
        {
            return accountSv.ToggleAccount(UserId);
        }
        //Check Account
        [HttpPost("checkAccount/{username}")]

        public bool CheckAccount(string username)
        {
            //check account 

            return accountSv.CheckAccount(username);
        }


        //Create User
        [HttpPost("createUser/{user}")]

        public int CreateUser(TblUser user)
        {
            return userSv.CreateUser(user);
        }
        
        //Create Account
        [HttpPost("createAccount/{account}")]

        public bool CreateAccount(TblAccount account)
        {
            //check account 
           
            return accountSv.CreateAccount(account);
        }
        [HttpDelete("{Id}")]
        public bool Delete(int Id)
        {
            if (accountSv.Delete(Id))
            {
                return userSv.Delete(Id);
            }
            else
            {
                return accountSv.Delete(Id);
            }
          
        }
    }

}
