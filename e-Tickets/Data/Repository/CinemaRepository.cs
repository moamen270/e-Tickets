using e_Tickets.Data.Repository.IRepository;
using e_Tickets.Models;

namespace e_Tickets.Data.Repository
{
    public class CinemaRepository : Repository<Cinema>, ICinemaRepository
    {
        private readonly ApplicationDbContext _context;

        public CinemaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}