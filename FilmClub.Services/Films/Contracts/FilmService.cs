using FilmClub.Services.Films.Contracts.Dtos;

namespace FilmClub.Services.Films.Contracts
{
    public interface FilmService
    {
        Task Add(int genreId, AddFilmDto dto);
    }
}
