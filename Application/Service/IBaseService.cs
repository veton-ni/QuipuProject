using Domain.Entity;
using System.Linq.Expressions;

namespace Application.Service
{
    public interface IBaseService<T> where T : BaseEntity
    {
        public Task<T> Get(Guid id);
        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>>? filter,
            int skip = 0,
            int take = int.MaxValue,
            string? orderBy = null,
            string? include = null);
        public Task<T> FindFirst(Expression<Func<T, bool>>? filter,
            string? include = null);
        public Task<T> Add(T entity);
        public Task<IEnumerable<T>> Add(IEnumerable<T> entities);
        public Task<int> Change(Guid id, T entity);
        public Task<int> Remove(Guid id);


    }
}
