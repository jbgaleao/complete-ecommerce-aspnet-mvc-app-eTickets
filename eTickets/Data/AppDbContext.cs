using eTickets.Models;

using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Actor> ACTORS { get; set; }
        public DbSet<Actor_Movie> ACTORS_MOVIES { get; set; }
        public DbSet<Cinema> CINEMA { get; set; }
        public DbSet<Movie> MOVIES { get; set; }
        public DbSet<Producer> PRODUCERS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(m => m.Movie)
                .WithMany(am => am.Actors_Movies)
                .HasForeignKey(fk => fk.MovieId);

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(a => a.Actor)
                .WithMany(am => am.Actors_Movies)
                .HasForeignKey(fk => fk.ActorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
