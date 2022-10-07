using e_Tickets.Data.Repository.IRepository;

namespace e_Tickets.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProducerRepository Producer { get; private set; }

        public IActorRepository Actor { get; private set; }

        public ICinemaRepository Cinema { get; private set; }

        public IMovieRepository Movie { get; private set; }

        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Movie = new MovieRepository(_context);
            Actor = new ActorRepository(_context);
            Category = new CategoryRepository(_context);
            Producer = new ProducerRepository(_context);
            Cinema = new CinemaRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}