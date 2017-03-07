using CCT.Infrastructure.Entity;
using MongoDB.Driver;

namespace CCT.Infrastructure.Queries
{
    public class GetPlaintextById : IQuery<Plaintext>
    {
        private readonly int _plaintextId;

        public GetPlaintextById(int plaintextId)
        {
            _plaintextId = plaintextId;
        }

        public Plaintext Execute(IMongoDatabase database)
        {
            var filter = Builders<Plaintext>.Filter.Eq("id", _plaintextId);
            return database.GetCollection<Plaintext>(typeof(Plaintext).Name).Find(filter).First();
        }
    }
}
