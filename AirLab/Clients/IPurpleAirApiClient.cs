using AirLab.Dtos.PurpleAirDatas;

namespace AirLab.Clients
{
    public interface IPurpleAirApiClient
    {
        Task<PurpleAirSensorDataFromApi> GetCurrentDataFromSensor(int sensorId);
    }
}
