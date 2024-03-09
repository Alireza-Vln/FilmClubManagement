using FilmClub.Entities.Genres;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Films.Contracts.Dtos;
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
    [Scenario("اضافه کردن فیلم")]
    [Story("",
        AsA = "مدیر کلاب",
        IWantTo = "فیلم جدید اضافه کنم",
        InOrderTo = "فیلم ها اجاره کنم")]
    public class AddFilmTest : BusinessIntegrationTest
    {
        readonly FilmManageService _sut;
        private Genre _genre;
        public AddFilmTest()
        {
            _sut = FilmManageServiceFactory.Create(SetupContext);
        }
        [Given("فیلمی در  فهرست فیلمها موجود ندارد")]
        [And(" ژانری به اسم معمایی وجود دارد")]
        public void Given()
        {
            _genre = new GenreBuilder()
                .WithTitle("معمایی")
                .Build();
            DbContext.Save(_genre);
        }
        [When(" من درخواست اضافه کردن فیلم دارم" +
            " با اسم کلاب مشت زنی " +
            "و کارگردان دیوید فینچر " +
            " و محدودیت سنی مثبت هجده سال" +
            "  و سال تولید ۲۰۰۲ و" +
            " تعداد ۱ زمان ۱۱۰ دقیقه  و" +
            " نرخ جریمه ی ۱۰ " 
            )]
        public async Task When()
        {
            var dto = new AddFilmDto
            {
                Name = "کلاب مشت زنی",
                Director = "دیوید فینچر",
                AgeLimit = 18,
                Poblish = "2002",
                Count = 1,
                Duration = 110,
                PenaltyRate = 10,
                Description = "",
                Rate = 10,
                GenreId = _genre.Id,
            };
            await _sut.Add(_genre.Id,dto);
        }
        [Then(" درخواست اضافه کردن فیلم دارم" +
            " با اسم کلاب مشت زنی " +
            "و کارگردان دیوید فینچر " +
            " و محدودیت سنی مثبت هجده سال" +
            "  و سال تولید ۲۰۰۲ و" +
            " تعداد ۱ زمان ۱۱۰ دقیقه  و" +
            " نرخ جریمه ی ۱۰")]
        public void Then()
        {
            var actual = ReadContext.Films.Single();
            actual.Name.Should().Be("کلاب مشت زنی");
            actual.Director.Should().Be("دیوید فینچر");
            actual.AgeLimit.Should().Be(18);
            actual.Poblish.Should().Be("2002");
            actual.Count.Should().Be(1);
            actual.Duration.Should().Be(110);
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
