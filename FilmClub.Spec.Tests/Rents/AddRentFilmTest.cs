using FilmClub.Entities.Films;
using FilmClub.Entities.Genres;
using FilmClub.Services.Unit.Test.GenresTest;
using FilmClub.Services.Unit.Test.UsersTest;
using FilmClub.Spec.Tests.Users;
using FilmClub.Test.Tools.Genres.Builders;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;
using FilmClub.Tests.Tools.Infrastructure.DatabaseConfig.IntegrationTest;
using FilmClubs.Contracts.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FilmClub.Spec.Tests.Rents
{
    [Scenario("ٍثبت اجاره فیلم به کاربر")]
    [Story("",
        AsA ="کاربر",
        IWantTo ="فیلمی اجاره کنم",
        InOrderTo ="ان فیلم را تماشا کنم")]
    public class AddRentFilmTest : BusinessIntegrationTest
    {
        readonly RentService _sut;
        private User _user;
        private Film _film;
        private Genre _genre;
        private DateTime _fakeTime;
        public AddRentFilmTest()
        {
            _sut=RentServiceFactory.Create(SetupContext,_fakeTime);
           
        }
        [Given(" اجاره ای در فهرست اجارههای فیلم نیست")]
        [And("یک ژانر به عنوان معمایی در فهرست ژانرها میباشد")]
        [And("یک فیلم با اسم کلاب مشت زنی" +
            " با ژانر معمایی در فهرست فیلم ها میباشد")]
        [And("کاربری به اسم علیرضا رد فهرست کاربر ها میباشد")]
        private void Given()
        {
            _genre=new GenreBuilder()
                .WithTitle("معمایی")
                .Build();
            DbContext.Save(_genre);
            _film=new FilmBuilder() 
               . WithName("کلاب مشت زنی")
                .WithGenreId(_genre.Id).
                Build();
            DbContext.Save(_film);
            _user=new UserBuilder()
                .WithName("علیرضا")
                .Build();
            DbContext.Save(_user);
        }
        [When("کاربری به اسم علیرضا" +
            " و فامیل ولدان فیلم مذکور را اجاره میکند ")]
        public async Task When()
        {
           
            var dto = new AddRentDto
            {
                FilmId = _film.Id,
                UserId = _user.Id,
               
            };

           await _sut.Add(dto);
        }
        [Then("یک اجاره در فهرست اجاره ها میباشد")]
        public void Then()
        {
            var actual = ReadContext.Rents.Single();
            actual.FilmId.Should().Be(_film.Id);
            actual.UserId.Should().Be(_user.Id);
            actual.RentFilmTime.Should().Be(_fakeTime);
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
