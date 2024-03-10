using FilmClub.Entities.Films;
using FilmClub.Services.Rents;
using FilmClub.Services.Unit.Test.UsersTest;

namespace FilmClub.Spec.Tests.Rents
{
    public interface RentRepository
    {
        void Add(Rent rent);
       // Film? FindFilm(int filmId);
      //  User? FindUser(int userId);
    }
}
