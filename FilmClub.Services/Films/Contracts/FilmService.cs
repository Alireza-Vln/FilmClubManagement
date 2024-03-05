using FilmClub.Services.Films.Contracts.Dtos;

namespace FilmClub.Services.Unit.Test.FilmsTest.FilmTest
{
    public interface FilmService
    {
        Task<List<GetFilmDto>> Get(FilmFilterDto filter);
    }
}
