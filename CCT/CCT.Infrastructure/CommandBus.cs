using Autofac;
using CCT.Domain;
using CCT.Domain.Exceptions;

namespace CCT.Infrastructure
{
    public class CommandBus : ICommandBus
    {
        private readonly ILifetimeScope _scope;

        public CommandBus(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public void Handle<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _scope.Resolve<ICommandHandler<TCommand>>();
            if (handler == null)
            {
                throw new CommandHandlerNotFoundException<TCommand>();
            }

            handler.Handle(command);
        }
    }
}
