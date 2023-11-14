using AirLab.Dtos.PurpleAirSensors;

namespace AirLab.Services.PurpleAir
{
    public interface IPurpleAirService
    {
        Task GetDataFromPurpleAirAsync();
        Task<PurpleAirSensorDto> AddPurpleAirSensor(int sensorId);
    }
}
