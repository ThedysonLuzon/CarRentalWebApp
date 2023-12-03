using System.Collections.Concurrent;
using CarRentalWebApp.Models;
using CarRentalWebApp.Repositories;

public class MockCarRepository : ICarRepository
{
    private readonly ConcurrentDictionary<string, Car> _cars = new ConcurrentDictionary<string, Car>();

    public MockCarRepository()
    {
        // Initialize mock data only if the dictionary is empty
        if (!_cars.Any())
        {
            _cars.TryAdd("1", new Car { CarId = "1", CarModel = "Tesla Model S", FuelType = "Electric", Mileage = "10000", RentalPricePerDay = 100 });
            _cars.TryAdd("2", new Car { CarId = "2", CarModel = "Toyota Corolla", FuelType = "Gasoline", Mileage = "5000", RentalPricePerDay = 50 });
        }
    }

    public Task<IEnumerable<Car>> GetAllAsync()
    {
        return Task.FromResult(_cars.Values.AsEnumerable());
    }

    public Task<Car> GetByIdAsync(string id)
    {
        _cars.TryGetValue(id, out var car);

        if (car == null)
        {
            // Handle the case when car is not found. 
            throw new KeyNotFoundException($"Car not found with ID: {id}");
        }

        return Task.FromResult(car);
    }

    public Task AddAsync(Car car)
    {
        _cars.TryAdd(car.CarId, car);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(string id, Car car)
    {
        if (_cars.ContainsKey(id))
        {
            _cars[id] = car;
            return Task.CompletedTask;
        }
        throw new KeyNotFoundException("Car not found with ID: " + id);
    }

    public Task DeleteAsync(string id)
    {
        _cars.TryRemove(id, out var removedCar);
        return Task.CompletedTask;
    }
}
