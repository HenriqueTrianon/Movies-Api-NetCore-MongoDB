using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Movies.Infra.Persistence;

namespace Movies.Domain.Interfaces.Repository
{
    public interface IMongoDbRepository<TModel, in TIndex,TModelDto> where TModel: IEntity<TIndex>
    {
        Task Insert(TModelDto model);
        Task<List<TModelDto>> GetAll(Expression<Func<TModel, bool>> func);
        Task<List<TModelDto>> GetAll();
        Task<TModelDto> GetFirstOrDefault(Expression<Func<TModel, bool>> func);
        Task Update(TModelDto model);
        Task<bool> Delete(TIndex id);
    }
}