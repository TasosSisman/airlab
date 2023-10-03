using AirLab.Models;
using AirLab.Repositories.PurpleAir.PurpleAirDatas;
using Microsoft.AspNetCore.Mvc;

namespace AirLab.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PurpleAirDataController : Controller
    {
        private readonly IPurpleAirDataRepository _purpleAirDataRepository;

        public PurpleAirDataController(IPurpleAirDataRepository purpleAirDataRepository)
        {
            _purpleAirDataRepository = purpleAirDataRepository;
        }


        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(PurpleAirSensor))]
        [ProducesResponseType(400)]
        public IActionResult GetPurpleAirRecords([FromQuery] int sensorId,[FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            var result = _purpleAirDataRepository.GetPurpleAirData(dateFrom, dateTo, sensorId);

            if (result == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }
    }
}
