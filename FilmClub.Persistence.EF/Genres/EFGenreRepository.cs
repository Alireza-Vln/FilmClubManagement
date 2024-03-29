﻿using FilmClub.Entities.Genres;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Dtos;
using FilmClub.Services.Unit.Test.GenresTest.GenreTests;
using Microsoft.EntityFrameworkCore;

namespace FilmClubManagement.Persistance.EF.Genres
{
    public class EFGenreRepository : GenreRepository
    {
        private readonly DbSet<Genre> _genre;

        public EFGenreRepository(EFDataContext context)
        {
            _genre = context.Genres;
        }

        public async Task Add(Genre genre)
        {
            _genre.Add(genre);
        }

        public Genre? FindGenreById(int id)
        {
            return _genre.FirstOrDefault(_ => _.Id == id);
        }


        public void Remove(Genre? genre)
        {
            _genre.Remove(genre);
        }

        public List<GetGenreManageDto> GetAll(GenreFilterDto? filterDto)
        {
            var genre = _genre.Select(_ => new GetGenreManageDto
            {
                Id = _.Id,
                Title = _.Title,
                Rate = _.Rate,

            });
            if (filterDto.Title != null)
            {
                genre = genre.Where(_ => _.Title == filterDto.Title);
            }
            return genre.ToList();
        }

        public List<GetGenreDto> Get(GenreFilterDto? filterDto)
        {
            var genre = _genre.Select(_ => new GetGenreDto
            {
                Title = _.Title,
                Rate = _.Rate,

            });
            if (filterDto.Title != null)
            {
                genre = genre.Where(_ => _.Title == filterDto.Title);
            }
            return genre.ToList();
        }

        public bool IsExistGenreName(string title)
        {
            return _genre.Any(_ => _.Title == title);
        }
    }
}
