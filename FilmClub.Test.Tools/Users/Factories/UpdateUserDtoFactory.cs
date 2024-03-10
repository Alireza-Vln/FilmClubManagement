using FilmClub.Spec.Tests.Users;

namespace FilmClub.Services.Unit.Test.UsersTest
{
    public static class UpdateUserDtoFactory
    {
        public static UpdateUserDto Create()
        {
            return new UpdateUserDto()
            {
                FirstName = "dummy-update-first-name",
                LastName = "dummy-update-last-name",
                PhoneNumber = "1987454",
                Address = "shz",
                Age = new DateTime(1995, 09, 30),
                Gender = Gender.Male,
            };

        }
    }
}
