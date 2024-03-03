using FilmClub.Entities.Films;

namespace FilmClub.Services.Genres
{
    public class Genre
    {
        public Genre()
        {
            Films = new();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Rate { get; set; }
        public HashSet<Film> Films { get; set; }
    }

}
