using FilmClub.Entities.Films;
using FilmClub.Services.Genres;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace FilmClub.Services.Unit.Test.Genres
{
    public class EFDataContext :DbContext
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
