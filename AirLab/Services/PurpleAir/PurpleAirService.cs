using AirLab.Clients;
using AirLab.Dtos.PurpleAirDatas;
using AirLab.Dtos.PurpleAirSensors;
using AirLab.Models;
using AirLab.Repositories.ApplicationSettings;
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
        private readonly IApplicationSettingsRepository _applicationSettingsRepository;
        private readonly IMapper _mapper;

        public PurpleAirService(
            IPurpleAirApiClient purpleAirApiClient,
            IPurpleAirSensorRepository purpleAirSensorRepository,
            IPurpleAirDataRepository purpleAirDataRepository,
            IApplicationSettingsRepository applicationSettingsRepository,
            IMapper mapper)
        {
            _purpleAirApiClient = purpleAirApiClient;
            _purpleAirSensorRepository = purpleAirSensorRepository;
            _purpleAirDataRepository = purpleAirDataRepository; 
            _applicationSettingsRepository = applicationSettingsRepository;
            _mapper = mapper;
        }


        public async Task GetDataFromPurpleAirAsync()
        {
            try
            {
                var sensors = _purpleAirSensorRepository.GetPurpleAirSensors();
                var apiKey = await _applicationSettingsRepository.GetSettingValueByKey("PurpleAirApiKey");

                foreach (var sensor in sensors)
                {
                    var sensorData = await _purpleAirApiClient.GetCurrentDataFromSensor(sensor.SensorId, apiKey);

                    if (sensorData == null)
                        return;

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


        public async Task<PurpleAirSensorDto> AddPurpleAirSensor(int sensorId)
        {
            try
            {
                var newSensorDto = await _purpleAirApiClient.GetDataForNewSensorAsync(sensorId);

                if (newSensorDto == null)
                    return null;

                var newSensor = _mapper.Map<PurpleAirSensor>(newSensorDto);

                var result = await _purpleAirSensorRepository.CreatePurpleAirSensorAsync(newSensor);

                if (!result)
                    return null;

                return await _purpleAirSensorRepository.GetPurpleAirSensorAsync(sensorId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
