using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Mongo.Repository.Interface
{
    public interface IMongoDBRepository<TModelDao,TModel>
    {
        Task Insert(TModelDao model);
        Task<List<TModelDao>> GetByField(string fieldName, string field);
        Task<bool> Update(string id, string updateFieldName, string updateFieldValue);
        Task<bool> DeleteById(string id);
    }
}