using FilmClub.Test.Tools.Genres.Builders;
using FluentAssertions;
using FilmClub.Test.Tools.Genres.Factories;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClub.Services.Genres.Cantracts.Exceptoins;
using FilmClubManagement.Persistance.EF;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;

namespace FilmClub.Services.Unit.Test.GenresTest.GenreManageTest
{
    public class UpdateGenreManageServiceTests:BusinessUnitTest
    {
      
        public readonly GenreManageService _sut;

        public UpdateGenreManageServiceTests()
        {
           
            _sut = GenreManageServiceFactory.Create(SetupContext);
        }

        [Fact]
        public async Task Update_updates_genre_properly()
        {
            var genre = new GenreBuilder().Build();
            DbContext.Save(genre);
            var dto = UpdateGenreManageDtoFactory.Create();

            await _sut.Update(genre.Id, dto);

            var actual = ReadContext.Genres.Single(_ => _.Id == genre.Id);
            actual.Title.Should().Be(dto.Title);

        }
        [Fact]
        public async Task Throw_update_genre_if_genre_is_null_exception()
        {
            var dummyId = 1;
            var dto = UpdateGenreManageDtoFactory.Create();

            var actual = () => _sut.Update(dummyId, dto);

            await actual.Should().ThrowExactlyAsync<ThrowUpdateGenreIsNullException>();


        }
    }
}
