using FilmClub.Entities.Films;
using FilmClub.Entities.Genres;
using FilmClub.Services.Unit.Test.GenresTest;
using FilmClub.Services.Unit.Test.UsersTest;
using FilmClub.Spec.Tests.Rents;
using FilmClub.Spec.Tests.Users;
using FilmClub.Test.Tools.Genres.Builders;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClub.Test.Tools.Rents.Factories;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Services.Unit.Test.RentTest
{
    public class AddRentServiceTests : BusinessUnitTest
    {
        readonly RentService _sut;
        readonly DateTime _fakeDate;
        private User _user;
        private Film _film;
        private Genre _genre;
        public AddRentServiceTests()
        {
            _fakeDate = new DateTime(2020, 10, 10);
            _sut = RentServiceFactory.Create(SetupContext, _fakeDate);
        }
        [Fact]
        public void Add_adds_Rent_properly()
        {
            _genre = new GenreBuilder().Build();
            DbContext.Save(_genre);
            _film = new FilmBuilder().WithGenreId(_genre.Id).Build();
            _user = new UserBuilder().Build();
            DbContext.Save(_film);
            DbContext.Save(_user);
            var dto = AddRentDtoFactory.Create(_film.Id, _user.Id);

            _sut.Add(dto);

            var actual = ReadContext.Rents.Single();
            actual.FilmId.Should().Be(dto.FilmId);
            actual.UserId.Should().Be(dto.UserId);
            actual.RentFilmTime.Should().Be(_fakeDate);

        }
        [Fact]
        public async void Add_adds_rent_if_film_is_null_exception()
        {
            var dummyFilmId = 122;
            _user = new UserBuilder().Build();
            DbContext.Save(_user);
            var dto = AddRentDtoFactory.Create(dummyFilmId, _user.Id);

            var actual = () => _sut.Add(dto);
            await actual.Should().ThrowExactlyAsync<ThrowAddsRentIfFilmIsNullException>();
        }
        [Fact]
        public async void Add_adds_rent_if_user_is_null_exception()
        {
            var dummyUserId = 122;
            _genre = new GenreBuilder().Build();
            DbContext.Save(_genre);
            _film = new FilmBuilder().WithGenreId(_genre.Id).Build();
            DbContext.Save(_film);
            var dto = AddRentDtoFactory.Create(_film.Id, dummyUserId);

            var actual = () => _sut.Add(dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddsRentIfUserIsNullException>();

        }
      
    }
}
