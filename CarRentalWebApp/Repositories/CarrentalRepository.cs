using CarRentalWebApp.Models;
using System.Text.Json;


namespace CarRentalWebApp.Repositories
{
    public class CarRentalRepository : ICarRentalRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://3.97.115.6/api/"; 

        public CarRentalRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Carrental>> GetAllAsync()
        {
            // Example implementation for GetAllAsync
            var response = await _httpClient.GetAsync(_baseUrl + "carrentals");
            response.EnsureSuccessStatusCode();
            // return Task.FromResult<IEnumerable<Carrental>>(_carRentals);
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var carrentals = await JsonSerializer.DeserializeAsync<IEnumerable<Carrental>>(responseStream);
            return carrentals;
        }

        public async Task<Carrental> GetByIdAsync(string carRentalId)
        {
            // Example implementation for GetByIdAsync
            var response = await _httpClient.GetAsync($"https://localhost:7077/api/" + $"carrental/{carRentalId}");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Carrental>(responseStream);
        }

        public async Task AddAsync(Carrental carRental)
        {
            // Example implementation for AddAsync
            var content = new StringContent(JsonSerializer.Serialize(carRental), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_baseUrl + "Carrental", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(Carrental carRental,string id)
        {
            // Find the existing car rental in the list
            var content = new StringContent(JsonSerializer.Serialize(carRental), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(_baseUrl + $"Carrental/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(string carRentalId)
        {
            // Example implementation for DeleteAsync
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Carrental/{carRentalId}");
            response.EnsureSuccessStatusCode();
        }
    }


}
