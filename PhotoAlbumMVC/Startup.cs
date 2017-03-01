using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhotoAlbumMVC.Startup))]
namespace PhotoAlbumMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
