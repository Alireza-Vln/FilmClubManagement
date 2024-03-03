namespace FilmClub.Services.Unit.Test.FilmsTest
{
    public interface FilmService
    {
        Task Add(int genreId, AddFilmDto dto);
    }
}
