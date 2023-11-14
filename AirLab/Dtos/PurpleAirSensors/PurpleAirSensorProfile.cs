using AirLab.Models;
using AutoMapper;

namespace AirLab.Dtos.PurpleAirSensors
{
    public class PurpleAirSensorProfile : Profile
    {
        public PurpleAirSensorProfile()
        {
            CreateMap<PurpleAirSensor, PurpleAirSensorDto>()
                .ForMember(dest => dest.LastSeen, method => method.PreCondition(source => source.LastSeen.HasValue))
                .ForMember(dest => dest.LastSeen, method => method.MapFrom(source => source.LastSeen.Value.ToString("dd/MM/yyyy HH:mm") ?? null));
            CreateMap<NewPurpleAirSensor, PurpleAirSensor>();
        }
    }
}
