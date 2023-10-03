using AirLab.Models;
using AutoMapper;

namespace AirLab.Dtos.PurpleAirDatas
{
    public class PurpleAirDataProfile : Profile
    {
        public PurpleAirDataProfile()
        {
            CreateMap<PurpleAirData, GetPurpleAirDataDto>();
            CreateMap<PurpleAirDataCreateDto, PurpleAirData>();
            CreateMap<PurpleAirSensorDataFromApi, PurpleAirDataCreateDto>()
                .ForMember(
                dest => dest.TimeStamp,
                opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.TimeStamp).LocalDateTime))
                .AfterMap((src, dest, context) => context.Mapper.Map(src.Stats, dest));
            CreateMap<PurpleAirSensorStats, PurpleAirDataCreateDto>();
        }
    }
}
