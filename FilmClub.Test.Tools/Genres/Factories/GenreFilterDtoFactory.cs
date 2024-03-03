using FilmClub.Services.Genres.Cantracts.Dtos;

namespace FilmClub.Test.Tools.Genres.Factories
{
    public static class GenreFilterDtoFactory
    {
        public static GenreFilterDto Create(string? title = null)
        {
            return new GenreFilterDto
            {
                Title = title ?? "dummy-title",
            };
        }
    }
}
