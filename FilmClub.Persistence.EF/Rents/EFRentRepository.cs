using FilmClub.Entities.Films;
using FilmClub.Services.Rents;
using FilmClub.Services.Unit.Test.UsersTest;
using FilmClubManagement.Persistance.EF;
using Microsoft.EntityFrameworkCore;

namespace FilmClub.Spec.Tests.Rents
{
    public class EFRentRepository : RentRepository
    {
        readonly DbSet<Rent> _rent ;
        readonly DbSet<User> _user;
        readonly DbSet<Film> _film;
        public EFRentRepository(EFDataContext context)
        {
            _rent =context.Rents;
        }

        public void Add(Rent rent)
        {
            _rent.Add(rent);
        }

        //public Film? FindFilm(int filmId)
        //{
        //    return _film.FirstOrDefault(_ => _.Id == filmId);
        //}

        //public User? FindUser(int userId)
        //{
        //    return _user.FirstOrDefault(_ => _.Id == userId);
        //}
    }
}
