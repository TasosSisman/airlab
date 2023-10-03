using AirLab.Data;
using AirLab.Dtos.PurpleAirSensors;
using AirLab.Models;
using AutoMapper;

namespace AirLab.Repositories.PurpleAir.PurpleAirSensors
{
    public class PurpleAirSensorRepository : IPurpleAirSensorRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PurpleAirSensorRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public ICollection<PurpleAirSensorDto> GetPurpleAirSensors()
        {
            var result = _context.PurpleAirSensors.ToList();

            return _mapper.Map<List<PurpleAirSensorDto>>(result);
        }

        public PurpleAirSensorDto GetPurpleAirSensor(int sensorId)
        {
            var result = _context.PurpleAirSensors
                .Where(x => x.SensorId == sensorId).FirstOrDefault();

            return _mapper.Map<PurpleAirSensorDto>(result);
        }
    }
}
