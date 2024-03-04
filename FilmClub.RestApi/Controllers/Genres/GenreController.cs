using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FilmClub.RestApi.Controllers.Genres
{
    [ApiController]
    [Route("api/Genre")]
    public class GenreController : Controller
    {
        readonly GenreManageService _service;
        public GenreController(GenreManageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<GetGenreManageDto>> Get([FromQuery] GenreFilterDto filterDto)
        {
            return await _service.Get(filterDto);
        }
    }
}
