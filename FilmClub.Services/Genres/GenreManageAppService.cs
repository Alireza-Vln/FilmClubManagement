using FilmClub.Entities.Genres;
using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Dtos;
using FilmClub.Services.Genres.Cantracts.Exceptoins;
using FilmClubs.Contracts;

namespace FilmClub.Services.Genres
{
    public class GenreManageAppService : GenreManageService
    {
        private readonly GenreRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        public GenreManageAppService(GenreRepository repository, UnitOfWork unitOfWork)
        {
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
            if(genre.Films.Count!=0)
            {
                throw new ThrowDeleteGenreIfFilmIsNotNullException();
            }
             _repository.Remove(genre);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetGenreManageDto>> Get(GenreFilterDto? filter)
        {
            return  _repository.Get(filter);
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
