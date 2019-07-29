using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using Movies.Domain.DTO;
using Movies.Domain.Interfaces.Repository;
using Movies.Domain.Models;
using Movies.Mongo.Repository.ExtensionMethods;
namespace Movies.Mongo.Repository.Repository
{
    public abstract class BaseRepository<TModelDto, TModel> : IMongoDbRepository<TModel, TModelDto> 
    {
        protected IMongoClient Client { get; }
        protected IMongoDatabase Database { get; }
        protected IMongoCollection<TModel> Collection { get; }
        protected abstract string DatabaseName { get; }
        protected abstract string CollectionName { get; }
        protected IMapper Mapper { get; }
        protected BaseRepository(IMongoClient client,IMapper mapper)
        {
            Client = client;
            Database= Client.GetDatabase(DatabaseName);
            Collection = Database.GetCollection<TModel>(CollectionName);
            Mapper = mapper;
        }
        public async Task Insert(TModelDto model) =>
            await Collection.InsertOneAsync(Mapper.Map<TModel>(model));

        public async Task<List<TModelDto>> GetAll() =>
            await Collection.Find(null).Project<TModelDto>(null).ToListAsync();
        public async Task<List<TModelDto>> GetByField(string fieldName, string fieldValue) =>
            await Collection.Find(Builders<TModel>.Filter.Eq(fieldName, fieldValue)).Project<TModelDto>(null).ToListAsync();

        public async Task<bool> Update(string id, string updateFieldName, string updateFieldValue)
        {
            var result = await Collection.UpdateOneAsync(Builders<TModel>.Filter.Eq("_id", id.ToObjectID()),
                Builders<TModel>.Update.Set(updateFieldName, updateFieldValue));
            return result.ModifiedCount != 0;
        }

        public async Task<bool> DeleteById(string id)
        {
            var result = await Collection.DeleteOneAsync(Builders<TModel>.Filter.Eq("_id", id.ToObjectID()));
            return result.DeletedCount != 0;
        }
    }
}
