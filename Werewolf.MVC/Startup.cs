using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Werewolf.MVC.Startup))]
namespace Werewolf.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
