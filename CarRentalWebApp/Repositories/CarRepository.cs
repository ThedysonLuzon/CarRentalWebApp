using CarRentalWebApp.Models;
using System.Text.Json;

namespace CarRentalWebApp.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://your-car-rental-api/"; // Replace with API base URL

        public CarRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "cars");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Car>>(responseStream);
        }

        public async Task<Car> GetByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"cars/{id}");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Car>(responseStream);
        }

        public async Task AddAsync(Car car)
        {
            var content = new StringContent(JsonSerializer.Serialize(car), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_baseUrl + "cars", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(string id, Car car)
        {
            var content = new StringContent(JsonSerializer.Serialize(car), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(_baseUrl + $"cars/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"cars/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
