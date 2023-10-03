using AirLab.Dtos.PurpleAirDatas;
using Newtonsoft.Json;
using System.Text.Json;

namespace AirLab.Clients
{
    public class PurpleAirApiClient : IPurpleAirApiClient
    {
        private const string PurpleAirApiKey = "C35AD90F-F7E3-11ED-BD21-42010A800008";

        private readonly HttpClient _httpClient;

        public PurpleAirApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("X-API-Key", PurpleAirApiKey);
        }

        public async Task<PurpleAirSensorDataFromApi> GetCurrentDataFromSensor(int sensorId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{sensorId}");

                var jsonString = await response.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<PurpleAirApiJsonResponse>(jsonString);

                if (results != null)
                    return results.SensorData;

                return new PurpleAirSensorDataFromApi();
            }
            catch (Exception ex)
            {
                return new PurpleAirSensorDataFromApi();
            }

        }
    }
}
