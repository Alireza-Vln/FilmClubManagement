using System.ComponentModel.DataAnnotations;

namespace FilmClub.Spec.Tests.Rents
{
    public class AddRentDto
    {
        [Required]
        public int FilmId { get; set; }
        [Required]
        public int UserId { get; set; }
      
    }
}