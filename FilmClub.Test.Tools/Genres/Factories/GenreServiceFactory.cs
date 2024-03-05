using FilmClubManagement.Persistance.EF;
using FilmClubManagement.Persistance.EF.Genres;

namespace FilmClub.Services.Unit.Test.GenresTest.GenreTests
{
    public class GenreServiceFactory
    {
        public static GenreService Create(EFDataContext context)
        {
            return new GenreAppService(new EFGenreRepository(context),
                new EFUnitOfWork(context));
               
        }
    }
}
