using FilmClub.Entities.Films;
using FilmClub.Entities.Genres;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Unit.Test.FilmsTest;
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
    [Scenario("ویرایش فیلم")]
    [Story("",
        AsA ="مدیر کلاب",
        IWantTo ="فیلم ها را ویرایش کنم",
        InOrderTo ="فیلم ها را به روز رسانی کنم")]
    public class UpdateFilmTest : BusinessIntegrationTest
    {
        readonly FilmManageService _sut;
        private Film _film;
        private Genre _genre;
        public UpdateFilmTest()
        {
            _sut = FilmManageServiceFactory.Create(SetupContext);
        }
        [Given("در فهرست فیلمها فیلمی به اسم کلاب مشت زنی " +
            "و  کارگردان دیوید فینچر" +
            " و محدودیت سنی مثبت هجده سال  " +
            "و سال تولید ۲۰۰۲" +
            " و تعداد ۱ دارم")]
        private void Given()
        {
            _genre = new GenreBuilder()
                .WithTitle("اکشن")
                .Build();
            DbContext.Save(_genre);
            _film = new FilmBuilder()
                .WithName("کلاب مشت زنی")
                .WithDirector("دیوید فینچر")
                .WithGenreId(_genre.Id)
                .Build();
            DbContext.Save(_film);
        }
        [When(" من درخواست ویرایش فیلم مذکو را با عنوان  ماموریت غیرممکن" +
            " با کارگردانی برایان دی پالما " +
            " و محدوده سنی مثبت 14 سال " +
            "و زمان 95 دقیقه " +
            "و ساخت تولید 1996 " +
            "و تعداد 1  را دارم")]
        private async Task When()
        {
            var dto = new UpdateFilmDto()
            {
                Name = "ماموریت غیر ممکن",
                Director = "دی پالما",
                AgeLimit = 14,
                Poblish = "1996",
                Count = 1,
                Duration = 95,
                PenaltyRate = 10,
                Description = "",
                Rate = 10,
                GenreId = _genre.Id,
            }; 
  
                await _sut.Update(_film.Id,dto);
        }
        [Then(" فیلم مذکور با عنوان" +
            "  ماموریت غیرممکن" +
            " با کارگردانی برایان دی پالما " +
            " و محدوده سنی مثبت 14 سال" +
            " و زمان 95 دقیقه" +
            " و ساخت تولید 1996 " +
            "و تعداد  تغییر میکند")]
        public void Then()
        {
            var actual = ReadContext.Films.Single(_ => _.Id == _film.Id);
            actual.Name.Should().Be("ماموریت غیر ممکن");
            actual.Director.Should().Be("دی پالما");
            actual.AgeLimit.Should().Be(14);
            actual.Poblish.Should().Be("1996");
            actual.Count.Should().Be(1);
            actual.Duration.Should().Be(95);
            actual.PenaltyRate.Should().Be(10);
            actual.Description.Should().Be("");
            actual.Rate.Should().Be(10);
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
