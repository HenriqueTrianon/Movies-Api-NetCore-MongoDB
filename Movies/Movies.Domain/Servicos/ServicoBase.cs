using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Movies.Domain.Interfaces.Repository;
using Movies.Domain.Interfaces.Services;

namespace Movies.Domain.Servicos
{
    public class ServicoBase<Tmodel>:IServicoMongoDB<Tmodel>
    {
        
        protected  IMongoDBRepository<Tmodel> mongoDbRepository { get; }

        public ServicoBase()
        {
            
        }
        public async Task Insert(Tmodel model)
        {
            await mongoDbRepository.Insert(model);
        }

        public async Task<List<Tmodel>> GetByField(string fieldName, string field)
        {
            return await mongoDbRepository.GetByField(fieldName, field);
        }

        public async Task<bool> Update(string id, string updateFieldName, string updateFieldValue)
        {
            return await mongoDbRepository.Update(id, updateFieldName, updateFieldValue);
        }

        public async Task<bool> DeleteById(string id)
        {
            return await mongoDbRepository.DeleteById(id);
        }
    }
}
