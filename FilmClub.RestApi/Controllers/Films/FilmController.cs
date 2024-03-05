using FilmClub.Services.Films.Contracts.Dtos;
using FilmClub.Services.Unit.Test.FilmsTest;
using FilmClub.Services.Unit.Test.FilmsTest.FilmTest;
using Microsoft.AspNetCore.Mvc;

namespace FilmClub.RestApi.Controllers.Films
{
    [ApiController]
    [Route("api/Films")]
    public class FilmController : Controller
    {
        readonly FilmService _service;
        public FilmController(FilmService service)
        {
            _service = service;
                
        }
        [HttpGet]
        public async Task<List<GetFilmDto>> Get([FromQuery]FilmFilterDto? dto)
        {
         return await _service.Get(dto);
        } 
    }
}
