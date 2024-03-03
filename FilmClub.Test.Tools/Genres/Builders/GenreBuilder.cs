using FilmClub.Services.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Test.Tools.Genres.Builders
{
   public class GenreBuilder
    {
        readonly Genre _genre;
        public GenreBuilder()
        {
            _genre = new Genre()
            {
                Id = 1,
                Title = "dummy-title",
                Rate = 100, 
            };
        }
        public GenreBuilder WithId(int id)
        { 
        
        _genre.Id = id;
            return this;
        }
        public GenreBuilder WithTitle(string title)
        {
            _genre.Title = title;
            return this;
        }
        public GenreBuilder WithRate(int rate)
        {
            _genre.Rate = rate;
            return this;
        }
       
        public Genre Build()
        {
            return _genre;
        }
    }
}
