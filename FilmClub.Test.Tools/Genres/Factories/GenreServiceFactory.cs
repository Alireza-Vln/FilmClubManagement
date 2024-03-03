using FilmClubManagement.Persistance.EF;
using FilmClubManagement.Persistance.EF.Genres;
using FilmClub.Services.Genres;
using FilmClub.Services.Genres.Cantracts;

namespace FilmClub.Test.Tools.Genres.Factories
{
    public class GenreServiceFactory
    {
        public  static GenreManageService Create(EFDataContext context)
        {
            return new  GenreManageAppService(new EFGenreRepository(context), new EFUnitOfWork(context));
        }
       
    }
}
