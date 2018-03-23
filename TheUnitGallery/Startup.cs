using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheUnitGallery.Startup))]
namespace TheUnitGallery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
