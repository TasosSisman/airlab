using AirLab.Dtos.PurpleAirSensors;
using AirLab.Models;
using AirLab.Repositories.PurpleAir.PurpleAirSensors;
using AirLab.Services.PurpleAir;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AirLab.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PurpleAirSensorController : Controller
    {
        private readonly IPurpleAirSensorRepository _purpleAirSensorRepository;
        private readonly IPurpleAirService _purpleAirService;

        public PurpleAirSensorController(IPurpleAirSensorRepository purpleAirSensorRepository, IPurpleAirService purpleAirService)
        {
            _purpleAirSensorRepository = purpleAirSensorRepository;
            _purpleAirService = purpleAirService;
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
        public async Task<IActionResult> GetPurpleAirSensor(int sensorId)
        {
            var result = await _purpleAirSensorRepository.GetPurpleAirSensorAsync(sensorId);

            if (result == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(PurpleAirSensorDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddPurpleAirSensor(int sensorId)
        {
            var result = await _purpleAirService.AddPurpleAirSensor(sensorId);

            if (result == null)
                return BadRequest("The sensor could not be added. Please check that the sensor index is correct or contact the developers.");

            return Ok(result);
        }
    }
}
