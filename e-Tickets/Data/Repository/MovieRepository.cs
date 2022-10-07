using e_Tickets.Data.Repository.IRepository;
using e_Tickets.Models;

namespace e_Tickets.Data.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}