using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bikers.Startup))]
namespace Bikers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
