using Newtonsoft.Json;

namespace AirLab.Dtos.PurpleAirDatas
{
    public class PurpleAirApiJsonResponse
    {
        [JsonProperty("sensor")]
        public PurpleAirSensorDataFromApi SensorData { get; set; }
    }

    public class PurpleAirSensorDataFromApi
    {
        [JsonProperty("sensor_index")]
        public int SensorId { get; set; }
        [JsonProperty("last_seen")]
        public long TimeStamp { get; set; }
        [JsonProperty("humidity")]
        public double? Humidity { get; set; }
        [JsonProperty("temperature")]
        public double? Temperature { get; set; }
        [JsonProperty("pressure")]
        public double? Pressure { get; set; }
        [JsonProperty("pm1.0")]
        public double? Pm_1_0 { get; set; }
        [JsonProperty("pm2.5")]
        public double? Pm_2_5 { get; set; }
        [JsonProperty("pm2.5_alt")]
        public double? Pm_2_5_alt { get; set; }
        [JsonProperty("pm10.0")]
        public double? Pm_10_0 { get; set; }
        [JsonProperty("0.3_um_count")]
        public double? Um_count_0_3 { get; set; }
        [JsonProperty("0.5_um_count")]
        public double? Um_count_0_5 { get; set; }
        [JsonProperty("1.0_um_count")]
        public double? Um_count_1_0 { get; set; }
        [JsonProperty("pm1.0_cf_1")]
        public double? Pm_1_0_cf_1 { get; set; }
        [JsonProperty("pm1.0_atm")]
        public double? Pm_1_0_atm { get; set; }
        [JsonProperty("pm2.5_atm")]
        public double? Pm_2_5_atm { get; set; }
        [JsonProperty("pm2.5_cf_1")]
        public double? Pm_2_5_cf_1 { get; set; }
        [JsonProperty("pm10.0_atm")]
        public double? Pm_10_0_atm { get; set; }
        [JsonProperty("pm10.0_cf_1")]
        public double? Pm_10_0_cf_1 { get; set; }
        [JsonProperty("stats")]
        public PurpleAirSensorStats Stats { get; set; }
    }

    public class PurpleAirSensorStats
    {
        [JsonProperty("pm2.5_10minute")]
        public double? Pm_2_5_10minute { get; set; }
        [JsonProperty("pm2.5_30minute")]
        public double? Pm_2_5_30minute { get; set; }
        [JsonProperty("pm2.5_60minute")]
        public double? Pm_2_5_60minute { get; set; }
        [JsonProperty("pm2.5_6hour")]
        public double? Pm_2_5_6hour { get; set; }
        [JsonProperty("pm2.5_24hour")]
        public double? Pm_2_5_24hour { get; set; }
        [JsonProperty("pm2.5_1week")]
        public double? Pm_2_5_1week { get; set; }
    }
}
