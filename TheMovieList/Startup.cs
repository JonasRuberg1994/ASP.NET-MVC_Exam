using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheMovieList.Startup))]
namespace TheMovieList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
