using FilmClub.Entities.Genres;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Genres;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Test.Tools.Genres.Factories;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClubManagement.Persistance.EF;
using FilmClubs.Contracts.Interfaces;
using FluentAssertions;
using Moq;

namespace FilmClub.Services.Unit.Test.GenresTest.GenreManageTest
{
    public class AddGenreManageServiceTests
    {
        private readonly EFDataContext _context;
        private readonly EFDataContext _readContext;
        public readonly GenreManageService _sut;

        public AddGenreManageServiceTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = GenreManageServiceFactory.Create(_context);
        }


        [Fact]
        public async Task Add_adds_genre_by_Manage_properly()
        {
            var dto = AddGenreManagementDtoFactory.Create();

            await _sut.Add(dto);

            var actual = _readContext.Genres.Single();
            actual.Title.Should().Be(dto.Title);
        }
        [Fact]
        public async Task Add_adds_genre_by_Manage_properly_maq()
        {
            var dto = AddGenreManagementDtoFactory.Create();

            var repositoryMock = new Mock<GenreRepository>();
            var unitOfWork = new Mock<UnitOfWork>();
            var filmRepository = new Mock<FilmRepository>();

            var sut = new GenreManageAppService(repositoryMock.Object, unitOfWork.Object, filmRepository.Object);

            await sut.Add(dto);
            repositoryMock.Verify(_ => _.Add(It.Is<Genre>(_ => _.Title == dto.Title)));

        }

    }
}
