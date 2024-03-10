using FilmClub.Spec.Tests.Users;
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

        public async Task Remove(int id)
        {
           var user = _repository.FindUser(id);
            if (user==null)
            {
                throw new ThrowDeleteUserIfUserIsNullException();
            }
            _repository.Remove(user);
            await _unitOfWork.Complete();
        }

        public async Task Update(int id, UpdateUserDto dto)
        {
          var user= _repository.FindUser(id);
            if (user == null)
            {
                throw new ThrowUpdateUserIfUserIsNullException() ;
            }
            user.FirstName= dto.FirstName;
            user.LastName= dto.LastName;
            user.Age= dto.Age;
            user.Gender= dto.Gender;
            user.Address= dto.Address;
            user.PhoneNumber= dto.PhoneNumber;
            await _unitOfWork.Complete();
            
        }
    }
}
