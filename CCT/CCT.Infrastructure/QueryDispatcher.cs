using MongoDB.Driver;

namespace CCT.Infrastructure
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IMongoDatabase _database;

        public QueryDispatcher(IMongoDatabase database)
        {
            _database = database;
        }

        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            return query.Execute(_database);
        }
    }
}
