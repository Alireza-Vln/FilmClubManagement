using FilmClub.Services.Unit.Test.GenresTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Test.Tools.Genres.Factories
{
    public static class UpdateGenreManageDtoFactory
    {
        public static UpdateGenreManageDto Create()
        {
            return new UpdateGenreManageDto()
            {
                Title = "Update-dummy-title",
            };
        }
    }
}
