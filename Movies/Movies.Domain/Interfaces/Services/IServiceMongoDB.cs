using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces.Services
{
    public interface IServiceMongoDb<TModelDao>
    {
        Task Insert(TModelDao model);
        Task<List<TModelDao>> GetByField(string fieldName, string field);
        Task<bool> Update(string id, string updateFieldName, string updateFieldValue);
        Task<bool> DeleteById(string id);
    }
}
