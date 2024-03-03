using FilmClub.Services.Genres.Cantracts.Dtos;

namespace FilmClub.Test.Tools.Genres.Factories
{
    public static class AddGenreManagementDtoFactory
    {
        public static AddGenreManageDto Create()
        {
            return new AddGenreManageDto()
            {

                Title = "Dummy-Title",

            };
        }
    }
}
