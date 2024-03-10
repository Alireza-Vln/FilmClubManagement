namespace FilmClub.Services.Unit.Test.UsersTest
{
    public interface UserRepository
    {
        void Add(User user);
        User? FindUser(int id);
        void Remove(User user);
    }
}
