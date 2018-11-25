using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KgisReports.Services
{
    public class EmployeeService
    {
        string _connString => System.Configuration.ConfigurationManager.ConnectionStrings["ReportsDataConnection"].ConnectionString;

        public Dictionary<string, string> GetEmployeesNamesAndEmails(bool onlyActive)
        {
            Dictionary<string, string> namesEmails = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = "SELECT Pracownik, email FROM dbo.Pracownicy";
                    var parameter = new SqlParameter("Aktywny", onlyActive);
                    comm.Parameters.Add(parameter);
                    var sqlReader = comm.ExecuteReader();
                    var tb = new DataTable();
                    tb.Load(sqlReader);
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        var values = tb.Rows[i].ItemArray;
                        namesEmails.Add(values.First().ToString(), values.Last().ToString());
                    }
                }
                conn.Close();
            }
            return namesEmails;
        }
    }
}