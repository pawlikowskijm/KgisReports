using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MP.ReportingServices;

namespace KgisReports.Services
{
    public class ReportService
    {
        public byte[] GetReport(string path, List<ReportParameter> parameters, ReportFormats format)
        {
            ReportClient client = new ReportClient(Config.ReportingServiceServerPath);
            return client.GetReportBytes(path, format, parameters);
        }

        public List<ReportParameter> GetParametersWithoutMailParams(List<ReportParameter> reportParameters)
        {
            return reportParameters.Where(p => p.Name.ToLower().Contains("mail") == false).ToList();
        }
    }
}