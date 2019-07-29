using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Movies.Domain.Interfaces.Repository;
using Movies.Domain.Interfaces.Services;

namespace Movies.Domain.Services
{
    public abstract class BaseService<TModelDao,TModel>:IService<TModelDao,TModel>
    {
        
        protected IMongoDbRepository<TModel,TModelDao> MongoDbRepository { get; }
        protected IMapper Mapper { get; }
        protected BaseService(IMongoDbRepository<TModel,TModelDao> Repo)
        {
            MongoDbRepository = Repo;
        }

        public async Task Insert(TModelDao model) =>
            await MongoDbRepository.Insert(model);

        public async Task<List<TModelDao>> GetByField(string fieldName, string field) =>
            await MongoDbRepository.GetByField(fieldName, field);

        public async Task<List<TModelDao>> GetAllAsync() =>
            await MongoDbRepository.GetAll();


        public async Task<bool> Update(string id, string updateFieldName, string updateFieldValue) =>
            await MongoDbRepository.Update(id, updateFieldName, updateFieldValue);

        public async Task<bool> DeleteById(string id) =>
            await MongoDbRepository.DeleteById(id);
    }
}
