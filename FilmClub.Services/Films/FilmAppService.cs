using FilmClub.Entities.Films;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Films.Contracts.Dtos;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Unit.Test.FilmsTest;
using FilmClubs.Contracts.Interfaces;

namespace FilmClub.Services.Films
{
    public class FilmAppService : FilmService
    {
       public readonly FilmRepository _FilmRepository;
        readonly GenreRepository _GenreRepository;
        readonly UnitOfWork _unitOfWork;
        public FilmAppService(FilmRepository repository, UnitOfWork unitOfWork, GenreRepository GenreRepository)
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
            return  _FilmRepository.Get(filter);
        }
    }
}
