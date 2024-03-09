using System.ComponentModel.DataAnnotations;

namespace FilmClub.Services.Films.Contracts.Dtos
{
    public class AddFilmDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Director { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Poblish { get; set; }
        [Required]
        public int AgeLimit { get; set; }
        [Required]
        public int PenaltyRate { get; set; }
        [Required]
        public int Duration { get; set; }

        public int Count { get; set; }
        public int Rate { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}
