using Microsoft.Owin;
using Owin;
using Virgil;

[assembly: OwinStartup(typeof(Startup))]
namespace Virgil
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
