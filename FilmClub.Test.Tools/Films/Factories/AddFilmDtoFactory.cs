
using FilmClub.Services.Genres;
using FilmClub.Services.Unit.Test.FilmsTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Test.Tools.Films.Factories
{
    public static class AddFilmDtoFactory
    {
        public static AddFilmDto Create(int genderId)
        {
            return new AddFilmDto()
            {
                Name = "dummy-name",
                Director = "dummy-director",
                Poblish = "dummy-polish",
                AgeLimit = 18,
                Count = 1,
                PenaltyRate = 1,
                Duration = 1,
                Description = "dummy-description",
                Rate = 1,
                GenreId = genderId,

            };
        }
    }
}
