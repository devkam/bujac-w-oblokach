namespace CCT.Domain
{
    public interface ICommandBus
    {
        void Handle<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
