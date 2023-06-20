using LMS_System.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LMS_System.Repositories
{
    public class RepositoyBase<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        protected RepositoyBase(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll() => await _dbSet.ToListAsync();

        public async Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression) => await _dbSet.Where(expression).ToListAsync();

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
