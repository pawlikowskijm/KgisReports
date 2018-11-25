﻿using KgisReports.BO;
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
    }
}