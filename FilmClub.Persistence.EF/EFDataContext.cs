using FilmClub.Entities.Films;
using FilmClub.Entities.Genres;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace FilmClubManagement.Persistance.EF
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(string connectionString) :
        this(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)
        {
        }


        public EFDataContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Genre> Genres { get; set; }
        public DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly
                (typeof(EFDataContext).Assembly);
        }
    }
}
