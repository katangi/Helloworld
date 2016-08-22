using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingMvc.Startup))]
namespace ShoppingMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
