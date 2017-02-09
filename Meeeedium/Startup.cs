using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Meeeedium.Startup))]
namespace Meeeedium
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
