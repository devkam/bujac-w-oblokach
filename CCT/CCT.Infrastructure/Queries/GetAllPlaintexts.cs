using CCT.Domain.Domain;
using CCT.Infrastructure.Commons;
using CCT.Infrastructure.DTO;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CCT.Infrastructure.Queries
{
    public class GetAllPlaintexts : IQuery<IEnumerable<PlaintextDTO>>
    {
        public IEnumerable<PlaintextDTO> Execute(IMongoDatabase database)
        {
            return database.GetCollection<Plaintext>(typeof(Plaintext).Name)
                .Find(Builders<Plaintext>.Filter.Empty)
                .SortBy(plaintext => plaintext.Id)
                .ToList()
                .MapTo<PlaintextDTO>();
        }
    }
}
