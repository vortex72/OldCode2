using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eClub.Startup))]
namespace eClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
