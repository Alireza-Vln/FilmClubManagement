using FilmClub.Entities.Genres;
using FilmClub.Services.Genres.Cantracts;
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
    [Scenario("حذف شدن ژانر")]
    [Story("",
        AsA = "مدیرکلاب",
        IWantTo = "ژانر فیلم را حذف کنم",
        InOrderTo = "ان ژانر را نداشته باشم")]
    public class DeleteGenreTest : BusinessIntegrationTest
    {
        private readonly GenreManageService _sut;
        private Genre _genre;
        public DeleteGenreTest()
        {
            _sut = GenreManageServiceFactory.Create(SetupContext);
        }
        [Given(" ژانری با عنوان اکشن در فهرست ژانر موجود داریم")]
        private void Given()
        {
            _genre = new GenreBuilder()
                .WithTitle("اکشن")
                .Build();
            DbContext.Save(_genre);

        }
        [When("من عنوان اکشن را حذف میکنم")]
        private async Task When()
        {
            await _sut.Delete(_genre.Id);
           
        }
        [Then("در فهرست ژانرها ژانری وجود ندارد")]
        private void Then()
        {
            var actual = ReadContext.Genres.FirstOrDefault();
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
