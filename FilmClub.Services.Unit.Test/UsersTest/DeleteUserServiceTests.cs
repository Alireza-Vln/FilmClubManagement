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
    public class DeleteUserServiceTests:BusinessUnitTest
    {
        readonly UserService _sut;
        public DeleteUserServiceTests()
        {
            _sut = UserServiceFactory.Create(SetupContext);
        }
        [Fact]
        public void Delete_deletes_user_properly()
        {
            var user=new UserBuilder().Build();
            DbContext.Save(user);

            _sut.Remove(user.Id);

            var actual=ReadContext.Users.FirstOrDefault(_=>_.Id==user.Id);
            actual.Should().BeNull();
        }
        [Fact]
        public void Throw_delete_user_if_user_is_null_exception()
        {
            var dummyId = 1;

           var actual=()=> _sut.Remove(dummyId);

            actual.Should().ThrowExactlyAsync<ThrowDeleteUserIfUserIsNullException>();
        }
    }
}
