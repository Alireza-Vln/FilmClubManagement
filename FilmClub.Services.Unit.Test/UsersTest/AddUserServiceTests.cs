using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClub.Test.Tools.Users.Factories;
using FilmClubManagement.Persistance.EF;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Services.Unit.Test.UsersTest
{
    public class AddUserServiceTests:BusinessUnitTest
    {
        private readonly UserService _sut;
        public AddUserServiceTests()
        {
           
            _sut = UserServiceFactory.Create(SetupContext);
        }

        [Fact]
        public async Task Add_adds_user_properly()
        {
            var dto = AddUserDtoFactory.Create();

            await _sut.Add(dto);

            var actual = ReadContext.Users.Single();
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.PhoneNumber.Should().Be(dto.PhoneNumber);
            actual.Address.Should().Be(dto.Address);
            actual.Gender.Should().Be(dto.Gender);
            actual.Age.Should().Be(dto.Age);

        }
    }
}
