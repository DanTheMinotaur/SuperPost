using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperPost.Startup))]
namespace SuperPost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
