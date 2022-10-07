using e_Tickets.Data.Repository.IRepository;
using e_Tickets.Models;

namespace e_Tickets.Data.Repository
{
    public class ActorRepository : Repository<Actor>, IActorRepository
    {
        private readonly ApplicationDbContext _context;

        public ActorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}