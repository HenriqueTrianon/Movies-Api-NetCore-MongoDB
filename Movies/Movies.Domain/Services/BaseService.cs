using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Movies.Domain.Interfaces.Repository;
using Movies.Domain.Interfaces.Services;
using Movies.Infra.Persistence;

namespace Movies.Domain.Services
{
    public abstract class BaseService<TmodelDto, Tindex, TModel> : IService<TmodelDto, Tindex, TModel>
            where TModel : IEntity<Tindex>
    {
        protected IValidator<TmodelDto> Validator { get; }
        protected IMongoDbRepository<TModel, Tindex, TmodelDto> MongoDbRepository { get; }

        protected BaseService(IMongoDbRepository<TModel, Tindex, TmodelDto> repository, IValidator<TmodelDto> validator)
        {
            MongoDbRepository = repository;
            Validator = validator;
        }

        public async Task Validate(TmodelDto dto)
        {
            await Validator.ValidateAndThrowAsync(dto);
        }

        public async Task Insert(TmodelDto dto,bool validate = true)
        {
            if (validate)
            {
                await Validate(dto);
            }
            await MongoDbRepository.Insert(dto);
        }

        public async Task<List<TmodelDto>> GetAll()
        {
            return await MongoDbRepository.GetAll();
        }

        public async Task<List<TmodelDto>> GetAll(Expression<Func<TModel, bool>> func)
        {
            return await MongoDbRepository.GetAll(func);
        }

        public async Task<TmodelDto> GetFirstorDefault(Expression<Func<TModel, bool>> func)
        {
            return await MongoDbRepository.GetFirstOrDefault(func);
        }

        public async Task<TmodelDto> GetLastorDefault(Expression<Func<TModel, bool>> func)
        {
            return await MongoDbRepository.GetLastOrDefault(func);
        }

        public async Task Update(TmodelDto dto,bool validate = true)
        {
            if (validate)
            {
                await Validate(dto);
            }
            await MongoDbRepository.Update(dto);
        }

        public async Task<bool> DeleteById(Tindex id)
        {
            return await MongoDbRepository.Delete(id);
        }
    }
}