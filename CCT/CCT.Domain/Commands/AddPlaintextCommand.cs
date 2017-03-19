namespace CCT.Domain.Commands
{
    public class AddPlaintextCommand : ICommand
    {
        public readonly string Content;

        public AddPlaintextCommand(string content)
        {
            Content = content;
        }
    }
}
