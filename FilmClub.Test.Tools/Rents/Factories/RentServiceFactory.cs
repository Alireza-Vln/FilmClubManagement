using FilmClub.Services.Unit.Test.UsersTest;
using FilmClubManagement.Persistance.EF;
using FilmClubManagement.Persistance.EF.Films;
using FilmClubs.Contracts.Interfaces;
using Moq;

namespace FilmClub.Spec.Tests.Rents
{
    public static class RentServiceFactory
    {
      
        public static RentService Create(EFDataContext context,DateTime? fakeTime=null)
        {
            var dateTimeServiceMock = new Mock<DateTimeService>();
            dateTimeServiceMock.Setup(_ => _.Now()).Returns(fakeTime ?? new DateTime(2023, 10, 10));
            return new RentAppService(new EFRentRepository(context),
                new EFUnitOfWork(context),
                dateTimeServiceMock.Object,
                new EFUserRepository(context),
                new EFFilmRepository(context));
        }
    }
}
