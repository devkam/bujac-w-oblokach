using Autofac;
using CCT.Infrastructure.Commands;
using CCT.Infrastructure.Queries;
using CCT.Infrastructure.Repository;
using MongoDB.Driver;
using System.Configuration;

namespace CCT.Infrastructure.DI
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterMongoDb(builder);
            RegisterCommands(builder);
            RegisterRepositories(builder);

            builder.RegisterType<QueryDispatcher>().AsImplementedInterfaces();
        }

        private void RegisterMongoDb(ContainerBuilder builder) {
            var client = new MongoClient(ConfigurationManager.AppSettings["DATABASE_CONNECTION_STRING"]);
            builder.Register(x => client.GetDatabase(ConfigurationManager.AppSettings["DATABASE_NAME"])).InstancePerRequest();
        }

        private void RegisterCommands(ContainerBuilder builder)
        {
            var commandDispatcherKey = "commandDispatcher";

            builder.RegisterType<CommandDispatcher>()
                .WithParameter(
                    (pi, _) => pi.ParameterType == typeof(ICommandDispatcher),
                    (_, ctx) => ctx.ResolveNamed<ICommandDispatcher>(commandDispatcherKey))
                .As<ICommandDispatcher>();

            builder.RegisterAssemblyTypes(typeof(ICommand).Assembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<>))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(ICommand).Assembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<,>))
                   .AsImplementedInterfaces();
        }

        private void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<PlaintextRepository>().AsImplementedInterfaces();
        }
    }
}
