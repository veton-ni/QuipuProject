using Application.Exceptions;
using Application.Persistence.Repository;
using Domain.Entity;
using Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;
        public Repository(DbContext Context)
        {
            this.Context = Context;
        }


        public async Task<T> Get(Guid id)
        {
            var result = await Context.Set<T>().FindAsync(id);

            return result ?? throw new Exception($"Item with name {typeof(T).Name} was not found!!!");
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>>? filter, int skip = 0, int take = int.MaxValue, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null)
        {
            var _resetSet = SetWhere(filter);

            if (include != null)
            {
                _resetSet = include(_resetSet);
            }
            if (orderBy != null)
            {
                _resetSet = orderBy(_resetSet).AsQueryable();
            }

            _resetSet = SetSelect(skip, take, _resetSet);

            return await _resetSet.AsQueryable().ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>>? filter, int skip = 0, int take = int.MaxValue, IEnumerable<string>? orderBy = null, IEnumerable<string>? include = null)
        {
            var _resetSet = SetWhere(filter);

            if (include != null)
            {
                foreach (string ii in include)
                {
                    _resetSet = _resetSet.Include(ii);
                }
            }

            if (orderBy != null)
            {
                _resetSet = _resetSet.AsQueryable().SortBy(orderBy);
            }

            _resetSet = SetSelect(skip, take, _resetSet);

            return await _resetSet.AsQueryable().ToListAsync();
        }
        private static IQueryable<T> SetSelect(int skip, int take, IQueryable<T> _resetSet)
        {
            if (take > 0)
                _resetSet = skip == 0 ? _resetSet.Take(take) : _resetSet.Skip(skip).Take(take);
            else
                _resetSet = skip == 0 ? _resetSet : _resetSet.Skip(skip);
            return _resetSet;
        }


        public async Task<T> FindFirst(Expression<Func<T, bool>>? filter, IEnumerable<string>? include = null)
        {
            var result = await Find(filter, take: 1, include: include);
            if (result.Count() == 0) throw new BadRequestException($"Item {typeof(T).Name} with id was not found!");

            return result.First();
        }

        private IQueryable<T> SetWhere(Expression<Func<T, bool>>? filter)
        {
            return filter != null ?
                Context.Set<T>().AsNoTracking().Where(filter).AsQueryable()
                : Context.Set<T>().AsNoTracking().AsQueryable();
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }


        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public async Task<int> Remove(Expression<Func<T, bool>> prediction)
        {
            return await Context.Set<T>().Where(prediction).ExecuteDeleteAsync();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public async Task<int> Update(Expression<Func<T, bool>> where, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> prop)
        {
            return await Context.Set<T>().Where(where).ExecuteUpdateAsync(prop);
        }

    }
}
