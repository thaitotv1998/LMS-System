using System.Linq.Expressions;

namespace LMS_System.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
