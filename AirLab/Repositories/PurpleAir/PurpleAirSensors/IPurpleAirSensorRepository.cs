using AirLab.Dtos.PurpleAirSensors;
using AirLab.Models;

namespace AirLab.Repositories.PurpleAir.PurpleAirSensors
{
    public interface IPurpleAirSensorRepository
    {
        ICollection<PurpleAirSensorDto> GetPurpleAirSensors();
        Task<PurpleAirSensorDto> GetPurpleAirSensorAsync(int sensorId);
        Task<bool> CreatePurpleAirSensorAsync(PurpleAirSensor sensor);
    }
}
