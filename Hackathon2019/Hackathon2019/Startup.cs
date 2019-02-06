using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hackathon2019.Startup))]
namespace Hackathon2019
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
