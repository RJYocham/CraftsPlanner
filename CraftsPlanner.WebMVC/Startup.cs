using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CraftsPlanner.WebMVC.Startup))]
namespace CraftsPlanner.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
