using MongoDB.Driver;

namespace CCT.Infrastructure
{
    public interface IQuery<out TResult>
    {
        TResult Execute(IMongoDatabase database);
    }
}
