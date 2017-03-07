using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Reflection;
using System.Web.Http.Dependencies;

namespace CCT.Web.API
{
    public class DependencyInjection
    {
        public static IContainer SetupDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(AppDomain.CurrentDomain.GetAssemblies());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<AutofacWebApiDependencyResolver>().As<IDependencyResolver>();

            return builder.Build();
        }
    }
}