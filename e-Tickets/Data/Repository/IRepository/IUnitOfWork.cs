namespace e_Tickets.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IProducerRepository Producer { get; }
        IActorRepository Actor { get; }
        ICinemaRepository Cinema { get; }
        IMovieRepository Movie { get; }
        ICategoryRepository Category { get; }

        int Save();
    }
}