﻿using FilmClub.Entities.Films;
using FilmClub.Entities.Genres;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Films.Contracts.Dtos;
using FilmClub.Services.Unit.Test.FilmsTest;
using Microsoft.EntityFrameworkCore;

namespace FilmClubManagement.Persistance.EF.Films
{
    public class EFFilmRepository : FilmRepository
    {
        private readonly DbSet<Film> _Film;


        public EFFilmRepository(EFDataContext context)
        {
            _Film = context.Films;

        }

        public void Add(Film film)
        {
            _Film.Add(film);
        }

        public Film? FindFilm(int FilmId)
        {
            return _Film.FirstOrDefault(_ => _.Id == FilmId);
        }

        public Film? FindGenerFilm(int genreId)
        {
            return _Film.FirstOrDefault(_ => _.GenreId== genreId);
        }

        public List<GetFilmDto> Get(FilmFilterDto? filter)
        {

            var film = _Film.Include(_ => _.Genre)
                .Select(_ => new GetFilmDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    AgeLimit = _.AgeLimit,
                    Count = _.Count,
                    Description = _.Description,
                    Director = _.Director,
                    Duration = _.Duration,
                    PenaltyRate = _.PenaltyRate,
                    Publish = _.Poblish,
                    Rate = _.Rate,
                    GenreName = _.Genre.Title
                });
            if (filter.Director != null)
            {
                film = film.Where(_ => _.Director == filter.Director);

            }
            if (filter.Name != null)
            {
                film = film.Where(_ => _.Name == filter.Name);

            }

            if (filter.GenreName != null)
            {
                film = film.Where(_ => _.GenreName == filter.GenreName);

            };
            return film.ToList();
        }


        public List<GetFilmManageDto> GetAll(FilmFilterDto? filter)
        {
            var film = _Film.Include(_ => _.Genre)
                .Select(_ => new GetFilmManageDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    AgeLimit = _.AgeLimit,
                    Count = _.Count,
                    Description = _.Description,
                    Director = _.Director,
                    Duration = _.Duration,
                    PenaltyRate = _.PenaltyRate,
                    Poblish = _.Poblish,
                    Rate = _.Rate,
                    GenreName = _.Genre.Title
                });
            if (filter.Director != null)
            {
                film = film.Where(_ => _.Director == filter.Director);

            }
            if (filter.Name != null)
            {
                film = film.Where(_ => _.Name == filter.Name);

            }

            if (filter.GenreName != null)
            {
                film = film.Where(_ => _.GenreName == filter.GenreName);

            };
            return film.ToList();
        }

        public void Remove(Film film)
        {
            _Film.Remove(film);
        }
    }
}
