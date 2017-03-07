using Autofac;

namespace CCT.Infrastructure.Commands
{
    public interface ICommand
    {

    }

    public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
    {
        void Execute(TCommand command);
    }

    public interface ICommandHandler<in TCommand, out TReturn>
        where TCommand : ICommand
    {
        TReturn Execute(TCommand command);
    }

    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command)
            where TCommand : ICommand;

        TReturn Execute<TCommand, TReturn>(TCommand command)
            where TCommand : ICommand;
    }

    public class CommandDispatcher : ICommandDispatcher
    {

        private readonly ILifetimeScope _scope;

        public CommandDispatcher(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _scope.Resolve<ICommandHandler<TCommand>>();

            if (handler == null)
            {
                //throw new CommandHandlerNotFoundException<TCommand>();
            }

            handler.Execute(command);
        }

        public TReturn Execute<TCommand, TReturn>(TCommand command) where TCommand : ICommand
        {
            var handler = _scope.Resolve<ICommandHandler<TCommand, TReturn>>();

            if (handler == null)
            {
                //throw new CommandHandlerNotFoundException<TCommand>();
            }

            return handler.Execute(command);
        }
    }
}
