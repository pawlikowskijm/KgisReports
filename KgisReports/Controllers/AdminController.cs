using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KgisReports.Models;
using KgisReports.Services;
using MP.ReportingServices;

namespace KgisReports.Controllers
{
    public class AdminController : Controller
    {
        ReportClient _client = new ReportClient(Config.ReportingServiceServerPath);
        EmailService _emailService = new EmailService();
        ReportService _reportService = new ReportService();

        // GET: Admin
        public ActionResult Index()
        {
            
            var availableReports = _client.GetReportsInfo();

            var model = new ReportsAdminModel 
            {
                ReportNames = availableReports.Select(p => new SelectListItem { Text = p.Name, Value = p.Path }).ToList()
            };
            return View(model);
        }

        public ActionResult ReportWithMailingList(string path)
        {
            var report = _client.GetReportInfo(path);
            var employeesNamesEmails = _emailService.GetEmployeesNamesAndEmails();
            
            var model = new ReportsSendAdminModel
            {
                Report = report,
                Emails = employeesNamesEmails.Select(p => p.Key).ToList(),
                EmailsDisplay = employeesNamesEmails.ToDictionary(p => p.Key, p => p.Value),
                HasParameters = _reportService.GetParametersWithoutMailParams(report.Parameters).Any(),
                HasMailingList = employeesNamesEmails.Any(),
                ChosenEmails = employeesNamesEmails.Select(p => true).ToList()
            };

            return View(model);
        }

        public ActionResult ReportAfterSend(ReportsSendAdminModel model)
        {
            var emailsToSend = new List<string>();
            for (int i = 0; i < model.Emails.Count; i++)
            {
                if (model.ChosenEmails[i])
                {
                    emailsToSend.Add(model.Emails[i]);
                }
            }

            _emailService.SendMails(model.Report.Parameters, model.Report.Name, model.Report.Path, emailsToSend, model.EmailSubject, model.EmailContent);
            return View();
        }

        
    }
}