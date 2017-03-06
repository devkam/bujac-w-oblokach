using CCT.Infrastructure.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;

namespace CCT.Infrastructure.Queries
{
    public class GetAllPlaintexts : IQuery<IEnumerable<Plaintext>>
    {
        public IEnumerable<Plaintext> Execute(IMongoDatabase database) 
        {
            return database.GetCollection<Plaintext>(typeof(Plaintext).Name)
                .Find(Builders<Plaintext>.Filter.Empty)
                .SortBy(plaintext => plaintext.Id)
                .ToList();
        }
    }
}
