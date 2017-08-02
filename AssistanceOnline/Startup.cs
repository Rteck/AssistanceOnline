using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssistanceOnline.Startup))]
namespace AssistanceOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
