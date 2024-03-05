using FilmClub.Entities.Genres;
using FilmClub.Services.Genres.Cantracts.Dtos;
using FilmClub.Services.Unit.Test.GenresTest.GenreTests;
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
        List<GetGenreManageDto> GetAll(GenreFilterDto? filterDto);
        List<GetGenreDto> Get(GenreFilterDto? filterDto);
        void Remove(Genre? genre);
    }
}
