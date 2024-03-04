using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Unit.Test.GenresTest;
using FilmClub.Test.Tools.Films.Factories;
using FilmClub.Test.Tools.Genres.Builders;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClubManagement.Persistance.EF;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FilmClub.Services.Unit.Test.FilmsTest
{
    public class GetFilmManageServiceTests
    {
        readonly EFDataContext _context;
        readonly EFDataContext _readContext;
        readonly FilmService _sut;

        public GetFilmManageServiceTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = FilmServiceFactory.Create(_context);
        }
        [Fact]
        public async Task Get_gets_film_properly()
        {
            var genre = new GenreBuilder().Build();
            var film = new FilmBuilder().WithGenreId(genre.Id).Build();
            var film2 = new FilmBuilder().WithGenreId(genre.Id)
                .WithName("filter").Build();
            _context.Save(genre);
            _context.Save(film);
            _context.Save(film2);
            var filter = FilmFilterDtoFactory
                .Create(film2.Name,film2.Director,genre.Title);

            await _sut.Get(filter);

            var actual=_readContext.Films.Single(_=>_.Id==film2.Id);
            actual.Id.Should().Be(film2.Id);
            actual.Name.Should().Be(film2.Name);
            actual.Director.Should().Be(film2.Director);
            actual.Duration.Should().Be(film2.Duration);    
            actual.Poblish.Should().Be(film2.Poblish);
            actual.AgeLimit.Should().Be(film2.AgeLimit);
            actual.Count.Should().Be(film2.Count);
            actual.Description.Should().Be(film2.Description);
            actual.Rate.Should().Be(film2.Rate);
            actual.PenaltyRate.Should().Be(film2.PenaltyRate);


        }
    }
}