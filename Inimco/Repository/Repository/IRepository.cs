using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        //I created this a while back. Ever since then i've been using it in every project i've made.
        //May contain unused code. but this is my go-to base repository.
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> All();
        Task<IQueryable<T>> Query(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        void Add(T entity);
        void Remove(T Entity);
        void Update(T entity);
        Task<int> SaveChangesAsync();
    }
}