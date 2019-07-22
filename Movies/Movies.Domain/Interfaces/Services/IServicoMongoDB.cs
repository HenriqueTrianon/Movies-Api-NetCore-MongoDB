using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces.Services
{
    interface IServicoMongoDB<Tmodel>
    {
        Task Insert(Tmodel model);
        Task<List<Tmodel>> GetByField(string fieldName, string field);
        Task<bool> Update(string id, string updateFieldName, string updateFieldValue);
        Task<bool> DeleteById(string id);
    }
}
