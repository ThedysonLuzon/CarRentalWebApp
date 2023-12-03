using CarRentalWebApp.Models;

namespace CarRentalWebApp.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(string id);
        Task AddAsync(Car car);
        Task UpdateAsync(string id, Car car);
        Task DeleteAsync(string id);
    }
}
