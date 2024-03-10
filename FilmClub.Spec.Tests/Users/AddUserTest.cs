using FilmClub.Services.Unit.Test.UsersTest;
using FilmClub.Test.Tools.Users.Factories;
using FilmClub.Tests.Tools.Infrastructure.DatabaseConfig.IntegrationTest;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FilmClub.Spec.Tests.Users
{
    [Scenario("اضافه کردن کاربر")]
    [Story("",
        AsA ="مدیر کلاب",
        IWantTo ="کاربر اضافه کنم",
        InOrderTo ="تا به کاربر فیلم اجاره کنم")]
    public class AddUserTest : BusinessIntegrationTest
    {
        readonly UserService _sut;
        public AddUserTest()
        {
            _sut = UserServiceFactory.Create(SetupContext);

        }
        [Given("فرض میکنیم در فهرست کاربرها کاربری وجود ندارد")]
        private void Given()
        {

        }
        [When("کاربری به اسم علیرضا ولدان " +
            "فامیل ولدان " +
            "شماره تماس ۰۹۳۸۲۶۷۶۷۴۲ " +
            "ادرس شیراز" +
            "متولد ۳۱/۰۹/۱۹۹۵" +
            "با جنسیت اقا" +
            "اضافه کنم")]
        public async Task When()
        {
            var dto = new AddUserDto
            {
                FirstName = "علیرضا",
                LastName = "ولدان",
                PhoneNumber = "۰۹۳۸۲۶۷۶۷۴۲",
                Address = "شیراز",
               Age = new DateTime(1995,09,30),
                Gender = Gender.Male,
            };
            await _sut.Add(dto);
        }
        [Then("کاربری به اسم علیرضا ولدان " +
            "فامیل ولدان " +
            "شماره تماس ۰۹۳۸۲۶۷۶۷۴۲ " +
            "ادرس شیراز" +
            "متولد ۳۱/۰۹/۱۹۹۵" +
            "با جنسیت اقا" +
            "در فهرست کاربر ها داریم")]
        public void Then()
        {
            var actual = ReadContext.Users.Single();
            actual.FirstName.Should().Be("علیرضا");
            actual.LastName.Should().Be("ولدان");
            actual.PhoneNumber.Should().Be("۰۹۳۸۲۶۷۶۷۴۲");
            actual.Address.Should().Be("شیراز");
            actual.Age.Should().Be(new DateTime(1995, 09, 30));
            actual.Gender.Should().Be(Gender.Male);
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
