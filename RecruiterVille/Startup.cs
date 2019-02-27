using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecruiterVille.Startup))]
namespace RecruiterVille
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
