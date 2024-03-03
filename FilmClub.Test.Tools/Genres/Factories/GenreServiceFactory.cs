using FilmClub.Services.Genres;
using FilmClub.Services.Genres.Contracts;
using FilmClub.Services.Unit.Test.Genres;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
