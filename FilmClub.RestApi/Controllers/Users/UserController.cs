using FilmClub.Services.Unit.Test.UsersTest;
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
    }
}
