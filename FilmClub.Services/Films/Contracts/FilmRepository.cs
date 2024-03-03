using FilmClub.Entities.Films;

namespace FilmClub.Services.Films.Contracts
{
    public interface FilmRepository
    {
        void Add(Film film);
    }
}
