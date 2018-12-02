using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MP.EMAIL;
using MP.ReportingServices;

namespace KgisReports.Services
{
    public class EmailService
    {
        string _connString => System.Configuration.ConfigurationManager.ConnectionStrings["ReportsDataConnection"].ConnectionString;

        public Dictionary<string, string> GetEmployeesNamesAndEmails()
        {
            Dictionary<string, string> namesEmails = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(Properties.Settings.Default.SQL_Select_EmailName, conn))
                {
                    var sqlReader = comm.ExecuteReader();
                    var tb = new DataTable();
                    tb.Load(sqlReader);
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        var values = tb.Rows[i].ItemArray;
                        if (!namesEmails.ContainsKey(values.First().ToString()))
                        {
                            namesEmails.Add(values.First().ToString(), values.Last().ToString());
                        }
                    }
                }
                conn.Close();
            }
            return namesEmails;
        }

        public bool SendEmail(string emailAddress, KeyValuePair<string, byte[]> attachment, string mailSubject, string mailContent)
        {
            EmailSender emailSender = new EmailSender(Config.SMTP_Host, Config.SMTP_User, Config.SMTP_Pass, Config.SMTP_Port);
            var mailAttachment = new Attachment(attachment.Key, attachment.Value, Attachment.ContentType.PDF);
            var email = new Email(Config.SMTP_User, emailAddress, mailSubject, mailContent, new List<Attachment> { mailAttachment });
            emailSender.SendEmailWithAttachment(email);
            return true;
        }

        public void SendMails(List<ReportParameter> reportParameters, string reportName, string reportPath, List<string> emailsToSend, string mailSubject, string mailContent)
        {
            var reportService = new ReportService();

            var parametersWithoutMailParams = reportService.GetParametersWithoutMailParams(reportParameters);
            var mailParams = reportParameters.Except(parametersWithoutMailParams);

            foreach (var email in emailsToSend)
            {
                foreach (var param in mailParams)
                {
                    param.Value = email;
                }
                var parameters = parametersWithoutMailParams.Union(mailParams).ToList();
                var reportBytes = reportService.GetReport(reportPath, parameters, ReportFormats.Pdf);
                SendEmail(email, new KeyValuePair<string, byte[]>($"{reportName}.pdf", reportBytes), mailSubject, mailContent);
            }
        }
    }
}