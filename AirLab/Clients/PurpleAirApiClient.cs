using AirLab.Dtos.PurpleAirDatas;
using AirLab.Dtos.PurpleAirSensors;
using AirLab.Repositories.ApplicationSettings;
using Newtonsoft.Json;
using System.Text.Json;

namespace AirLab.Clients
{
    public class PurpleAirApiClient : IPurpleAirApiClient
    {
        private readonly HttpClient _httpClient;

        public PurpleAirApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PurpleAirSensorDataFromApi> GetCurrentDataFromSensor(int sensorId, string apiKey)
        {
            try
            {
                if (!_httpClient.DefaultRequestHeaders.Contains("X-API-Key"))
                {
                    _httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKey);
                }
                else if(_httpClient.DefaultRequestHeaders.GetValues("X-API-Key").FirstOrDefault() != apiKey)
                {
                    _httpClient.DefaultRequestHeaders.Remove("X-API-Key");
                    _httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKey);
                }

                var response = await _httpClient.GetAsync($"{sensorId}");

                var jsonString = await response.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<PurpleAirApiJsonResponse>(jsonString);

                return results.SensorData;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<NewPurpleAirSensor> GetDataForNewSensorAsync(int sensorId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{sensorId}?fields=sensor_index,name,latitude,longitude,altitude");

                var jsonString = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<NewPurpleAirSensorJsonResponse>(jsonString);

                if (result?.NewSensor != null)
                    return result.NewSensor;

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
