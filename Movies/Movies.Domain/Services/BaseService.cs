using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Movies.Domain.Interfaces.Repository;
using Movies.Domain.Interfaces.Services;
using Movies.Infra.Persistence;

namespace Movies.Domain.Services
{
    public abstract class BaseService<TmodelDto, Tindex, TModel> : IService<TmodelDto, Tindex, TModel> where TModel : IEntity<Tindex>
    {
        protected IMongoDbRepository<TModel, Tindex, TmodelDto> MongoDbRepository { get; }
        protected BaseService(IMongoDbRepository<TModel, Tindex, TmodelDto> repository)
        {
            MongoDbRepository = repository;
        }

        public async Task Insert(TmodelDto model) =>
            await MongoDbRepository.Insert(model);

        public async Task<List<TmodelDto>> GetAll() =>
            await MongoDbRepository.GetAll();

        public async Task<List<TmodelDto>> GetAll(Expression<Func<TModel, bool>> func) =>
            await MongoDbRepository.GetAll(func);

        public async Task<TmodelDto> GetFirstorDefault(Expression<Func<TModel, bool>> func) =>
            await MongoDbRepository.GetFirstOrDefault(func);

        public async Task Update(TmodelDto dto) =>
            await MongoDbRepository.Update(dto);

        public async Task<bool> DeleteById(Tindex id) =>
            await MongoDbRepository.Delete(id);

    }
}
