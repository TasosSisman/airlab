using AirLab.Models;
using AutoMapper;

namespace AirLab.Dtos.PurpleAirSensors
{
    public class PurpleAirSensorProfile : Profile
    {
        public PurpleAirSensorProfile()
        {
            CreateMap<PurpleAirSensor, PurpleAirSensorDto>();
        }
    }
}
