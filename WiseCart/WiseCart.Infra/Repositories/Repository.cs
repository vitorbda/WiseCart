using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WiseCart.Domain.Interfaces;
using WiseCart.Infra.Context;

namespace WiseCart.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected DbSet<T> _dbSet => _context.Set<T>();

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual T DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return entity;
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
    }
}
