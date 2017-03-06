using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
