using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pawfect.Startup))]
namespace Pawfect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
