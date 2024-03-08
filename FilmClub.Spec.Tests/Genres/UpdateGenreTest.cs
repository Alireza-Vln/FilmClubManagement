using FilmClub.Entities.Genres;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Dtos;
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
    [Scenario("اضافه کردن ژانر")]
    [Story("",
      AsA = "مدیر کلاب",
      IWantTo = "ژانری را ویرایش کنم",
      InOrderTo = "ژانر را تِییر دهم")]
    public class UpdateGenreTest:BusinessIntegrationTest
    {
        readonly GenreManageService _sut;
        private Genre _genre;
        public UpdateGenreTest()
        {
            _sut = GenreManageServiceFactory.Create(SetupContext);
        }
        [Given("ژانری با عنوان اکشن در فهرست فیلم ها وجود دارد")]
        private void Given()
        {
            _genre = new GenreBuilder()
             .WithTitle("اکشن")
                 .Build();
            DbContext.Save(_genre);

        }
        [When("من عنوان اکشن را به عنوان معمایی تغییر می دهم ")]
        private async Task When()
        {

            var dto = UpdateGenreManageDtoFactory.Create("معمایی");
             await _sut.Update(_genre.Id, dto);

        }
        [Then(" در فهرست ژانر با عنوان اکشن  باید به عنوان معمایی تغییر کند")]
        private void Then()
        {
            var actual = ReadContext.Genres.Single(_=>_.Id==_genre.Id);
            actual.Title.Should().Be("معمایی");
        }
        [Fact]
        public void Run()
        {
            Runner.RunScenario
                (_ => Given(),
                _ => When().Wait(),
                _ => Then());
        }
        
    }
}
