using KgisReports.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KgisReports.Startup))]
namespace KgisReports
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AppDbContext appDbContext = new AppDbContext();
            appDbContext.Users.Find(1);
        }
    }
}
