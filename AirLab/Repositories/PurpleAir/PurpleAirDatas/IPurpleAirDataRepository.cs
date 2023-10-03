using AirLab.Dtos.PurpleAirDatas;
using AirLab.Dtos.PurpleAirSensors;

namespace AirLab.Repositories.PurpleAir.PurpleAirDatas
{
    public interface IPurpleAirDataRepository
    {
        ICollection<GetPurpleAirDataDto> GetPurpleAirData(DateTime? dateFrom, DateTime? dateTo, int sensorId = 129953);
        Task<bool> AddPurpleAirDataAsync(PurpleAirDataCreateDto dto);
        Task<DateTime?> GetLastTimeStampAsync(int sensorId);
    }
}
