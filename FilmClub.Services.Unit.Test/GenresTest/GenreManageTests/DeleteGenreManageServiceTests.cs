using FilmClubManagement.Persistance.EF;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Exceptoins;
using FilmClub.Test.Tools.Genres.Builders;
using FilmClub.Test.Tools.Genres.Factories;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FluentAssertions;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;

namespace FilmClub.Services.Unit.Test.GenresTest.GenreManageTest
{
    public class DeleteGenreManageServiceTests:BusinessUnitTest
    {
      
        public readonly GenreManageService _sut;

        public DeleteGenreManageServiceTests()
        {
           
            _sut = GenreManageServiceFactory.Create(ReadContext);
        }

        [Fact]
        public async Task Delete_deletes_genre_by_properly()
        {
            var genre = new GenreBuilder().Build();
            DbContext.Save(genre);

            await _sut.Delete(genre.Id);

            var actual = ReadContext.Genres.FirstOrDefault(_ => _.Id == genre.Id);
            actual.Should().BeNull();

        }
        [Fact]
        public async Task Throw_delete_genre_if_genre_is_null_exception()
        {
            var dummyId = 1;

            var actual = () => _sut.Delete(dummyId);

            await actual.Should().ThrowExactlyAsync<ThrowDeleteGenreIsNullException>();

        }
        [Fact]
        public async Task Throw_delete_genre_if_Film_is_Notnull_exception()
        {

            var genre = new GenreBuilder().Build();
            DbContext.Save(genre);
            var film = new FilmBuilder().WithGenreId(genre.Id).Build();
            DbContext.Save(film);

            var action = () => _sut.Delete(genre.Id);

            await action.Should().ThrowExactlyAsync<ThrowDeleteGenreIfFilmIsNotNullException>();



        }
    }
}
