using FilmClub.Services.Unit.Test.UsersTest;
using FilmClub.Services.Users.Contracts.Dtos;
using FilmClub.Spec.Tests.Users;
using Microsoft.AspNetCore.Mvc;

namespace FilmClub.RestApi.Controllers.Users
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task Add([FromBody] AddUserDto dto)
        {
            await _service.Add(dto);
        }
        [HttpDelete]
        public async Task Delete([FromQuery] int userId)
        {
            await _service.Remove(userId);
        }
        [HttpPatch]
        public async Task Update([FromQuery]int id, [FromBody] UpdateUserDto dto)
        {
            await _service.Update(id, dto);
        }
        [HttpGet]
        public async Task<List<GetUserDto>> GetAll([FromQuery] UserFilterDto? dto)
        {
       return  await _service.Get(dto);
        }
    }
}
