using FilmClub.Services.Unit.Test.UsersTest;

namespace FilmClub.Services.Users.Contracts.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Rate { get; set; }
    }
}
