using FilmClub.Entities.Genres;
using FilmClub.Services.Films.Contracts;
using FilmClub.Services.Films.Contracts.Dtos;
using FilmClub.Services.Unit.Test.FilmsTest;
using Microsoft.AspNetCore.Mvc;

namespace FilmClub.RestApi.Controllers.Films
{
    [ApiController]
    [Route("api/Films")]
    public class FilmManageController : Controller
    {
        private readonly FilmService _service;
        public FilmManageController(FilmService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task Add([FromQuery] int genreId,AddFilmDto dto)
        {
            await _service.Add(genreId, dto);
        }
        [HttpGet]
        public async Task<List<GetFilmManageDto>> Get([FromQuery] FilmFilterDto? filterDto)
        {
            return await _service.Get(filterDto);
        }


    }
}
