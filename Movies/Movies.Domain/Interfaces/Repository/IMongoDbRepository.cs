using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Infra.Persistence;

namespace Movies.Domain.Interfaces.Repository
{
    public interface IMongoDbRepository<TModel, in TIndex,TModelDto> where TModel: IEntity<TIndex>
    {
        Task Insert(TModelDto model);
        Task<List<TModelDto>> GetByField(string fieldName, string field);
        Task<List<TModelDto>> GetAll();
        Task<bool> Update(TIndex id, string updateFieldName, string updateFieldValue);
        Task<bool> DeleteById(TIndex id);
    }
}