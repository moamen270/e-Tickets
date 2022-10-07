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

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}