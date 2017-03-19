using CCT.Infrastructure.Entity;
using MongoDB.Driver;

namespace CCT.Infrastructure.Repository
{
    public class PlaintextRepository : IPlaintextRepository
    {
        private readonly IMongoDatabase _database;

        public PlaintextRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public int Add(Plaintext plaintext)
        {
            _database.GetCollection<Plaintext>(typeof(Plaintext).Name).InsertOne(plaintext);

            return plaintext.Id;
        }
    }
}
