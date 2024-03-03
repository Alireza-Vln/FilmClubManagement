using FilmClub.Services.Genres.Cantracts.Dtos;

namespace FilmClub.Test.Tools.Genres.Factories
{
    public static class UpdateGenreManageDtoFactory
    {
        public static UpdateGenreManageDto Create()
        {
            return new UpdateGenreManageDto()
            {
                Title = "Update-dummy-title",
            };
        }
    }
}
