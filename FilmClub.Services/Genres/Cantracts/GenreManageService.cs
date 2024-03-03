using FilmClub.Services.Genres.Cantracts.Dtos;

namespace FilmClub.Services.Genres.Cantracts
{
    public interface GenreManageService
    {
        Task Add(AddGenreManageDto dto);
        Task Delete(int id);
        Task<List<GetGenreManageDto>> Get(GenreFilterDto? filter);
        Task Update(int id, UpdateGenreManageDto dto);
    }
}
