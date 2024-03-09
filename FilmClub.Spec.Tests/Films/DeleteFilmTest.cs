using FilmClub.Entities.Films;
using FilmClub.Entities.Genres;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Unit.Test.GenresTest;
using FilmClub.Test.Tools.Films.Factories;
using FilmClub.Test.Tools.Genres.Builders;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;
using FilmClub.Tests.Tools.Infrastructure.DatabaseConfig.IntegrationTest;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FilmClub.Spec.Tests.Films
{
    [Scenario("حذف فیلم")]
    [Story("",
        AsA ="مدیرکلاب",
        IWantTo ="فیلم را حذف کنم",
        InOrderTo ="فیلم را اجاره ندهم")]
    public class DeleteFilmTest : BusinessIntegrationTest
    {
        readonly FilmManageService _sut;
        private Film _film;
        private Genre _genre;
        public DeleteFilmTest()
        {
            _sut = FilmManageServiceFactory.Create(SetupContext);
        }
        [Given("  فیلمی دارم با اسم کلاب مشت زنی " +
            "و کارگردان دیوید فینچر " +
            "ومحدودیت سنی مثبت هجده سال  و سال تولید ۲۰۰۲ " +
            "و تعداد ۱ زمان ۱۱۰ دقیقه  " +
            "و نرخ جریمه ی ۱۰  " +
            " و نرخ اجاره ی ۱۰  دارم" +
            "و با ژانر معمایی")]
        private void Given()
        {
            _genre = new GenreBuilder()
                .WithTitle("معمایی")
                .Build();
            DbContext.Save(_genre);
            _film = new FilmBuilder()
                .WithGenreId(_genre.Id)
                .Build();
            DbContext.Save(_film);

        }
        [When(":من درخواست حذف فیلم مذکور را دارم")]
        private async Task When()
        {
            await _sut.Remove(_film.Id);
        }
        [Then("فیلمی در فهرستهای وجود ندارد")]
        private void Then()
        {
            var actual = ReadContext.Films.FirstOrDefault();
            actual.Should().BeNull();
               
        }
        [Fact]
        public void Run()
        {
            Runner.RunScenario(
                _ => Given(),
                _ => When().Wait(),
                _ => Then());
        }

          
    }
}
