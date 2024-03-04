using FilmClub.Services.Genres.Cantracts;
using FilmClub.Services.Genres.Cantracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FilmClub.RestApi.Controllers.Genres
{
    [ApiController]
    [Route("api/Genres")]
    public class GenreManageController : Controller
    {
        readonly GenreManageService _service;
        public GenreManageController(GenreManageService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Add([FromBody] AddGenreManageDto dto)
        {
            await _service.Add(dto);
        }
        [HttpDelete]
        public async Task Delete([FromQuery]int Id)
        {
            await _service.Delete(Id);
        }
        [HttpGet]
        public async Task<List<GetGenreManageDto>> Get([FromQuery]GenreFilterDto filterDto)
        {
            return await _service.Get(filterDto);
        }
        [HttpPatch]
        public async Task Update([FromQuery] int Id, [FromBody] UpdateGenreManageDto dto)
        {
            await _service.Update(Id, dto);
        }
    }
}
