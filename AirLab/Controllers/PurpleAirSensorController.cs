using AirLab.Dtos.PurpleAirSensors;
using AirLab.Models;
using AirLab.Repositories.PurpleAir.PurpleAirSensors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AirLab.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PurpleAirSensorController : Controller
    {
        private readonly IPurpleAirSensorRepository _purpleAirSensorRepository;

        public PurpleAirSensorController(IPurpleAirSensorRepository purpleAirSensorRepository)
        {
            _purpleAirSensorRepository = purpleAirSensorRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PurpleAirSensorDto>))]
        public IActionResult GetPurpleAirSensors()
        {
            var result = _purpleAirSensorRepository.GetPurpleAirSensors();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }

        [HttpGet("{sensorId}")]
        [ProducesResponseType(200, Type = typeof(PurpleAirSensor))]
        [ProducesResponseType(400)]
        public IActionResult GetPurpleAirSensor(int sensorId)
        {
            var result = _purpleAirSensorRepository.GetPurpleAirSensor(sensorId);

            if (result == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }
    }
}
