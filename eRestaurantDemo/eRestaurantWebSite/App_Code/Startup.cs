using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eRestaurantWebSite.Startup))]
namespace eRestaurantWebSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
