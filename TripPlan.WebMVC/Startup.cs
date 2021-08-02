using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TripPlan.WebMVC.Startup))]
namespace TripPlan.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
