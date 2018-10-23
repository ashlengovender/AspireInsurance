using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projectthree.Startup))]
namespace Projectthree
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
