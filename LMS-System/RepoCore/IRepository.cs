using System.Linq.Expressions;

namespace LMS_System.RepoCore
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetById(object Id);
        bool Any(Expression<Func<T, bool>> where);
    }
}
