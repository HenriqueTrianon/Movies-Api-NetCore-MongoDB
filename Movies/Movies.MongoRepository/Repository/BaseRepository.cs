using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Movies.Domain.Interfaces.Repository;
using Movies.MongoRepository.ExtensionMethods;

namespace Tmodels.MongoRepository.Repository
{
    public abstract class BaseRepository<Tmodel>:IMongoDBRepository<Tmodel>
    {

        protected IMongoClient Client { get; }
        protected IMongoDatabase Database { get; }
        protected IMongoCollection<Tmodel> Collection { get; }
        
        protected abstract string DatabaseName { get; }
        protected abstract string CollectionName { get; }
        protected BaseRepository(IMongoClient client)
        {
            Client = client;
            Database= Client.GetDatabase(DatabaseName);
            Collection = Database.GetCollection<Tmodel>(CollectionName);
        }
        public async Task Insert(Tmodel model)
        {
            await Collection.InsertOneAsync(model);
        }

        public async Task<List<Tmodel>> GetByField(string fieldName, string fieldValue)
        {
            return await Collection.Find(Builders<Tmodel>.Filter.Eq(fieldName, fieldValue)).ToListAsync();
        }

        public async Task<bool> Update(string id, string updateFieldName, string updateFieldValue)
        {
            var result = await Collection.UpdateOneAsync(Builders<Tmodel>.Filter.Eq("_id", id.ToObjectID()), Builders<Tmodel>.Update.Set(updateFieldName, updateFieldValue));
            return result.ModifiedCount != 0;
        }

        public async Task<bool> DeleteById(string id)
        {
            var result = await Collection.DeleteOneAsync(Builders<Tmodel>.Filter.Eq("_id", id.ToObjectID()));
            return result.DeletedCount != 0;
        }
    }
}
