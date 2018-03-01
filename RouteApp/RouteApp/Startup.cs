using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RouteApp.Startup))]
namespace RouteApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
