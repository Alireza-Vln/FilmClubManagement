using FilmClub.Test.Tools.Genres.Builders;
using FluentAssertions;
using FilmClub.Test.Tools.Genres.Factories;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClub.Services.Genres.Cantracts.Exceptoins;
using FilmClubManagement.Persistance.EF;

namespace FilmClub.Services.Unit.Test.GenresTest.GenreManageTest
{
    public class UpdateGenreManageServiceTests
    {
        private readonly EFDataContext _context;
        private readonly EFDataContext _readContext;
        public readonly GenreManageService _sut;

        public UpdateGenreManageServiceTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = GenreManageServiceFactory.Create(_context);
        }

        [Fact]
        public async Task Update_updates_genre_properly()
        {
            var genre = new GenreBuilder().Build();
            _context.Save(genre);
            var dto = UpdateGenreManageDtoFactory.Create();

            await _sut.Update(genre.Id, dto);

            var actual = _readContext.Genres.Single(_ => _.Id == genre.Id);
            actual.Title.Should().Be(dto.Title);

        }
        [Fact]
        public async Task Thorw_update_genre_if_gener_is_null_exception()
        {
            var dummyId = 1;
            var dto = UpdateGenreManageDtoFactory.Create();

            var actual = () => _sut.Update(dummyId, dto);

            await actual.Should().ThrowExactlyAsync<ThrowUpdateGenreIsNullException>();


        }
    }
}
