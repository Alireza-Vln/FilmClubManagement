using FilmClub.Services.Genres.Cantracts.Dtos;
using FilmClub.Services.Unit.Test.Genres;
using FilmClub.Services.Unit.Test.GenresTest;

namespace FilmClub.Services.Genres.Contracts
{
    public interface GenreManageService
    {
        Task Add(AddGenreManageDto dto);
        Task Delete(int id);
        Task<List<GetGenreManageDto>> Get(GenreFilterDto? filter);
        Task Update(int id,UpdateGenreManageDto dto);
    }
}
