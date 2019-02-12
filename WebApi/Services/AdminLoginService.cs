using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public class AdminLoginService : IAdminLoginService
    {
        public AdminLoginService()
        { }

        public User FindByUsername(string username)
        {
            var user = new User() { UserId = "001", UserName = "zhangsan", Password="123" };//实际应从数据库查出User

            if (user == null) { return null; }

            if (username == user.UserName) 
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public bool ValidateAdminUser(User user, string loginPassword)
        {
            if (user == null) { return false; }

            if (user.Password == loginPassword)
                return true;
            else
                return false;
        }
    }
}
