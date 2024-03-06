using FilmClub.Entities.Films;
using FilmClub.Entities.Genres;
using FilmClub.Services.Unit.Test.UsersTest;
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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly
                (typeof(EFDataContext).Assembly);
        }
    }
}
