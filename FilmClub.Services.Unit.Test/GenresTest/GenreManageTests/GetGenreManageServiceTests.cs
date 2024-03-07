using FilmClub.Test.Tools.Genres.Builders;
using FluentAssertions;
using FilmClub.Test.Tools.Genres.Factories;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClubManagement.Persistance.EF;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;

namespace FilmClub.Services.Unit.Test.GenresTest.GenreManageTest
{
    public class GetGenreManageServiceTests:BusinessUnitTest
    {
       
        public readonly GenreManageService _sut;

        public GetGenreManageServiceTests()
        {
          
            _sut = GenreManageServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Get_gets_all_genre_manage_properly()
        {
            var genre = new GenreBuilder().Build();
            DbContext.Save(genre);
            var filter = GenreFilterDtoFactory.Create();

            var actual = await _sut.Get(filter);

            actual.Single().Id.Should().Be(genre.Id);
            actual.Single().Title.Should().Be(genre.Title);
            actual.Single().Rate.Should().Be(genre.Rate);

        }
        [Fact]
        public async Task Get_Gets_Genre_manage_properly_with_filter()
        {
            var genre = new GenreBuilder().Build();
            DbContext.Save(genre);
            var genre2 = new GenreBuilder().
                 WithId(2)
                .WithTitle("filter-dummy-title")
                .Build();
            DbContext.Save(genre2);

            var filter = GenreFilterDtoFactory.Create(genre2.Title);

            var actual = await _sut.Get(filter);


            actual.Count.Should().Be(1);
            actual.Single().Title.Should().Be(genre2.Title);


        }

    }
}
