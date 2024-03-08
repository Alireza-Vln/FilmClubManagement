using FilmClub.Entities.Genres;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Dtos;
using FilmClub.Services.Genres.Cantracts.Exceptoins;
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
    [Scenario("اضافه شدن ژانر")]
    [Story("",
        AsA = "مدیر کلاب",
        IWantTo = "ژانر جدید اضافه کنم",
        InOrderTo = "ژانر را به فیلم ها اجاره کنم")]

    public class AddGenreWithDuplicateTitle:BusinessIntegrationTest
    {
        readonly GenreManageService _sut;
         private Genre _genre;
         private AddGenreManageDto _dto;
      
        public AddGenreWithDuplicateTitle()
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
        [When("من ژانری به عنوان اکشن به فهرست ژانرها اضافه میکنم ")]
        private async Task When()
        {
            _dto = AddGenreManagementDtoFactory.Create("اکشن");
           
        }
        [Then("  تنها یک دسته بندی در فهرست ژانر با عنوان اکشن  باید وجود داشته باشد")]
        [And("خطای با عنوان  این اسم تکراری است باید رخ دهد")]
        public void Then()
        {
            
            var actual =()=> _sut.Add(_dto);
            actual.Should().ThrowExactlyAsync<ThrowAddGenreIsDuplicateException>();
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
