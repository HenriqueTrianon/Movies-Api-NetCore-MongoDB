using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using Movies.Domain.Interfaces.Repository;
using Movies.Infra.Extensions;
using Movies.Infra.Persistence;
using Movies.Mongo.Repository.Context;

namespace Movies.Mongo.Repository.Repository
{
    public abstract class BaseRepository<TModelDto, TIndex, TModel> : IMongoDbRepository<TModel, TIndex, TModelDto>
            where TModel : IEntity<TIndex>
    {
        protected IMongoCollection<TModel> Collection { get; }
        protected abstract string CollectionName { get; }

        protected BaseRepository(MoviesContext context)
        {
            Collection = context.Database.GetCollection<TModel>(CollectionName);
        }

        public async virtual Task Insert(TModelDto dto)
        {
            var model = dto.MapTo<TModel>();
            await Collection.InsertOneAsync(model);
        }

        public async virtual Task<List<TModelDto>> GetAll()
        {
            return await Collection.Find(Builders<TModel>.Filter.Empty)
                    .Project<TModelDto>(null)
                    .ToListAsync();
        }

        public async virtual Task<TModelDto> GetFirstOrDefault(Expression<Func<TModel, bool>> func)
        {
            return  await Collection.Find(func)
                    .Project<TModelDto>(null)
                    .FirstOrDefaultAsync();
        }

        public async virtual Task<TModelDto> GetLastOrDefault(Expression<Func<TModel, bool>> func)
        {
            return await Collection.Find(func)
                    .SortByDescending(e => e.Id)
                    .Project<TModelDto>(null)
                    .FirstOrDefaultAsync();
        }

        public async virtual Task Update(TModelDto dto)
        {
            var model = dto.MapTo<TModel>();
            await Collection.ReplaceOneAsync(b => b.Id.Equals(model.Id), model, new UpdateOptions
            {
                    IsUpsert = true
            });
        }

        public async virtual Task<List<TModelDto>> GetAll(Expression<Func<TModel, bool>> func)
        {
            return await Collection.Find(func)
                    .Project<TModelDto>(null)
                    .ToListAsync();
        }

        public async virtual Task<bool> Delete(TIndex id)
        {
            var result = await Collection.DeleteOneAsync(b => b.Id.Equals(id));
            return result.DeletedCount != 0;
        }
    }
}
