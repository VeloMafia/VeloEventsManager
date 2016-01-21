using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VeloEventsManager.Web.Startup))]
namespace VeloEventsManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}