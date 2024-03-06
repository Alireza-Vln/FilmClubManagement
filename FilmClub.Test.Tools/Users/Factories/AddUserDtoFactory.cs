using FilmClub.Services.Unit.Test.UsersTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Test.Tools.Users.Factories
{
    public static class AddUserDtoFactory
    {
        public static AddUserDto Create()
        {

            return new AddUserDto
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                Age = new DateTime(2020, 10, 10),
                Gender = Gender.Male,
                Address = "dummy-address",
                PhoneNumber = "09112223344",
            };



        }
    }
}
