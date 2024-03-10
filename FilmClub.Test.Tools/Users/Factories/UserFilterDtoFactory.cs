namespace FilmClub.Services.Unit.Test.UsersTest
{
    public static class UserFilterDtoFactory
    {
        public static UserFilterDto Create(
            string? firstName = null,
            string? lastName = null
            )
        {
            return new UserFilterDto()
            {
                FirstName = firstName ?? "dummy-first-name",
                LastName = lastName ?? "dummy-last-name",
            };
        }
    }
}
