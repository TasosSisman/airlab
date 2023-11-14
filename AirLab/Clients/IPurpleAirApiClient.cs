using AirLab.Dtos.PurpleAirDatas;
using AirLab.Dtos.PurpleAirSensors;

namespace AirLab.Clients
{
    public interface IPurpleAirApiClient
    {
        Task<PurpleAirSensorDataFromApi> GetCurrentDataFromSensor(int sensorId, string apiKey);
        Task<NewPurpleAirSensor> GetDataForNewSensorAsync(int sensorId);
    }
}
