using FilmClub.Spec.Tests.Rents;
using Microsoft.AspNetCore.Mvc;

namespace FilmClub.RestApi.Controllers.Rents
{
    [ApiController]
    [Route("api/Rents")]
    public class RentController : Controller
    {
        readonly RentService _service;
        public RentController(RentService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task AddRent([FromBody] AddRentDto dto)
        {
            await _service.Add(dto);
        }
    }
}
