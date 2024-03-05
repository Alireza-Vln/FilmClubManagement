using FilmClub.Entities.Genres;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Dtos;
using FilmClub.Services.Genres.Cantracts.Exceptoins;
using FilmClubs.Contracts.Interfaces;

namespace FilmClub.Services.Genres
{
    public class GenreManageAppService : GenreManageService
    {
        private readonly GenreRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly FilmRepository _filmRepository;
        public GenreManageAppService(GenreRepository repository, UnitOfWork unitOfWork,FilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddGenreManageDto dto)
        {
            var genre = new Genre()
            {
                Title = dto.Title,
            };
            await _repository.Add(genre);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
           var genre= _repository.FindGenreById(id);
            if (genre == null)
            {
                throw new ThrowDeleteGenreIsNullException();
            }
            if(_filmRepository.FindFilm(genre.Id)!=null)
            {
                throw new ThrowDeleteGenreIfFilmIsNotNullException();
            }
             _repository.Remove(genre);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetGenreManageDto>> Get(GenreFilterDto? filter)
        {
            return  _repository.GetAll(filter);
        }

        public async Task Update(int id, UpdateGenreManageDto dto)
        {
            var genre= _repository.FindGenreById(id);
            if(genre == null)
            {
                throw new ThrowUpdateGenreIsNullException();
            }
             genre.Title= dto.Title;

           await _unitOfWork.Complete();
        }
    }
}
