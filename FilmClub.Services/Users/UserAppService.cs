using FilmClubs.Contracts.Interfaces;
using static FilmClub.Services.Unit.Test.UsersTest.UserAppService;

namespace FilmClub.Services.Unit.Test.UsersTest
{
    public partial class UserAppService:UserService
    {
        private UserRepository _repository;
        private UnitOfWork _unitOfWork;

        public UserAppService(UserRepository repository, UnitOfWork UnitOfWork)
        {
           _repository= repository;
            _unitOfWork= UnitOfWork;
        }

        public async Task Add(AddUserDto dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                Gender = dto.Gender,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
            };


            _repository.Add(user);
            await _unitOfWork.Complete();
        }
    }
}
