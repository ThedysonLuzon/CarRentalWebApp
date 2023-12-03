using CarRentalWebApp.Models;

namespace CarRentalWebApp.Repositories
{
    public class CarRentalRepository : ICarRentalRepository
    {
        // Assuming you're using an in-memory list for mock purposes
        private readonly List<Carrental> _carRentals = new();

        public CarRentalRepository()
        {
            // Optionally initialize with some data
        }

        public Task<IEnumerable<Carrental>> GetAllAsync()
        {
            // Example implementation for GetAllAsync
            return Task.FromResult<IEnumerable<Carrental>>(_carRentals);
        }

        public Task<Carrental> GetByIdAsync(string carRentalId)
        {
            // Example implementation for GetByIdAsync
            var carRental = _carRentals.FirstOrDefault(cr => cr.Carrentalid == carRentalId);
            return Task.FromResult(carRental);
        }

        public Task AddAsync(Carrental carRental)
        {
            // Example implementation for AddAsync
            _carRentals.Add(carRental);
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Carrental carRental)
        {
            // Find the existing car rental in the list
            var existingCarRental = _carRentals.FirstOrDefault(cr => cr.Carrentalid == carRental.Carrentalid);
            if (existingCarRental != null)
            {
                // Update properties here
                existingCarRental.Carrentalcompanyname = carRental.Carrentalcompanyname;
                existingCarRental.Location = carRental.Location;
                // Update other properties as necessary
            }
            else
            {
                // Handle the case where the car rental doesn't exist, e.g., throw an exception or do nothing
            }
        }

        public Task DeleteAsync(string carRentalId)
        {
            // Example implementation for DeleteAsync
            var carRental = _carRentals.FirstOrDefault(cr => cr.Carrentalid == carRentalId);
            if (carRental != null)
            {
                _carRentals.Remove(carRental);
            }
            return Task.CompletedTask;
        }
    }


}
