using FilmClub.Services.Unit.Test.UsersTest;
using FilmClub.Test.Tools.Infrastructure.DatabaseConfig;
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
    [Scenario("حذف کردن کاربر")]
    [Story("",
        AsA = "مدیر کلاب",
        IWantTo = "کاربر را حذف کنم",
        InOrderTo = "تا ان کاربر را نداشته باشم")]
    public class DeleteUserTest : BusinessIntegrationTest
    {
        readonly UserService _sut;
        private User _user;
        public DeleteUserTest()
        {
            _sut = UserServiceFactory.Create(SetupContext);
        }
        [Given("کاربری به اسم علیرضا  " +
            "فامیل ولدان " +
            "شماره تماس ۰۹۳۸۲۶۷۶۷۴۲ " +
            "ادرس شیراز" +
            "متولد ۳۱/۰۹/۱۹۹۵" +
            "با جنسیت اقا" +
            "در فهرست فیلمها وجود دارد")]

        private void Given()
        {
            _user = new UserBuilder().Build();
            DbContext.Save(_user);
        }
        [When("کاربر مذکور را حذف میکنیم")]
        private async Task When()
        {
          await _sut.Remove(_user.Id);
        }
        [Then("در فهرست کابر ها کاربری وجود ندارد")]
        private void Then()
        {
            var actual=ReadContext.Users.FirstOrDefault(_=>_.Id==_user.Id);
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
