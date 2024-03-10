using FilmClub.Entities.Films;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Rents;
using FilmClub.Services.Unit.Test.UsersTest;
using FilmClubs.Contracts.Interfaces;

namespace FilmClub.Spec.Tests.Rents
{
    public class RentAppService : RentService
    {
        readonly RentRepository _repository;
        readonly UnitOfWork _unitOfWork;
        readonly DateTimeService _dateTimeService;
        readonly UserRepository _userRepository;
        readonly FilmRepository _filmRepository;
        public RentAppService
            (RentRepository repository,
            UnitOfWork unitOfWork,
            DateTimeService dateTimeService,
            UserRepository userRepository,
            FilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
            _userRepository = userRepository;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _dateTimeService = dateTimeService;
        }
        public async Task Add(AddRentDto dto)
        {
            var film = _filmRepository.FindFilm(dto.FilmId);
            if (film == null)
            {

            }
            var user = _userRepository.FindUser(dto.UserId);
            if (user == null)
            {

            }

            var rent = new Rent()
            {
                FilmId = film.Id,
                UserId = user.Id,
                RentFilmTime = _dateTimeService.Now()
                

            };


            _repository.Add(rent);
            await _unitOfWork.Complete();
        }
    }
}
