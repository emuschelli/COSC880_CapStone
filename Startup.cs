using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WarApp.Startup))]
namespace WarApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
