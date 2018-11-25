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
        EmployeeService _employeeService = new EmployeeService();

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

        public ActionResult ReportCheckParameters(string path)
        {
            var reportInfo = _client.GetReportInfo(path);
            if (reportInfo.Parameters.Any())
            {
                return RedirectToAction(nameof(ReportWithParameters), reportInfo);
            }
            else
            {
                return RedirectToAction(nameof(ReportWithoutParameters), reportInfo);
            }
        }

        public ActionResult ReportWithoutParameters(ReportInfo reportInfo)
        {
            var model = new ReportsSendAdminModel { Report = reportInfo };

            return View(model);
        }

        public ActionResult ReportWithParameters(ReportInfo reportInfo)
        {
            var employeesNamesEmails =_employeeService.GetEmployeesNamesAndEmails(true);
            var model = new ReportsSendAdminModel { Report = reportInfo, NamesEmails = employeesNamesEmails };

            return View(model);
        }

        public ActionResult ReportSendPage(ReportInfo reportInfo)
        {
            

            return View();
        }
    }
}