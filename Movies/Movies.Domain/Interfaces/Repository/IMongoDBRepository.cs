using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces.Repository
{
    public interface IMongoDBRepository<Tmodel>
    {
        Task Insert(Tmodel model);
        Task<List<Tmodel>> GetByField(string fieldName, string field);
        Task<bool> Update(string id, string updateFieldName, string updateFieldValue);
        Task<bool> DeleteById(string id);
    }
}