using AirLab.Data;
using AirLab.Models;

namespace AirLab
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if (!_context.PurpleAirSensors.Any())
            {
                var sensor = new PurpleAirSensor()
                {
                    SensorId = 129953,
                    Name = "ENVICARE-18",
                    LastSeen = DateTime.Now,
                    Latitude = 37.978294d,
                    Longitude = 23.672758d,
                    Altitude = 65
                };
                _context.PurpleAirSensors.Add(sensor);
                _context.SaveChanges();
            }
        }
    }
}
