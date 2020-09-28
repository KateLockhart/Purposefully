using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Purposefully.WebMVC.Startup))]
namespace Purposefully.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
