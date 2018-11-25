using KgisReports.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KgisReports.Repositories
{
    public class UserRepository : BaseRepository<User, long>
    {
        public User GetByLogin(string login)
        {
            return Where(p => p.Login == login).SingleOrDefault();
        }
    }
}