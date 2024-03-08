using FilmClub.Services.Genres.Cantracts.Dtos;

namespace FilmClub.Test.Tools.Genres.Factories
{
    public static class AddGenreManagementDtoFactory
    {
        public static AddGenreManageDto Create(string?title=null)
        {
            return new AddGenreManageDto()
            {

                Title = title??"Dummy-Title",

            };
        }
    }
}
