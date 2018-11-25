using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KgisReports.BO
{
    public class User : BaseBO<long>
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}