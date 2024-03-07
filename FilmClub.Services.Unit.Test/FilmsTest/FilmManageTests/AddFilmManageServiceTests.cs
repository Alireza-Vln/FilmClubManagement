using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClub.Test.Tools.Films.Factories;
using FilmClub.Test.Tools.Genres.Builders;
using FluentAssertions;
using FilmClub.Services.Films.Contracts;
using FilmClubManagement.Persistance.EF;
using System.ComponentModel.DataAnnotations;
using FilmClub.Services.Genres.Cantracts.Exceptoins;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;

namespace FilmClub.Services.Unit.Test.FilmsTest.FilmManageTests
{
    public class AddFilmManageServiceTests:BusinessUnitTest
    {
     
        readonly FilmManageService _sut;

        public AddFilmManageServiceTests()
        {
          
            _sut = FilmManageServiceFactory.Create(SetupContext);
        }

        [Fact]
        public async Task Add_adds_Film_properly()
        {
            var genre = new GenreBuilder().Build();
            DbContext.Save(genre);
            var dto = AddFilmDtoFactory.Create(genre.Id);

            await _sut.Add(genre.Id, dto);

            var actual = ReadContext.Films.Single();
            actual.Name.Should().Be(dto.Name);
            actual.Director.Should().Be(dto.Director);
            actual.Poblish.Should().Be(dto.Poblish);
            actual.Duration.Should().Be(dto.Duration);
            actual.AgeLimit.Should().Be(dto.AgeLimit);
            actual.Count.Should().Be(dto.Count);
            actual.Rate.Should().Be(dto.Rate);
            actual.PenaltyRate.Should().Be(dto.PenaltyRate);
            actual.Description.Should().Be(dto.Description);
            actual.GenreId.Should().Be(genre.Id);
        }
        [Fact]
        public async Task Throw_adds_film_if_genre_is_null()
        {
            var dummyGenreId = 1;
            var dto = AddFilmDtoFactory.Create(dummyGenreId);

            var actual = () => _sut.Add(dummyGenreId, dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddsFilmIfGenreIsNullException>();
        }
    }
}
