using FilmClubManagement.Persistance.EF;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Exceptoins;
using FilmClub.Test.Tools.Genres.Builders;
using FilmClub.Test.Tools.Genres.Factories;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FluentAssertions;

namespace FilmClub.Services.Unit.Test.GenresTest
{
    public class DeleteGenreManageServiceTests
    {
        private readonly EFDataContext _context;
        private readonly EFDataContext _readContext;
        public readonly GenreManageService _sut;

        public DeleteGenreManageServiceTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = GenreServiceFactory.Create(_context);
        }

        [Fact]
        public async Task Delete_deletes_genre_by_properly()
        {
            var genre = new GenreBuilder().Build();
            _context.Save(genre);

           await  _sut.Delete(genre.Id);

            var actual = _readContext.Genres.FirstOrDefault(_ => _.Id == genre.Id);
            actual.Should().BeNull();

        }
        [Fact]
        public async Task Throw_delete_genre_if_genre_is_null_exception()
        {
            var dummyId = 1;

           var actual=()=> _sut.Delete(dummyId);

           await actual.Should().ThrowExactlyAsync<ThrowDeleteGenreIsNullException>();

        }
        [Fact]
        //public async Task Throw_delete_genre_if_Film_is_Notnull_exception()
        //{

        //    var genre = new GenreBuilder().Build();
        //    _context.Save(genre);
        //    var film=new FilmBuilder().WithGenreId(genre.Id).Build();

        //    var action = () => _sut.Delete(genre.Id);

        //    var actual = _readContext.Films.FirstOrDefault(_ => _.GenreId == genre.Id);
        //    await action.Should().ThrowExactlyAsync<ThrowDeleteGenreIfFilmIsNotNullException>();



        }
    }
}
