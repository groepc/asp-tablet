using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Plathe.Startup))]
namespace Plathe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
