namespace CCT.Infrastructure
{
    public interface ICommandBus
    {
        void Handle<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
