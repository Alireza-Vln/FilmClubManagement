﻿using FilmClub.Contracts;
using FilmClub.Entities.Films;
using FilmClub.Services.Genres.Contracts;
using FilmClub.Services.Unit.Test.Genres;

namespace FilmClub.Services.Unit.Test.FilmsTest
{
    public class FilmAppService : FilmService
    {
        readonly FilmRepository _FilmRepository;
        readonly GenreRepository _GenreRepository;
        readonly UnitOfWork _unitOfWork;
        public FilmAppService(FilmRepository repository,UnitOfWork unitOfWork, GenreRepository GenreRepository)
        {
            _GenreRepository = GenreRepository;
            _FilmRepository=repository;
            _unitOfWork=unitOfWork;
        }

        public async Task Add(int genreId, AddFilmDto dto)
        {
           var genre = _GenreRepository.FindGenreById(genreId);
           
            var film = new Film()
            {
                Name = dto.Name,
                GenreId = genre.Id,
                Description = dto.Description,
                Director = dto.Director,
                Duration = dto.Duration,
                AgeLimit = dto.AgeLimit,
                Count = dto.Count,
                PenaltyRate = dto.PenaltyRate,
                Poblish = dto.Poblish,
                Rate = dto.Rate,
            };

            _FilmRepository.Add(film);
            await _unitOfWork.Complete();
        }
    }
}
