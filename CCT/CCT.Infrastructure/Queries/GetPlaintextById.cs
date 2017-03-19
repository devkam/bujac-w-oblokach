using CCT.Domain.Domain;
using CCT.Infrastructure.Commons;
using CCT.Infrastructure.DTO;
using MongoDB.Driver;

namespace CCT.Infrastructure.Queries
{
    public class GetPlaintextById : IQuery<PlaintextDTO>
    {
        private readonly int _plaintextId;

        public GetPlaintextById(int plaintextId)
        {
            _plaintextId = plaintextId;
        }

        public PlaintextDTO Execute(IMongoDatabase database)
        {
            var filter = Builders<Plaintext>.Filter.Eq("id", _plaintextId);
            return database.GetCollection<Plaintext>(typeof(Plaintext).Name)
                .Find(filter)
                .First()
                .MapTo<PlaintextDTO>();
        }
    }
}
