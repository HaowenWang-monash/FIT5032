using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_5032_Assignment.Startup))]
namespace _5032_Assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
