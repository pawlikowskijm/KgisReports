using KgisReports.BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KgisReports.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}