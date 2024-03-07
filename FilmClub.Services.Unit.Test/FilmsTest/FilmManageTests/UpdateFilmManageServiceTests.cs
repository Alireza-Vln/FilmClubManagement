using FilmClub.Entities.Genres;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Unit.Test.GenresTest;
using FilmClub.Test.Tools.Films.Factories;
using FilmClub.Test.Tools.Genres.Builders;
using FilmClub.Test.Tools.Genres.Factories;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClubManagement.Persistance.EF;
using FluentAssertions;


namespace FilmClub.Services.Unit.Test.FilmsTest.FilmManageTests
{
    public class UpdateFilmManageServiceTests:BusinessUnitTest
    { 
        readonly FilmManageService _sut;
        public UpdateFilmManageServiceTests()
        {   
            _sut = FilmManageServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Update_update_film_properly()
        {
            var genre = new GenreBuilder().Build();
            DbContext.Save(genre);
            var film = new FilmBuilder().Build();
            DbContext.Save(film);
            var dto = UpdateFilmDtoFactory.Create(genre.Id);

            await _sut.Update(film.Id, dto);

            var actual = ReadContext.Films.Single(_ => _.Id == film.Id);

            actual.Name.Should().Be(dto.Name);
            actual.Director.Should().Be(dto.Director);
            actual.Poblish.Should().Be(dto.Poblish);
            actual.Duration.Should().Be(dto.Duration);
            actual.AgeLimit.Should().Be(dto.AgeLimit);
            actual.Count.Should().Be(dto.Count);
            actual.Rate.Should().Be(dto.Rate);
            actual.PenaltyRate.Should().Be(dto.PenaltyRate);
            actual.Description.Should().Be(dto.Description);
            actual.GenreId.Should().Be(dto.GenreId);
        }
        [Fact]
        public async Task Throw_update_film_properly_if_genre_is_null_exception()
        {
            var dummyGenreId = 154;
            var genre = new GenreBuilder().Build();
            DbContext.Save(genre);
            var film = new FilmBuilder().WithGenreId(genre.Id).Build();
            DbContext.Save(film);
            var dto = UpdateFilmDtoFactory.Create(dummyGenreId);

            var actual = () => _sut.Update(film.Id, dto);

            await actual.Should().ThrowExactlyAsync<ThrowUpdateFilmProperlyIfGenreIsNullException>();

        }
        [Fact]
        public async Task Throw_update_film_properly_if_film_is_null_exception()
        {
            var dummyFilmId = 154;
            var genre = new GenreBuilder().Build();
            DbContext.Save(genre);
            var dto = UpdateFilmDtoFactory.Create(genre.Id);

            var actual = () => _sut.Update(dummyFilmId, dto);

            await actual.Should().ThrowExactlyAsync<ThrowUpdateFilmProperlyIfFilmIsNullException>();

        }
    }
}
