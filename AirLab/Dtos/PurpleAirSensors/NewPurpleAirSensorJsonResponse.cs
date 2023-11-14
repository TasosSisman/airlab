using Newtonsoft.Json;

namespace AirLab.Dtos.PurpleAirSensors
{
    public class NewPurpleAirSensorJsonResponse
    {
        [JsonProperty("sensor")]
        public NewPurpleAirSensor NewSensor { get; set; }
    }

    public class NewPurpleAirSensor
    {
        [JsonProperty("sensor_index")]
        public int SensorId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("latitude")]
        public double? Latitude { get; set; }
        [JsonProperty("longitude")]
        public double? Longitude { get; set; }
        [JsonProperty("altitude")]
        public double? Altitude { get; set; }
    }
}
