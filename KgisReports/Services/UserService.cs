using KgisReports.BO;
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
            var hashedPass = Utils.PasswordHashEncryption(password);
            var userRepo = new UserRepository();
            
            var result = userRepo.Where(p => p.Login == login && p.Password == hashedPass).Any();
            return result;
        }

        

        public User GetUserByLogin(string login)
        {
            var userRepo = new UserRepository();
            return userRepo.GetByLogin(login);
        }
    }
}