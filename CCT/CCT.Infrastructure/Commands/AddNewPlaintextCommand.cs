using System;

namespace CCT.Infrastructure.Commands
{
    public class AddNewPlaintextCommand : ICommand
    {
        public readonly string Content;

        public AddNewPlaintextCommand(string content)
        {
            Content = content;
        }
    }
}
