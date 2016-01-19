using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VeloEventsManager.Startup))]
namespace VeloEventsManager
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
