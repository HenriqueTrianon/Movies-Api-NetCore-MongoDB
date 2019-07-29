using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces.Services
{
    public interface IService<TModelDTO, TModel>
    {
        Task Insert(TModelDTO model);
        Task<List<TModelDTO>> GetByField(string fieldName, string field);
        Task<List<TModelDTO>> GetAllAsync();
        Task<bool> Update(string id, string updateFieldName, string updateFieldValue);
        Task<bool> DeleteById(string id);
    }
}
