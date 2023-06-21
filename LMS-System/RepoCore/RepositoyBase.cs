using LMS_System.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LMS_System.RepoCore
{
    public class RepositoyBase<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

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

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll() => await _dbSet.ToListAsync();

        public async Task<T> GetByCondition(Expression<Func<T, bool>> expression) => await _dbSet.Where(expression).FirstAsync();

        public async Task<T> GetById(object Id) => await _dbSet.FindAsync(Id);

        public bool Any(Expression<Func<T, bool>> where) => _dbSet.Where(where).Any();
    }
}
