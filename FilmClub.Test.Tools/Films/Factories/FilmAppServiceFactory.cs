using FilmClubManagement.Persistance.EF;
using FilmClubManagement.Persistance.EF.Films;

namespace FilmClub.Services.Unit.Test.FilmsTest.FilmTest
{
    public static class FilmAppServiceFactory
    {
        public static FilmService Create(EFDataContext context)
        {
            return new FilmAppService(new EFFilmRepository(context),
                new EFUnitOfWork(context));
        }
    }
}
