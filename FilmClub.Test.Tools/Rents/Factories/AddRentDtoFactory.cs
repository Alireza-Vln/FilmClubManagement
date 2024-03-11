using FilmClub.Services.Unit.Test.UsersTest;
using FilmClub.Spec.Tests.Rents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Test.Tools.Rents.Factories
{
    public static class AddRentDtoFactory
    {
        public static AddRentDto Create(int? filmId = null,
                                         int? userId = null)
        {
            return new AddRentDto()
            {
                FilmId = filmId ?? 1,
                UserId = userId ?? 1,
            };

        }
    }
}
