using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CCT.Web.API.Startup))]

namespace CCT.Web.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
