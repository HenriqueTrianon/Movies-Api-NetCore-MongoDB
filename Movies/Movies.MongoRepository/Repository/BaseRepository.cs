using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Movies.Domain.Interfaces.Repository;
using Movies.Infra.Extensions;
using Movies.Infra.Persistence;
using Movies.Mongo.Repository.Context;
using Movies.Mongo.Repository.ExtensionMethods;
namespace Movies.Mongo.Repository.Repository
{
    public abstract class BaseRepository<TModelDto,TIndex, TModel> : IMongoDbRepository<TModel, TIndex, TModelDto> where TModel : IEntity<TIndex>
    {
        protected IMongoCollection<TModel> Collection { get; }
        protected abstract string CollectionName { get; }
        protected BaseRepository( MoviesContext context)
        {
            Collection = context.Database.GetCollection<TModel>(CollectionName);
        }
        public async Task Insert(TModelDto model) =>
            await Collection.InsertOneAsync(model.MapTo<TModel>());

        public async Task<List<TModelDto>> GetAll() =>
            await Collection.Find(Builders<TModel>.Filter.Empty).Project<TModelDto>(null).ToListAsync();
        

        public async Task<List<TModelDto>> GetByField(string fieldName, string fieldValue) =>
            await Collection.Find(Builders<TModel>.Filter.Eq(fieldName, fieldValue)).Project<TModelDto>(null).ToListAsync();

        public async Task<bool> Update(TIndex id, string updateFieldName, string updateFieldValue)
        {
            var result = await Collection.UpdateOneAsync(Builders<TModel>.Filter.Eq("_id", id.ToObjectID()),
                Builders<TModel>.Update.Set(updateFieldName, updateFieldValue));
            return result.ModifiedCount != 0;
        }

        //public async Task<bool> UpdateTask(TModelDto dto)
        //{
        //    var model = dto.MapTo<TModel>();
        //    await  Collection.UpdateOne(Builders<TModel>.Filter(model.Id),)
        //}

        public async Task<bool> DeleteById(TIndex id)
        {
            var result = await Collection.DeleteOneAsync(Builders<TModel>.Filter.Eq("_id", id.ToObjectID()));
            return result.DeletedCount != 0;
        }
    }
}
