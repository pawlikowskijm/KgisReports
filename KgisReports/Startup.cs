using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KgisReports.Startup))]
namespace KgisReports
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
