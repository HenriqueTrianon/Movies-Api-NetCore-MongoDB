using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Movies.Domain.Interfaces.Repository;
using Movies.Mongo.Repository.ExtensionMethods;
using Movies.Mongo.Repository.Interface;

namespace Movies.Mongo.Repository.Repository
{
    public abstract class BaseRepository<TModelDto, TModel> : IMongoDBRepository<TModelDto, TModel> 
    {
        protected IMongoClient Client { get; }
        protected IMongoDatabase Database { get; }
        protected IMongoCollection<TModel> Collection { get; }
        protected abstract string DatabaseName { get; }
        protected abstract string CollectionName { get; }
        protected BaseRepository(IMongoClient client)
        {
            Client = client;
            Database= Client.GetDatabase(DatabaseName);
            Collection = Database.GetCollection<TModel>(CollectionName);
        }
        public async Task Insert(TModelDto model)
        {
            await Collection.InsertOneAsync(AutoMapper.Mapper.Map<TModel>(model));
        }

        public async Task<List<TModelDto>> GetByField(string fieldName, string fieldValue)
        {
            return await Collection.Find(Builders<TModel>.Filter.Eq(fieldName, fieldValue)).ToListAsync().ConvertEach<TModel,TModelDto>();
        }

        public async Task<bool> Update(string id, string updateFieldName, string updateFieldValue)
        {
            var result = await Collection.UpdateOneAsync(Builders<TModel>.Filter.Eq("_id", id.ToObjectID()), Builders<TModel>.Update.Set(updateFieldName, updateFieldValue));
            return result.ModifiedCount != 0;
        }

        public async Task<bool> DeleteById(string id)
        {
            var result = await Collection.DeleteOneAsync(Builders<TModel>.Filter.Eq("_id", id.ToObjectID()));
            return result.DeletedCount != 0;
        }
    }
}
