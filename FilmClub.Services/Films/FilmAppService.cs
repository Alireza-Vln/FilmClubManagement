using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Films.Contracts.Dtos;
using FilmClubs.Contracts.Interfaces;

namespace FilmClub.Services.Unit.Test.FilmsTest.FilmTest
{
    public class FilmAppService:FilmService
    {
        readonly FilmRepository _repository;
        readonly UnitOfWork _unitOfWork;
        public FilmAppService(FilmRepository repository,UnitOfWork unitOfWork)
        {
            _repository=repository;
            _unitOfWork=unitOfWork;
        }

        public async Task<List<GetFilmDto>> Get(FilmFilterDto filter)
        {
          return  _repository.Get(filter);
        }
    }
}
