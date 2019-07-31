using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Domain.Interfaces.Repository;
using Movies.Domain.Interfaces.Services;
using Movies.Infra.Persistence;

namespace Movies.Domain.Services
{
    public abstract class BaseService<TModelDao, TIndex,TModel>:IService<TModelDao, TIndex, TModel> where TModel : IEntity<TIndex>
    {
        
        protected IMongoDbRepository<TModel,TIndex,TModelDao> MongoDbRepository { get; }
        protected BaseService(IMongoDbRepository<TModel,TIndex,TModelDao> Repo)
        {
            MongoDbRepository = Repo;
        }

        public async Task Insert(TModelDao model) =>
            await MongoDbRepository.Insert(model);

        public async Task<List<TModelDao>> GetByField(string fieldName, string field) =>
            await MongoDbRepository.GetByField(fieldName, field);

        public async Task<List<TModelDao>> GetAllAsync() =>
            await MongoDbRepository.GetAll();

        public async Task<bool> Update(TIndex id, string updateFieldName, string updateFieldValue) =>
            await MongoDbRepository.Update(id, updateFieldName, updateFieldValue);

        public async Task<bool> DeleteById(TIndex id) =>
            await MongoDbRepository.DeleteById(id);
    }
}
