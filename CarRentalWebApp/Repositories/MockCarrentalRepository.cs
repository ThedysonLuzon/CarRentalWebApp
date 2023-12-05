using CarRentalWebApp.Models;

namespace CarRentalWebApp.Repositories
{
   /* public class MockCarRentalRepository : ICarRentalRepository
    {
        private List<Carrental> _carRentals = new List<Carrental>();

        // Constructor to initialize with some mock data
        public MockCarRentalRepository()
        {
            // Initialize _carRentals with mock data
            _carRentals = new List<Carrental>
            {
                new Carrental
                {
                    Carrentalid = "1",
                    Carrentalcompanyname = "City Wheels",
                    Location = "Downtown"
                },
                new Carrental
                {
                    Carrentalid = "2",
                    Carrentalcompanyname = "Holiday Cars",
                    Location = "Airport"
                },
                new Carrental
                {
                    Carrentalid = "3",
                    Carrentalcompanyname = "Business Rides",
                    Location = "Business District"
                },
                // Add more mock car rentals as necessary
            };
        }

        public Task<IEnumerable<Carrental>> GetAllAsync()
        {
            // Return all car rentals
            return Task.FromResult<IEnumerable<Carrental>>(_carRentals);
        }

        public Task<Carrental> GetByIdAsync(string carRentalId)
        {
            // Find a single car rental by ID
            var carRental = _carRentals.FirstOrDefault(cr => cr.Carrentalid == carRentalId);
            return Task.FromResult(carRental);
        }

        public Task AddAsync(Carrental carRental)
        {
            // Add a new car rental
            _carRentals.Add(carRental);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Carrental carRental)
        {
            // Update an existing car rental
            var existingCarRental = _carRentals.FirstOrDefault(cr => cr.Carrentalid == carRental.Carrentalid);
            if (existingCarRental != null)
            {
                // Update properties here
                existingCarRental.Carrentalcompanyname = carRental.Carrentalcompanyname;
                existingCarRental.Location = carRental.Location;
                // etc.
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string carRentalId)
        {
            // Delete a car rental
            var carRentalToDelete = _carRentals.FirstOrDefault(cr => cr.Carrentalid == carRentalId);
            if (carRentalToDelete != null)
            {
                _carRentals.Remove(carRentalToDelete);
            }
            return Task.CompletedTask;
        }
    }*/


}
