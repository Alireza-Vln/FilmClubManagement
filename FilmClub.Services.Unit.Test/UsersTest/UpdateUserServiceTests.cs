using FilmClub.Spec.Tests.Users;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClub.Test.Tools.Users.Factories;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Services.Unit.Test.UsersTest
{
    public class UpdateUserServiceTests : BusinessUnitTest
    {
        readonly UserService _sut;
        public UpdateUserServiceTests()
        {
            _sut = UserServiceFactory.Create(SetupContext);
        }
        [Fact]
        public void Update_updates_User_properly()
        {
            var user = new UserBuilder().Build();
            DbContext.Save(user);
            var dto = UpdateUserDtoFactory.Create();

            _sut.Update(user.Id, dto);

            var actual = ReadContext.Users.Single();
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.PhoneNumber.Should().Be(dto.PhoneNumber);
            actual.Age.Should().Be(dto.Age);
            actual.Address.Should().Be(dto.Address);
            actual.Gender.Should().Be(dto.Gender);
        }
        [Fact]
        public void Throw_update_user_if_user_is_null()
        {
            var dummyid = 1;
            var dto=UpdateUserDtoFactory.Create();

           var actual=()=> _sut.Update(dummyid, dto);
            actual.Should().ThrowExactlyAsync<ThrowUpdateUserIfUserIsNullException>();

        }
    }
}
