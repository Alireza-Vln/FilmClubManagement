using FilmClub.Entities.Films;
using FilmClub.Entities.Genres;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Exceptoins;
using FilmClub.Services.Unit.Test.GenresTest;
using FilmClub.Services.Unit.Test.UsersTest;
using FilmClub.Test.Tools.Genres.Builders;
using FilmClub.Test.Tools.Genres.Factories;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;
using FilmClub.Tests.Tools.Infrastructure.DatabaseConfig.IntegrationTest;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FilmClub.Spec.Tests.Genres
{
    [Scenario("عدم حذف شدن ژانر")]
    [Story("",
        AsA = "مدیرکلاب",
        IWantTo = "ژانر فیلم را حذف کنم",
        InOrderTo = "ان ژانر را نداشته باشم")]
    public class FaildToDeleteGenreOfTheFilmTest :BusinessIntegrationTest
    {
       private readonly GenreManageService _sut;
        private Genre _genre;
        private Func<Task> _actual;
        public FaildToDeleteGenreOfTheFilmTest()
        {
            _sut = GenreManageServiceFactory.Create(SetupContext);
        }
        [Given(" ژانری با عنوان اکشن در فهرست ژانر موجود داریم")]
        [And("فیلمی با عنوان  ماموریت غیرممکن با کارگردانی برایان دی پالما" +
            "  و محدوده سنی مثبت 14 سال و زمان 95 دقیقه" +
            " و ساخت تولید 1996 و تعداد 1  و ژانر اکشن در فهرست فیلم ها موجود داریم")]
        private void Given()
        {
            _genre = new GenreBuilder()
                .WithTitle("اکشن")
                .Build();
            DbContext.Save(_genre);
            var film = new FilmBuilder()
                .WithGenreId(_genre.Id)
                .Build();
            DbContext.Save(film);
        }
        [When("من عنوان اکشن را حذف میکنم")]
        private async Task When()
        {
            _actual =() => _sut.Delete(_genre.Id);
        }
        [Then("خطایی با عنوان این ژانر دارای فیلم می باشد باید رخ دهد")]
        private async Task Then()
        {      
           await _actual.Should().ThrowExactlyAsync<ThrowDeleteGenreIfFilmIsNotNullException>();
        }
        [Fact]
        public void Run()
        {
            Runner.RunScenario(
                _ => Given(),
                _ => When().Wait(),
                _ => Then().Wait());
        }
    }
}
