using AirLab.Clients;
using AirLab.Dtos.PurpleAirDatas;
using AirLab.Repositories.PurpleAir.PurpleAirDatas;
using AirLab.Repositories.PurpleAir.PurpleAirSensors;
using AutoMapper;

namespace AirLab.Services.PurpleAir
{
    public class PurpleAirService : IPurpleAirService
    {
        private readonly IPurpleAirApiClient _purpleAirApiClient;
        private readonly IPurpleAirSensorRepository _purpleAirSensorRepository;
        private readonly IPurpleAirDataRepository _purpleAirDataRepository;
        private readonly IMapper _mapper;

        public PurpleAirService(
            IPurpleAirApiClient purpleAirApiClient,
            IPurpleAirSensorRepository purpleAirSensorRepository,
            IPurpleAirDataRepository purpleAirDataRepository,
            IMapper mapper)
        {
            _purpleAirApiClient = purpleAirApiClient;
            _purpleAirSensorRepository = purpleAirSensorRepository;
            _purpleAirDataRepository = purpleAirDataRepository;
            _mapper = mapper;
        }
        public async Task GetDataFromPurpleAirAsync()
        {
            try
            {
                var sensors = _purpleAirSensorRepository.GetPurpleAirSensors();

                foreach (var sensor in sensors)
                {
                    var sensorData = await _purpleAirApiClient.GetCurrentDataFromSensor(sensor.SensorId);

                    var lastDataTimestamp = await _purpleAirDataRepository.GetLastTimeStampAsync(sensor.SensorId);

                    if (lastDataTimestamp.HasValue && DateTimeOffset.FromUnixTimeSeconds(sensorData.TimeStamp).UtcDateTime > lastDataTimestamp)
                    {
                        var dataToAdd = _mapper.Map<PurpleAirDataCreateDto>(sensorData);

                        _ = await _purpleAirDataRepository.AddPurpleAirDataAsync(dataToAdd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
