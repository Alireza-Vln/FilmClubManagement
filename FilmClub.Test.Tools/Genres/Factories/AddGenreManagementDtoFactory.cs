using FilmClub.Services.Unit.Test.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Test.Tools.Genres.Factories
{
   public static class AddGenreManagementDtoFactory
    {
        public static AddGenreManageDto Create()
        {
            return new AddGenreManageDto()
            {

                Title = "Dummy-Title",

            };
        }
    }
}
