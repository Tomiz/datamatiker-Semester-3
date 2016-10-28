using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyRESTClient.Startup))]
namespace MyRESTClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
