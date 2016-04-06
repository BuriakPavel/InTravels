using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InTravels.Startup))]
namespace InTravels
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
