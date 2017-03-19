using CCT.Domain.Domain;
using MongoDB.Driver;

namespace CCT.Domain.Repositories
{
    public class PlaintextRepository : IPlaintextRepository
    {
        private readonly IMongoDatabase _database;

        public PlaintextRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public void Add(Plaintext plaintext)
        {
            _database.GetCollection<Plaintext>(typeof(Plaintext).Name).InsertOne(plaintext);
        }
    }
}
