using KgisReports.Models;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using System.Data.Entity.Migrations;

[assembly: OwinStartupAttribute(typeof(KgisReports.Startup))]
namespace KgisReports
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AppDbContext appDbContext = new AppDbContext();
            
            if (!appDbContext.Database.CompatibleWithModel(false))
            {
                
                //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, DbMigrationsConfiguration<AppDbContext>>("DefaultConnection"));
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppDbContext>());
            }
            
            appDbContext.Users.Find(1);
        }
    }
}
