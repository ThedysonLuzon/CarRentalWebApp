using CarRentalWebApp.Models;

namespace CarRentalWebApp.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(int bookingId);
        Task AddAsync(Booking booking);
        Task UpdateAsync(int bookingId, Booking booking);
        Task DeleteAsync(int bookingId);
    }
}
