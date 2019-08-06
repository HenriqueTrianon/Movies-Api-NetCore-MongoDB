using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Movies.Domain.Interfaces.Services
{
    public interface IService<TModelDTO, in TIndex, TModel>
    {
        Task Validate(TModelDTO dto);
        Task Insert(TModelDTO dto, bool validate = true);
        Task<List<TModelDTO>> GetAll();
        Task<List<TModelDTO>> GetAll(Expression<Func<TModel, bool>> func);
        Task<TModelDTO> GetFirstorDefault(Expression<Func<TModel, bool>> func);
        Task<TModelDTO> GetLastorDefault(Expression<Func<TModel, bool>> func );
        Task Update(TModelDTO dto, bool validate = true);
        Task<bool> DeleteById(TIndex id);
    }
}