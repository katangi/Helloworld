using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingMvc.Models;
using DataAccessLayer;
using System.Data;

namespace BussinessLayer
{
  public  class UserBL
    {
        #region SaveUser

        UserDL userDL = new UserDL();
        public int SaveUser(User user)
        {

            int a = userDL.SaveUser(user);
            return a;
        }

        #endregion SaveUser
        public int UpdateUser(User user)
        {

            int a = userDL.UpdateUser(user);
            return a;
        }
        public DataTable GetLoginDetail(UserLogin user)
        {
            DataTable dtUser = null;
            try {
                dtUser = userDL.GetLoginDetail(user);
            }
            catch(Exception e)
            {
                throw (e);
            }
            return dtUser;
        }

        public List<User>GetAllUser()
        {
            List<User> userList = userDL.GetAllUser();
            return userList;
        }

        public User GetUserById(int id)
        {
            User user = userDL.GetUserById(id);
            return user;
        }
        public User MyprofileById(int id)
        {
            User user = userDL.MyProfileById(id);
            return user;
        }
        public int DeleteUser(User user)
        {
            int a= userDL.DeleteUser(user);
            return a;
        }
       
    }
}
