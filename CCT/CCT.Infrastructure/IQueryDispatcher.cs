namespace CCT.Infrastructure
{
    public interface IQueryDispatcher
    {
        TResult Execute<TResult>(IQuery<TResult> query);
    }
}
