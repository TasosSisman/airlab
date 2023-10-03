using AirLab.Data;
using AirLab.Dtos.PurpleAirDatas;
using AirLab.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AirLab.Repositories.PurpleAir.PurpleAirDatas
{
    public class PurpleAirDataRepository : IPurpleAirDataRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PurpleAirDataRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<GetPurpleAirDataDto> GetPurpleAirData(DateTime? dateFrom, DateTime? dateTo, int sensorId = 129953)
        {
            var predicates = _context.PurpleAirData.Where(x => x.SensorId == sensorId);

            if (dateFrom.HasValue)
                predicates = predicates.Where(x => x.TimeStamp >= dateFrom);

            if (dateTo.HasValue)
                predicates = predicates.Where(x => x.TimeStamp <= dateTo);

            var result = predicates.ToList();

            return _mapper.Map<List<GetPurpleAirDataDto>>(result);
        }

        public async Task<bool> AddPurpleAirDataAsync(PurpleAirDataCreateDto dto)
        {
            var dataToAdd = _mapper.Map<PurpleAirData>(dto);

            _context.Add(dataToAdd);
            var result = await _context.SaveChangesAsync();

            return result == 1;
        }

        public async Task<DateTime?> GetLastTimeStampAsync(int sensorId)
        {
            var result = await _context.PurpleAirData
                .Where(x => x.SensorId == sensorId)
                .OrderByDescending(x => x.TimeStamp)
                .Select(x => x.TimeStamp)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
