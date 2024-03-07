using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Dtos;
using FilmClub.Test.Tools.Genres.Factories;
using FluentAssertions;
using FilmClub.Tests.Tools.Infrastructure.DatabaseConfig.IntegrationTest;
using Xunit;

namespace FilmClub.Spec.Tests.Genres
{
    [Scenario("اضافه شدن ژانر")]
    [Story("",
        AsA = "مدیر کلاب",
        IWantTo = "ژانر جدید اضافه کنم",
        InOrderTo = "ژانر را به فیلم ها اجاره کنم")]

    public class AddGenreTest : BusinessIntegrationTest
    {
        private readonly GenreManageService _sut;

        public AddGenreTest()
        {
            _sut = GenreManageServiceFactory.Create(SetupContext);

        }
        [Given("ژانری در فهرست ژانرها وجود ندارد")]
        private void Given()
        {

        }
        [When("ژانری عنوان اکشن به فهرست ژانرها اضافه میکنم")]
        private async Task When()
        {
            var dto = new AddGenreManageDto()
            {
                Title = "اکشن"
            };
            await _sut.Add(dto);
        }
        [Then(" یک دسته بندی به عنوان اکشن در فهرست ژانرها قرار دارد ")]
        private  void Then()
        {
            var actual = ReadContext.Genres.Single();
            actual.Title.Should().Be("اکشن");
        }
        [Fact]
        public void Run()
        {
            Runner.RunScenario(
                _=>Given(),
                _=>When().Wait(),
                _=>Then());
        }
    
    }
}
