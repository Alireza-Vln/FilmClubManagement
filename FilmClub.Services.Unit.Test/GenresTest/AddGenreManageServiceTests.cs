using FluentAssertions;

namespace FilmClub.Services.Unit.Test.Genres
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
            _sut = GenreServiceFactory.Create(_context);
        }



        [Fact]
        public async Task Add_adds_genre_by_Manage_properly()
        {
            var dto = AddGenreManagementDtoFactory.Create();
           
          await _sut.Add(dto);

            var actual = _readContext.Genres.Single();
            actual.Title.Should().Be(dto.Title);
        }
      
    }
}
