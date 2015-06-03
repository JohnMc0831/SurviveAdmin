using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurviveAdmin.Startup))]
namespace SurviveAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
