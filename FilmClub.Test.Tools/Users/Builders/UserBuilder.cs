using FilmClub.Services.Unit.Test.UsersTest;

namespace FilmClub.Spec.Tests.Users
{
    public class UserBuilder
    {
        readonly User _user;
        public UserBuilder()
        {
            _user = new User()
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                PhoneNumber = "1987454",
                Address = "shz",
                Age = new DateTime(1995, 09, 30),
                Gender = Gender.Male,
            };
        }
        public UserBuilder WithName(string firstName)
        { 
        _user.FirstName = firstName;
            return this;
        }
        public User Build()
        {
            return _user;
        }


    }
}