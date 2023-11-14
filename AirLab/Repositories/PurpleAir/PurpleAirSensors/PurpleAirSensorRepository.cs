using AirLab.Data;
using AirLab.Dtos.PurpleAirSensors;
using AirLab.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public async Task<PurpleAirSensorDto> GetPurpleAirSensorAsync(int sensorId)
        {
            var result = await _context.PurpleAirSensors
                .Where(x => x.SensorId == sensorId).FirstOrDefaultAsync();

            return _mapper.Map<PurpleAirSensorDto>(result);
        }

        public async Task<bool> CreatePurpleAirSensorAsync(PurpleAirSensor sensor)
        {
            _context.Add(sensor);
            var result = await _context.SaveChangesAsync();

            return result == 1;
        } 
    }
}
