using CarRentalWebApp.Models;
using System.Text.Json;


namespace CarRentalWebApp.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://3.97.115.6/api/";

        public BookingRepository(HttpClient httpClient)
        {
             _httpClient = httpClient;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            // Return all bookings. Replace with actual DB code.
            var response = await _httpClient.GetAsync(_baseUrl + "bookings");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var bookings = await JsonSerializer.DeserializeAsync<IEnumerable<Booking>>(responseStream);
            return bookings;
        }

        public async Task<Booking> GetByIdAsync(int bookingId)
        {
            // Get a booking by ID. Replace with actual DB code.
            var response = await _httpClient.GetAsync($"https://localhost:7077/api/" + $"Booking/{bookingId}");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Booking>(responseStream);
        }

        public async Task AddAsync(Booking booking)
        {
            var content = new StringContent(JsonSerializer.Serialize(booking), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_baseUrl + "Booking", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(int bookingId, Booking booking)
        {
            var content = new StringContent(JsonSerializer.Serialize(booking), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(_baseUrl + $"Booking/{bookingId}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int bookingId)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Booking/{bookingId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
