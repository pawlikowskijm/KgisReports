using KgisReports.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace KgisReports
{
    public static class Utils
    {
        public static string PasswordHashEncryption(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static void SetApplicationUser(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                Config.ApplicationUser = null;
            }
            else
            {
                var userService = new UserService();
                var user = userService.GetUserByLogin(login);
                Config.ApplicationUser = user ?? throw new ApplicationException("Nie znaleziono użytkownika o podanym loginie!");
            }
        }

        public static void SetExtraAccessUser()
        {
            Config.ApplicationUser = new BO.User { Login = Config.ExtraAccessLogin, Role = Config.ExtraAccessUserRole };
        }

        public static bool IsExtraAccess(string login, string password)
        {
            if (login == Config.ExtraAccessLogin && password == Config.ExtraAccessPassword)
            {
                return true;
            }
            return false;
        }
    }
}