using WebSiteBanThucPhamCN.Data;
using WebSiteBanThucPhamCN.Models;
namespace WebSiteBanThucPhamCN.Services
{
    public class UserSv
    {
        UserDb userDb = new UserDb();
        public TblUser GetProfileById(string Id)
        {
            return userDb.GetProfileById(Id);
        }
        public bool CheckEmail(string email)
        {
            return userDb.CheckEmail(email);
        }
        public int GetNumberUser()
        { 
        return userDb.GetNumberUser();
        }
            //create
            public int CreateUser(TblUser user)
        {
            return userDb.CreateUser(user);

        }
        //update

        public bool TrashUser(string user)
        {
           
            return userDb.TrashUser(user);
        }
        public bool UpdateProfile(TblUser user)
        {
            return userDb.UpdateProfile(user);
        }
        public bool Delete(int Id)
        {
            return userDb.Delete(Id);
        }
    }
}
