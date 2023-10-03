using AirLab.Dtos.PurpleAirSensors;
using AirLab.Models;

namespace AirLab.Repositories.PurpleAir.PurpleAirSensors
{
    public interface IPurpleAirSensorRepository
    {
        ICollection<PurpleAirSensorDto> GetPurpleAirSensors();
        PurpleAirSensorDto GetPurpleAirSensor(int sensorId);
    }
}
