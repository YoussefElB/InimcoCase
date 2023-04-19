using Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly InimcoDbContext _dbContext;
        protected readonly DbSet<T> ModelDbSets;

        public Repository(InimcoDbContext dbContext)
        {
            _dbContext = dbContext;
            ModelDbSets = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            ModelDbSets.Add(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await ModelDbSets.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return await ModelDbSets.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IQueryable<T>> Query(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _dbContext.Set<T>().Where(predicate);

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }


        public IQueryable<T> All()
        {
            return ModelDbSets;
        }

        public void Remove(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached) ModelDbSets.Attach(entity);
            ModelDbSets.Remove(entity);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            ModelDbSets.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
