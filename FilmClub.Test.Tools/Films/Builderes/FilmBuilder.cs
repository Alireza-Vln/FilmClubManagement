using FilmClub.Entities.Films;

namespace FilmClub.Services.Unit.Test.GenresTest
{
    public class FilmBuilder
    {
        public readonly Film _film;
        public FilmBuilder()
        {
            _film = new Film
            {
                Name = "dummy-name",
                Director = "dummy-director",
                Poblish = "dummy-polish",
                AgeLimit = 18,
                Count = 1,
                PenaltyRate = 1,
                Duration = 1,
                Description = "dummy-description",
                Rate = 1,
                GenreId = 1,
            };  
        }
        public FilmBuilder WithName(string name)
        {
            _film.Name = name;
            return this;
        }
        public FilmBuilder WithGenreId(int genreId)
        {
            _film.GenreId= genreId;
            return this;
        }

        public Film Build() 
        {
            return _film;
        }
    }
}
