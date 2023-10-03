namespace AirLab.Dtos.PurpleAirSensors
{
    public class PurpleAirSensorDto
    {
        public int SensorId { get; set; }
        public string? Name { get; set; }
        public DateTime? LastSeen { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Altitude { get; set; }
    }
}
