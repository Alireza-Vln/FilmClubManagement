using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Unit.Test.GenresTest;
using FilmClub.Test.Tools.Films.Factories;
using FilmClub.Test.Tools.Genres.Builders;
using FilmClub.Test.Tools.Genres.Factories;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClubManagement.Persistance.EF;
using FluentAssertions;


namespace FilmClub.Services.Unit.Test.FilmsTest
{
    public class UpdateFilmManageServiceTests
    {
        readonly EFDataContext _context;
        readonly EFDataContext _readContext;
        readonly FilmManageService _sut;
        public UpdateFilmManageServiceTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = FilmManageServiceFactory.Create(_context);
        }
        [Fact]
        public async Task Update_update_film_properly()
        {
            var genre=new GenreBuilder().Build();
            _context.Save(genre);
            var film=new FilmBuilder().Build();
            _context.Save(film);
            var dto=UpdateFilmDtoFactory.Create(genre.Id);

            await _sut.Update(film.Id, dto);

            var actual = _readContext.Films.Single(_=>_.Id==film.Id);

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
    }
}
