using System.Linq.Expressions;

namespace e_Tickets.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);

        Task<T> GetFirstOrDefautlt(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includeProperty = null);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includeProperty = null);

        T Create(T entity);

        T Update(T entity);

        Task Delete(int id);
    }
}