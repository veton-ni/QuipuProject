using Domain.Entity;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Persistence.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>>? filter, 
            int skip = 0,
            int take = int.MaxValue,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null);

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>>? filter,
            int skip = 0,
            int take = int.MaxValue,
            IEnumerable<string>? orderBy = null,
            IEnumerable<string>? include = null);
        
        Task<T> FindFirst(Expression<Func<T, bool>>? filter,
            IEnumerable<string>? include = null);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        Task<int> Remove(Expression<Func<T, bool>> prediction);

        void Update(T entity);
        Task<int> Update(Expression<Func<T, bool>> where, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> prop);

    }
}
