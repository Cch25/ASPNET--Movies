using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Filme.Startup))]
namespace Filme
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
