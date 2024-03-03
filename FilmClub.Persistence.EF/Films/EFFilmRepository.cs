using FilmClub.Entities.Films;
using FilmClub.Services.Unit.Test.Genres;
using Microsoft.EntityFrameworkCore;

namespace FilmClub.Services.Unit.Test.FilmsTest
{
    public class EFFilmRepository:FilmRepository
    {
        private readonly DbSet<Film> _Film;

        public EFFilmRepository(EFDataContext context)
        {
            _Film = context.Films;
        }

        public void Add(Film film)
        {
            _Film.Add(film);
        }
    }
}
