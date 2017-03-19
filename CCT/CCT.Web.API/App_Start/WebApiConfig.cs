using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;

namespace CCT.Web.API
{
    public static class WebApiConfig
    {
        public static void ConfigureWebApi(this IAppBuilder app, HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            app.UseWebApi(config);
        }
    }
}
