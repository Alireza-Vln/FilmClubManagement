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
using System.Xml.Linq;
using Xunit;

namespace FilmClub.Services.Unit.Test.FilmsTest.FilmManageTests
{
    public class GetFilmManageServiceTests:BusinessUnitTest
    {
        readonly FilmManageService _sut;

        public GetFilmManageServiceTests()
        {
         
            _sut = FilmManageServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Get_gets_all_film_properly()
        {
            var genre = new GenreBuilder().Build();
            var film = new FilmBuilder().WithGenreId(genre.Id).Build();
            DbContext.Save(genre);
            DbContext.Save(film);
            var filter = FilmFilterDtoFactory.Create();

            var result = await _sut.Get(filter);

            result.Single().Id.Should().Be(film.Id);
            result.Single().Name.Should().Be(film.Name);
            result.Single().Director.Should().Be(film.Director);
            result.Single().Duration.Should().Be(film.Duration);
            result.Single().Poblish.Should().Be(film.Poblish);
            result.Single().AgeLimit.Should().Be(film.AgeLimit);
            result.Single().Count.Should().Be(film.Count);
            result.Single().Description.Should().Be(film.Description);
            result.Single().Rate.Should().Be(film.Rate);
            result.Single().PenaltyRate.Should().Be(film.PenaltyRate);
            result.Single().GenreName.Should().Be(genre.Title);
        }
        [Fact]
        public async Task Get_gets_film_filtered_by_director()
        {
            var genre = new GenreBuilder()
                .Build();
            var film = new FilmBuilder()
                .WithGenreId(genre.Id).Build();
            var film2 = new FilmBuilder()
                .WithGenreId(genre.Id)
                .WithDirector("filter")
                .Build();
            DbContext.Save(genre);
            DbContext.Save(film);
            DbContext.Save(film2);
            var filter = FilmFilterDtoFactory
                .Create(film2.Name, film2.Director);

            var result = await _sut.Get(filter);

            result.Count.Should().Be(1);
            result.Single().Director.Should().Be(film2.Director);

        }
        [Fact]
        public async Task Get_gets_film_filtered_by_name()
        {
            var genre = new GenreBuilder().Build();
            var film = new FilmBuilder().WithGenreId(genre.Id).Build();
            var film2 = new FilmBuilder().WithGenreId(genre.Id)
                .WithName("filter").Build();
            DbContext.Save(genre);
            DbContext.Save(film);
            DbContext.Save(film2);
            var filter = FilmFilterDtoFactory
                .Create(film2.Name);

            var result = await _sut.Get(filter);

            result.Count.Should().Be(1);
            result.Single().Name.Should().Be(film2.Name);

        }

        [Fact]
        public async Task Get_gets_film_filtered_by_genre_title()
        {
            var genre = new GenreBuilder().Build();
            var film = new FilmBuilder().WithGenreId(genre.Id).Build();
            DbContext.Save(genre);
            DbContext.Save(film);

            var filter = FilmFilterDtoFactory
                .Create(film.Name, film.Director, genre.Title);

            var result = await _sut.Get(filter);

            result.Count.Should().Be(1);
            result.Single().GenreName.Should().Be(genre.Title);
        }

    }
}