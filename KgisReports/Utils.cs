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
                Config.ApplicationUser = new BO.User { Login = login };
            }
        }
    }
}