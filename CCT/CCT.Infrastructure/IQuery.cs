namespace CCT.Infrastructure
{
    public interface IQuery<out TResult>
    {
        TResult Execute();
    }
}
