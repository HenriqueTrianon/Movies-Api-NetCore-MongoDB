using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces.Services
{
    public interface IService<TModelDTO, TIndex, TModel>
    {
        Task Insert(TModelDTO model);
        Task<List<TModelDTO>> GetByField(string fieldName, string field);
        Task<List<TModelDTO>> GetAllAsync();
        Task<bool> Update(TIndex id, string updateFieldName, string updateFieldValue);
        Task<bool> DeleteById(TIndex id);
    }
}
