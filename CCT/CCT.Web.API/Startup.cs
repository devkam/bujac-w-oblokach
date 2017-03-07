using Autofac;
using Owin;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace CCT.Web.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = DependencyInjection.SetupDependencyInjection();

            var config = new HttpConfiguration
            {
                DependencyResolver = container.Resolve<IDependencyResolver>()
            };

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.ConfigureWebApi(config);
        }
    }
}
