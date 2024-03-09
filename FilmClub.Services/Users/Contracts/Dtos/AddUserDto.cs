using System.ComponentModel.DataAnnotations;

namespace FilmClub.Services.Unit.Test.UsersTest
{
    public class AddUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
      
    }
}
