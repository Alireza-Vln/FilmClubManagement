using FilmClub.Entities.Genres;
using FilmClub.Services.Genres.Cantracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Services.Genres.Cantracts
{
    public interface GenreRepository
    {
        Task Add(Genre genre);
        Genre? FindGenreById(int id);
        List<GetGenreManageDto> Get(GenreFilterDto? filterDto);
        void Remove(Genre? genre);
    }
}
