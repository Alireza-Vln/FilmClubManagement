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
    public class AddUserServiceTests
    {
        private readonly UserService _sut;
        private readonly EFDataContext _context;
        private readonly EFDataContext _readContext;
        public AddUserServiceTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = UserServiceFactory.Create(_context);
        }

        [Fact]
        public async Task Add_adds_user_properly()
        {
            var dto = AddUserDtoFactory.Create();

            await _sut.Add(dto);

            var actual = _readContext.Users.Single();
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.PhoneNumber.Should().Be(dto.PhoneNumber);
            actual.Address.Should().Be(dto.Address);
            actual.Gender.Should().Be(dto.Gender);
            actual.Age.Should().Be(dto.Age);

        }
    }
}
