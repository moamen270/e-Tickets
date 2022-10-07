using e_Tickets.Data.Repository.IRepository;
using e_Tickets.Models;

namespace e_Tickets.Data.Repository
{
    public class ProducerRepository : Repository<Producer>, IProducerRepository
    {
        private readonly ApplicationDbContext _context;

        public ProducerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}