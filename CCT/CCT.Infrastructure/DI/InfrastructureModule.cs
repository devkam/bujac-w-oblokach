﻿using Autofac;
using CCT.Domain;
using CCT.Domain.Repositories;
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
            AutoMapperConfig.CreateMap();

            builder.RegisterType<QueryDispatcher>().AsImplementedInterfaces();
        }

        private void RegisterMongoDb(ContainerBuilder builder) {
            var client = new MongoClient(ConfigurationManager.AppSettings["DATABASE_CONNECTION_STRING"]);
            builder.Register(x => client.GetDatabase(ConfigurationManager.AppSettings["DATABASE_NAME"])).InstancePerRequest();
        }

        private void RegisterCommands(ContainerBuilder builder)
        {
            var commandDispatcherKey = "commandDispatcher";

            builder.RegisterType<CommandBus>()
                .WithParameter(
                    (pi, _) => pi.ParameterType == typeof(ICommandBus),
                    (_, ctx) => ctx.ResolveNamed<ICommandBus>(commandDispatcherKey))
                .As<ICommandBus>();

            builder.RegisterAssemblyTypes(typeof(ICommand).Assembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<>))
                   .AsImplementedInterfaces();
        }

        private void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<PlaintextRepository>().AsImplementedInterfaces();
        }
    }
}
