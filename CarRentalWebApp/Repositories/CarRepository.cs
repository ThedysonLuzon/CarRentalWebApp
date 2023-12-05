using CarRentalWebApp.Models;
using System.Text.Json;

namespace CarRentalWebApp.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://3.97.115.6/api/";

        public CarRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_baseUrl + "cars");
                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var cars = await JsonSerializer.DeserializeAsync<IEnumerable<Car>>(responseStream);
                return cars;
            }
            catch (HttpRequestException ex)
            {
                // Log or handle the HTTP request exception
                Console.WriteLine($"HTTP Request Exception: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                // Log or handle JSON deserialization exception
                Console.WriteLine($"JSON Deserialization Exception: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Catch any other unexpected exceptions
                Console.WriteLine($"Unexpected Exception: {ex.Message}");
                throw;
            }
        
    }

        public async Task<Car> GetByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"Car/{id}");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Car>(responseStream);
        }

        public async Task AddAsync(Car car)
        {
            var content = new StringContent(JsonSerializer.Serialize(car), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_baseUrl + "Car", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(string id, Car car)
        {
            var content = new StringContent(JsonSerializer.Serialize(car), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(_baseUrl + $"Car/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Car/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
