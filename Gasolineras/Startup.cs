using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gasolineras.Startup))]
namespace Gasolineras
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
