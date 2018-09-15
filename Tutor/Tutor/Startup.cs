using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tutor.Startup))]
namespace Tutor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
