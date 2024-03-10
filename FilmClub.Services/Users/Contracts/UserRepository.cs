using FilmClub.Services.Users.Contracts.Dtos;

namespace FilmClub.Services.Unit.Test.UsersTest
{
    public interface UserRepository
    {
        void Add(User user);
        User? FindUser(int id);
        List<GetUserDto> GetAll(UserFilterDto? filterDto);
        void Remove(User user);
    }
}
