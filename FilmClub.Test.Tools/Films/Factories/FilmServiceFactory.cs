using FilmClub.Services.Unit.Test.FilmsTest;
using FilmClub.Services.Unit.Test.Genres;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
