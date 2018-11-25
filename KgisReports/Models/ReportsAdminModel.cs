using MP.ReportingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KgisReports.Models
{
    public class ReportsAdminModel
    {
        public List<SelectListItem> ReportNames { get; set; }
        public List<ReportInfo> Reports { get; set; }
    }

    public class ReportsSendAdminModel
    {
        public ReportInfo Report { get; set; }
        public Dictionary<string, string> NamesEmails { get; set; }
    }
}