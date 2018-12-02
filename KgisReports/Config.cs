using KgisReports.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KgisReports
{
    public static class Config
    {
        public static User ApplicationUser { get; set; }
        public static string ExtraAccessLogin => "admin";
        public static string ExtraAccessPassword => "123!";
        public static User.UserRole ExtraAccessUserRole => User.UserRole.Admin;
        public static string ReportingServiceServerPath => "http://desktop-51p1738/ReportServer_SSRS";
        public static string SMTP_Host => "smtp.gmail.com";
        public static string SMTP_User => "michalpw159@gmail.com";
        public static string SMTP_Pass => "modecom02";
        public static int SMTP_Port = 587;
    }
}