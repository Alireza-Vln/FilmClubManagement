using FilmClub.Entities.Films;
using FilmClub.Services.Films.Contracts.Dtos;
using FilmClub.Services.Unit.Test.FilmsTest;

namespace FilmClub.Services.Films.Contracts
{
    public interface FilmRepository
    {
        void Add(Film film);
       List<GetFilmManageDto> GetAll(FilmFilterDto? filter);
        Film FindFilm(int filmId);
        void Remove(Film film);
        List<GetFilmDto> Get(FilmFilterDto? filter);
    }
}
