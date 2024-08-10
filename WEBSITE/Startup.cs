using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEBSITE.Startup))]
namespace WEBSITE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
