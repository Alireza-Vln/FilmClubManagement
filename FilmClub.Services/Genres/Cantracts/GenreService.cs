using FilmClub.Services.Genres.Cantracts.Dtos;

namespace FilmClub.Services.Unit.Test.GenresTest.GenreTests
{
    public interface GenreService
    {
        Task<List<GetGenreDto>>Get(GenreFilterDto filter);
    }
}
