using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FilmClub.Services.Genres.Contracts;
using FilmClub.Services.Genres;
using FilmClub.Services.Unit.Test.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmClub.Test.Tools.Genres.Builders;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using FilmClub.Test.Tools.Genres.Factories;

namespace FilmClub.Services.Unit.Test.GenresTest
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
            _sut = GenreServiceFactory.Create(_context);
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
            var dto=UpdateGenreManageDtoFactory.Create();

            var actual = () => _sut.Update(dummyId, dto);

         await actual.Should().ThrowExactlyAsync<ThrowUpdateGenreIsNullException>();

            
        }
    }
}
