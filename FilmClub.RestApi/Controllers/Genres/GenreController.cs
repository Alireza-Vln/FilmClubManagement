using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Dtos;
using FilmClub.Services.Unit.Test.GenresTest.GenreTests;
using Microsoft.AspNetCore.Mvc;

namespace FilmClub.RestApi.Controllers.Genres
{
    [ApiController]
    [Route("api/Genre")]
    public class GenreController : Controller
    {
        readonly GenreService _service;
        public GenreController(GenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<GetGenreDto>> Get([FromQuery] GenreFilterDto filterDto)
        {
            return await _service.Get(filterDto);
        }
    }
}
