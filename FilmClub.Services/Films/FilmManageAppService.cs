using FilmClub.Entities.Films;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Films.Contracts.Dtos;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Unit.Test.FilmsTest;
using FilmClubs.Contracts.Interfaces;

namespace FilmClub.Services.Films
{
    public class FilmManageAppService : FilmManageService
    {
       public readonly FilmRepository _FilmRepository;
        readonly GenreRepository _GenreRepository;
        readonly UnitOfWork _unitOfWork;
        public FilmManageAppService(FilmRepository repository, UnitOfWork unitOfWork, GenreRepository GenreRepository)
        {
            _GenreRepository = GenreRepository;
            _FilmRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(int genreId, AddFilmDto dto)
        {
            var genre = _GenreRepository.FindGenreById(genreId);
            if(genre == null)
            {
                throw new ThrowAddsFilmIfGenreIsNullException();
            }
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

        public async Task<List<GetFilmManageDto>> Get(FilmFilterDto? filter)
        {
            return  _FilmRepository.GetAll(filter);
        }

        public async Task Remove(int id)
        {
            var film = _FilmRepository.FindFilm(id);
            if(film == null)
            {
                throw new ThrowRemoveFilmIfFilmIsNullException();
            }

             _FilmRepository.Remove(film);
            await _unitOfWork.Complete();
        }

        public async Task Update(int id, UpdateFilmDto dto)
        {
            var film=_FilmRepository.FindFilm(id);
            var genre=_GenreRepository.FindGenreById(dto.GenreId);
            if(genre == null)
            {
                throw new ThrowUpdateFilmProperlyIfGenreIsNullException();
            }
            if(film==null)
            {
                throw new ThrowUpdateFilmProperlyIfFilmIsNullException();
            }
          
            film.Name = dto.Name;
            film.Description = dto.Description;
            film.Director = dto.Director;
            film.Poblish = dto.Poblish;
            film.Duration = dto.Duration;
            film.AgeLimit = dto.AgeLimit;
            film.Count = dto.Count;
            film.PenaltyRate = dto.PenaltyRate;
            film.Rate = dto.Rate;
            film.GenreId= dto.GenreId;

            await _unitOfWork.Complete();
           
        }
    }
}
