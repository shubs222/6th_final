using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NHUB.Startup))]
namespace NHUB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
