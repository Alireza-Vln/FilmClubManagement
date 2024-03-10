using FilmClub.Services.Users.Contracts.Dtos;
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

        public User? FindUser(int id)
        {
            return _users.FirstOrDefault(_ => _.Id == id);
        }

        public List<GetUserDto> GetAll(UserFilterDto? filterDto)
        {
            var user = _users.Select(_ => new GetUserDto
            {
                Id = _.Id,
                FirstName = _.FirstName,
                LastName = _.LastName,
                PhoneNumber = _.PhoneNumber,
                Age = ( DateTime.Now.Year - _.Age.Year),
                Address = _.Address,
                Gender = _.Gender.ToString(),
                Rate = _.Rate,
            });
            if (filterDto.FirstName != null)
            { 
            user=user.Where(_=>_.FirstName==filterDto.FirstName);
            }
            if (filterDto.LastName != null)
            {
                user=user.Where(_=>_.LastName==filterDto.LastName);
            }
            return user.ToList();
        }

        public void Remove(User user)
        {
            _users.Remove(user);
        }
    }
}
