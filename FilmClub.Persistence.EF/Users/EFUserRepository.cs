using FilmClubManagement.Persistance.EF;
using Microsoft.EntityFrameworkCore;

namespace FilmClub.Services.Unit.Test.UsersTest
{
    public class EFUserRepository:UserRepository
    {
        private DbSet<User> _users;

        public EFUserRepository(EFDataContext context)
        {
            _users = context.Users;
        }

        public void Add(User user)
        {
          _users.Add(user);
        }
    }
}
