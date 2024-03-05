using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Dtos;
using FilmClubs.Contracts.Interfaces;

namespace FilmClub.Services.Unit.Test.GenresTest.GenreTests
{
    public class GenreAppService : GenreService
    {
        private readonly GenreRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        public GenreAppService(GenreRepository repository,UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork= unitOfWork;
        }

        public async Task<List<GetGenreDto>> Get(GenreFilterDto? filter)
        {
            return _repository.Get(filter);
        }
    }
}
