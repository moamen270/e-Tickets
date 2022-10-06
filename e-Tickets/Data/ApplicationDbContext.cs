using e_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Actor_Movie>().HasKey(key => new
            {
                key.MovieId,
                key.ActorId
            });
            builder.Entity<Actor_Movie>().HasOne(e => e.Movie).WithMany(e => e.Actors_Movies).HasForeignKey(f => f.MovieId);
            builder.Entity<Actor_Movie>().HasOne(e => e.Actor).WithMany(e => e.Actors_Movies).HasForeignKey(f => f.ActorId);
            base.OnModelCreating(builder);
        }

        private DbSet<Actor> Actors { get; set; }
        private DbSet<Producer> Producers { get; set; }
        private DbSet<Cinema> Cinemas { get; set; }
        private DbSet<Actor_Movie> Actors_Movies { get; set; }
        private DbSet<Movie> Movies { get; set; }
        private DbSet<Category> Categories { get; set; }
    }
}