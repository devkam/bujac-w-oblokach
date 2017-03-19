using CCT.Domain.Commands;
using System;

namespace CCT.Domain.Exceptions
{
    public class CommandHandlerNotFoundException<TCommand> : Exception where TCommand : ICommand
    {
        public CommandHandlerNotFoundException() : base($"Handler for `${typeof(TCommand).Name} was not found!")
        {
        }
    }
}
