using MP.ReportingServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public Dictionary<string, string> EmailsDisplay { get; set; }
        public List<string> Emails { get; set; }
        public List<bool> ChosenEmails { get; set; }
        public bool HasParameters { get; set; }
        public bool HasMailingList { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Proszę wpisać temat wiadomości")]
        [Display(Name = "Temat wiadomości")]
        public string EmailSubject { get; set; }
        [Display(Name = "Wiadomość")]
        public string EmailContent { get; set; }
    }
}