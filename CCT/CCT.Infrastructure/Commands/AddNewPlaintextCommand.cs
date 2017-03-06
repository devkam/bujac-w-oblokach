using System;

namespace CCT.Infrastructure.Commands
{
    public class AddNewPlaintextCommand : ICommand
    {
        public Guid Id;
        public readonly string Content;

        public AddNewPlaintextCommand(Guid id, string content)
        {
            Id = id;
            Content = content;
        }
    }
}
