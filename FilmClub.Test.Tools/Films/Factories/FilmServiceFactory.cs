using FilmClubManagement.Persistance.EF;
using FilmClubManagement.Persistance.EF.Films;
using FilmClubManagement.Persistance.EF.Genres;
using FilmClub.Services.Films;
using FilmClub.Services.Films.Contracts;

namespace FilmClub.Test.Tools.Films.Factories
{
    public static class FilmServiceFactory
    {
        public static FilmService Create(EFDataContext context)
        {
            return new FilmAppService(new EFFilmRepository(context), new EFUnitOfWork(context), new EFGenreRepository(context));
        }
    }
}
