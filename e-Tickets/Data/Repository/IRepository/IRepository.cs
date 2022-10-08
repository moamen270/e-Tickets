using System.Linq.Expressions;

namespace e_Tickets.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);

        Task<T> GetFirstOrDefautltAsync(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includeProperty = null);

        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[]? includeProperty);

        Task<IEnumerable<T>> GetAllFilterAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? includeProperty);

        T Create(T entity);

        T Update(T entity);

        Task Delete(int id);
    }
}