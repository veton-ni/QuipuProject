using Application.Common.DateTimeContract;
using Application.Persistence;
using Application.Persistence.Repository;
using Application.Service;
using Domain.Entity;
using System.Linq.Expressions;

namespace Infrastructure.Service
{
    public class ServiceBase<T> : IBaseService<T> where T : BaseEntity
    {

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IDateTimeProvider _dateTime;
        protected readonly IRepository<T> _repository;


        public ServiceBase(IUnitOfWork unitOfWork, IRepository<T> repository, IDateTimeProvider dateTime)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _dateTime = dateTime;
        }
        public async Task<T> Add(T entity)
        {
            entity.CreateDate = _dateTime.Now;
            _repository.Add(entity);
            await _unitOfWork.Complete();
            return entity;
        }

        public async Task<IEnumerable<T>> Add(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreateDate = _dateTime.Now;
            }

            _repository.AddRange(entities);
            await _unitOfWork.Complete();
            return entities;

        }

        public async Task<int> Change(Guid id, T entity)
        {
            entity.Id = id;

            entity.UpdateDate = _dateTime.Now;
            _repository.Update(entity);

            _unitOfWork._context.Entry(entity).Property(x => x.CreateDate).IsModified = false;

            return await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>>? filter,
            int skip = 0,
            int take = int.MaxValue,
            string? orderBy = null,
            string? include = null)
        {
            return await _repository.Find(
                filter,
                skip,
                take,
                orderBy is null ? null : orderBy.Split(','),
                include is null ? null : include.Split(','));
        }

        public async Task<T> FindFirst(Expression<Func<T, bool>>? filter, string? include = null)
        {
            return await _repository.FindFirst(filter, include is null ? null : include.Split(','));
        }

        public async Task<T> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<int> Remove(Guid id)
        {
            return await _repository.Remove(x => x.Id == id);
        }


    }
}
