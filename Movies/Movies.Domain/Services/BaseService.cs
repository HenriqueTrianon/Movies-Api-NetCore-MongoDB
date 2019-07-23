using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Domain.Interfaces.Services;

namespace Movies.Domain.Services
{
    public class BaseService<TModelDao>:IServiceMongoDb<TModelDao>
    {
        
        protected IMongoDBRepository<TModelDao> MongoDbRepository { get; }

        public BaseService()
        {
            
        }
        public async Task Insert(TModelDao model)
        {
            await MongoDbRepository.Insert(model);
        }

        public async Task<List<TModelDao>> GetByField(string fieldName, string field)
        {
            return await MongoDbRepository.GetByField(fieldName, field);
        }

        public async Task<bool> Update(string id, string updateFieldName, string updateFieldValue)
        {
            return await MongoDbRepository.Update(id, updateFieldName, updateFieldValue);
        }

        public async Task<bool> DeleteById(string id)
        {
            return await MongoDbRepository.DeleteById(id);
        }
    }
}
