using FilmClub.Services.Genres;
using FilmClub.Test.Tools.Genres.Builders;
using FilmClub.Test.Tools.Genres.Factories;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClubManagement.Persistance.EF;
using FilmClubManagement.Persistance.EF.Films;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Services.Unit.Test.GenresTest.GenreTests
{
    public class GetGenreServiceTests
    {
        private readonly EFDataContext _context;
        private readonly EFDataContext _readContext;
        public readonly GenreService _sut;

        public GetGenreServiceTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = GenreServiceFactory.Create(_context);
        }
        [Fact]
        public async Task Get_gets_all_genre_properly()
        {
            var genre = new GenreBuilder().Build();
            _context.Save(genre);
            var filter = GenreFilterDtoFactory.Create();

            var actual = await _sut.Get(filter);

         
            actual.Single().Title.Should().Be(genre.Title);
            actual.Single().Rate.Should().Be(genre.Rate);

        }
        [Fact]
        public async Task Get_Gets_Genre_manage_properly_with_filter()
        {
            var genre = new GenreBuilder().Build();
            _context.Save(genre);
            var genre2 = new GenreBuilder().
                 WithId(2)
                .WithTitle("filter-dummy-title")
                .Build();
            _context.Save(genre2);

            var filter = GenreFilterDtoFactory.Create(genre2.Title);

            var actual = await _sut.Get(filter);


            actual.Count.Should().Be(1);
            actual.Single().Title.Should().Be(genre2.Title);


        }



    }
}
