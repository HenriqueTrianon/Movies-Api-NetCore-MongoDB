using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces.Repository
{
    public interface IMongoDbRepository<TModel,TModelDto>
    {
        Task Insert(TModelDto model);
        Task<List<TModelDto>> GetByField(string fieldName, string field);
        Task<List<TModelDto>> GetAll();
        Task<bool> Update(string id, string updateFieldName, string updateFieldValue);
        Task<bool> DeleteById(string id);
    }
}