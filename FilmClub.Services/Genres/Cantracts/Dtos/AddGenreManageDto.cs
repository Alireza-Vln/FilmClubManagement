using System.ComponentModel.DataAnnotations;

namespace FilmClub.Services.Genres.Cantracts.Dtos
{
    public class AddGenreManageDto
    {
        [Required]
        public string Title { get; set; }

    }
}
