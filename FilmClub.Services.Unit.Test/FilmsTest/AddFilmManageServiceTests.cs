using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClub.Services.Genres.Contracts;
using FilmClub.Services.Unit.Test.Genres;
using FilmClub.Test.Tools.Films.Factories;
using FilmClub.Test.Tools.Genres.Builders;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Services.Unit.Test.FilmsTest
{
    public class AddFilmManageServiceTests
    {
        readonly EFDataContext _context;
        readonly EFDataContext _readContext;
        readonly FilmService _sut;
      
        public AddFilmManageServiceTests()
        {
            var db=new EFInMemoryDatabase();
            _context=db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = FilmServiceFactory.Create(_context);
        }
        [Fact]
        public async Task Add_adds_Film_properly()
        {
            var genre=new GenreBuilder().Build();
            _context.Save(genre);
            var dto = AddFilmDtoFactory.Create(genre.Id);

            await _sut.Add(genre.Id, dto);
            
            var actual=_readContext.Films.Single();
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
    }
}
