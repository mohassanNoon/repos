using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ETutore.Startup))]
namespace ETutore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
