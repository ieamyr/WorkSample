using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWork.Startup))]
namespace MyWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
