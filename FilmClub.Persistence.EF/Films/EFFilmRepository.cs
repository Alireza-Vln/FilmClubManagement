using FilmClub.Entities.Films;
using FilmClub.Services.Films.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FilmClubManagement.Persistance.EF.Films
{
    public class EFFilmRepository : FilmRepository
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
