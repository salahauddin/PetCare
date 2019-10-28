using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PAWFETNEW.Startup))]
namespace PAWFETNEW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
