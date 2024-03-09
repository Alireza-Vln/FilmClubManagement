using FilmClub.Services.Genres.Cantracts.Dtos;

namespace FilmClub.Test.Tools.Genres.Factories
{
    public static class UpdateGenreManageDtoFactory
    {
        public static UpdateGenreManageDto Create(string? tite = null)
        {
            return new UpdateGenreManageDto()
            {
                Title = tite??"dummy-update-genre"
            };
        }
    }
}
