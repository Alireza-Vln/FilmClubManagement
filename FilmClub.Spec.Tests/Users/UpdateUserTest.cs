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

namespace FilmClub.Spec.Tests.Users
{
    [Scenario("ویرایش کاربر")]
    [Story("",
        AsA = "مدیر کلاب",
        IWantTo = "کابر را ویرایش کنم",
        InOrderTo = "کاربر را به روز کنم")]
    public class UpdateUserTest : BusinessIntegrationTest
    {
        readonly UserService _sut;
        private User _user;
        public UpdateUserTest()
        {
            _sut = UserServiceFactory.Create(SetupContext);
        }
        [Given("کاربری به اسم علیرضا  " +
           "فامیل ولدان " +
           "شماره تماس ۰۹۳۸۲۶۷۶۷۴۲ " +
           "ادرس شیراز" +
           "متولد ۳۱/۰۹/۱۹۹۵" +
           "با جنسیت اقا" +
           "در فهرست کاربر ها داریم")]
        public void Given()
        {
            _user = new User()
            {
                FirstName = "علیرضا",
                LastName = "ولدان",
                PhoneNumber = "۰۹۳۸۲۶۷۶۷۴۲",
                Address = "شیراز",
                Age = new DateTime(1995, 09, 30),
                Gender = Gender.Male,
            };
            DbContext.Save(_user);
        }
        [When("کاربری به اسم امیر  " +
             "فامیل ولدان " +
             "شماره تماس 09174437798 " +
             "ادرس شیراز" +
             "متولد ۳۱/۰۹/۱۹۹۵" +
             "با جنسیت اقا" +
             "در فهرست کاربر ها تغییر کند")]
        public async Task When()
        {
            var dto = new UpdateUserDto()
            {
                FirstName = "امیر",
                LastName = "ولدان",
                PhoneNumber = "09174437798",
                Address = "شیراز",
                Age = new DateTime(1995, 09, 30),
                Gender = Gender.Male,
            };
            await _sut.Update(_user.Id, dto);

        }

        [Then("کاربری به اسم امیر  " +
             "فامیل ولدان " +
             "شماره تماس 09174437798 " +
             "ادرس شیراز" +
             "متولد ۳۱/۰۹/۱۹۹۵" +
             "با جنسیت اقا" +
             "در فهرست کاربر ها وحود دارد")]
        public void Then()
        {
            var actual = ReadContext.Users.Single();
            actual.FirstName.Should().Be("امیر");
            actual.LastName.Should().Be("ولدان");
            actual.PhoneNumber.Should().Be("09174437798");
            actual.Address.Should().Be("شیراز");
            actual.Age.Should().Be(new DateTime(1995, 09, 30));
            actual.Gender.Should().Be(Gender.Male);

        }
        public void Run()
        {
            Runner.RunScenario(
                _ => Given(),
                _ => When().Wait(),
                _ => Then());
        }

    }

}
