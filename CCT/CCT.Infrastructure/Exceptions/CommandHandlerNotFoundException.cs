using CCT.Infrastructure.Commands;
using System;

namespace CCT.Infrastructure.Exceptions
{
    public class CommandHandlerNotFoundException<TCommand> : Exception where TCommand : ICommand
    {
        public CommandHandlerNotFoundException() : base($"Handler for `${typeof(TCommand).Name} was not found!")
        {
        }
    }
}
