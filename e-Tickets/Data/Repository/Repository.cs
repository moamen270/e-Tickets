using e_Tickets.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace e_Tickets.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task Delete(int id)
        {
            var obj = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(obj);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[]? includeProperty)
        {
            IQueryable<T> query = _context.Set<T>();
            query = _context.Set<T>();
            if (includeProperty != null)
                query = includeProperty.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllFilterAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? includeProperty)
        {
            IQueryable<T> query;
            if (filter != null)
                query = _context.Set<T>().Where(filter);
            else
                query = _context.Set<T>();
            if (includeProperty != null)
                query = includeProperty.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetFirstOrDefautltAsync(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includeProperty = null)
        {
            IQueryable<T> query;
            if (filter != null)
                query = _context.Set<T>().Where(filter);
            else
                query = _context.Set<T>();
            if (includeProperty != null)
                query = includeProperty.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.FirstOrDefaultAsync();
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}