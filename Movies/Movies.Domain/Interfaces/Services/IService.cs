using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces.Services
{
    public interface IService<TModelDTO, in TIndex,TModel>
    {
        Task Insert(TModelDTO model);
        Task<List<TModelDTO>> GetAll();
        Task<List<TModelDTO>> GetAll(Expression<Func<TModel, bool>> func);
        Task<TModelDTO> GetFirstorDefault(Expression<Func<TModel, bool>> func);
        Task Update(TModelDTO dto);
        Task<bool> DeleteById(TIndex id);
    }
}
