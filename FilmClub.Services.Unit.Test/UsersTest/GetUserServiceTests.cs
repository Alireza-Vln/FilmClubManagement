using FilmClub.Services.Unit.Test.FilmsTest;
using FilmClub.Spec.Tests.Users;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClub.Test.Tools.Users.Factories;
using FilmClubs.Contracts.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FilmClub.Services.Unit.Test.UsersTest
{
    public class GetUserServiceTests : BusinessUnitTest
    {
         readonly  UserService _sut;

      
        public GetUserServiceTests()
        {
            _sut = UserServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Get_gets_User_properly()
        {
            var user=new UserBuilder().Build();
            DbContext.Save(user);
            var filterDto = UserFilterDtoFactory.Create();
            var year = DateTime.Now.Year - user.Age.Year;
            
            var actual= await _sut.Get(filterDto);

            actual.Single().Id.Should().Be(user.Id);
            actual.Single().FirstName.Should().Be(user.FirstName);
            actual.Single().LastName.Should().Be(user.LastName);
            actual.Single().PhoneNumber.Should().Be(user.PhoneNumber);
            actual.Single().Address.Should().Be(user.Address);
            actual.Single().Gender.Should().Be(user.Gender.ToString());
            actual.Single().Rate.Should().Be(user.Rate);
            actual.Single().Age.Should().Be(year);
         

        }
    }
}
