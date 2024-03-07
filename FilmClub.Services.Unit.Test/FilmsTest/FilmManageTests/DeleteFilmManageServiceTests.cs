using FilmClub.Services.Films;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Unit.Test.GenresTest;
using FilmClub.Test.Tools.Films.Factories;
using FilmClub.Test.Tools.Genres.Builders;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClubManagement.Persistance.EF;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Services.Unit.Test.FilmsTest.FilmManageTests
{
    public class DeleteFilmManageServiceTests
    {
        readonly EFDataContext _context;
        readonly EFDataContext _readContext;
        readonly FilmManageService _sut;
        public DeleteFilmManageServiceTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = FilmManageServiceFactory.Create(_context);
        }
        [Fact]
        public async Task Remove_removes_film_properly()
        {
            var genre = new GenreBuilder().Build();
            _context.Save(genre);
            var film = new FilmBuilder().WithGenreId(genre.Id).Build();
            _context.Save(film);


            await _sut.Remove(film.Id);

            var actual = _readContext.Films.FirstOrDefault(_ => _.Id == film.Id);

            actual.Should().BeNull();
        }
        [Fact]
        public async Task Throw_remove_film_if_film_is_null_exception()
        {
            var dummyId = 123;

            var actual = () => _sut.Remove(dummyId);

            await actual.Should().ThrowExactlyAsync<ThrowRemoveFilmIfFilmIsNullException>();
        }

    }
}
