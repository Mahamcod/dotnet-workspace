using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WEBAPPLICATION.Startup))]
namespace WEBAPPLICATION
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
