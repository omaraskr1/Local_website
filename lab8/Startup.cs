using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab8.Startup))]
namespace lab8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
