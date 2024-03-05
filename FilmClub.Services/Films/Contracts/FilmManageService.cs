using FilmClub.Services.Films.Contracts.Dtos;
using FilmClub.Services.Unit.Test.FilmsTest;

namespace FilmClub.Services.Films.Contracts
{
    public interface FilmManageService
    {
        Task Add(int genreId, AddFilmDto dto);
        Task<List<GetFilmManageDto>> Get(FilmFilterDto? filter);
        Task Update(int id, UpdateFilmDto dto);
    }
}
