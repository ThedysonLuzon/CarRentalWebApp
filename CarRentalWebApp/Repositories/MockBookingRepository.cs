using CarRentalWebApp.Models;
using CarRentalWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalWebApp.MockRepositories
{
    public class MockBookingRepository : IBookingRepository
    {
        private readonly List<Booking> _bookingList;

        public MockBookingRepository()
        {
            // Only initialize with dummy data if _bookingList is empty or null
            if (_bookingList == null || !_bookingList.Any())
            {
                _bookingList = new List<Booking>
                {
                    new Booking { Bookingid = 1, Customername = "John Doe", Numberofpeople = 4, Bookingdate = DateTime.Now.AddDays(-10), InsuranceNeeded = true },
                    new Booking { Bookingid = 2, Customername = "Jane Smith", Numberofpeople = 2, Bookingdate = DateTime.Now.AddDays(-5), InsuranceNeeded = false },
                    new Booking { Bookingid = 3, Customername = "Alice Johnson", Numberofpeople = 5, Bookingdate = DateTime.Now.AddDays(-20), InsuranceNeeded = true },
                    new Booking { Bookingid = 4, Customername = "Bob Brown", Numberofpeople = 1, Bookingdate = DateTime.Now.AddDays(-15), InsuranceNeeded = false },
                };
            }
        }

        public Task<IEnumerable<Booking>> GetAllAsync()
        {
            // Return all bookings
            return Task.FromResult<IEnumerable<Booking>>(_bookingList);
        }

        public Task<Booking> GetByIdAsync(int bookingId)
        {
            var booking = _bookingList.FirstOrDefault(b => b.Bookingid == bookingId);
            if (booking == null)
            {
                throw new KeyNotFoundException("Booking not found.");
            }
            return Task.FromResult(booking);
        }

        public Task AddAsync(Booking booking)
        {
            // Add a new booking
            booking.Bookingid = _bookingList.Max(b => b.Bookingid) + 1; // Generate a new ID
            _bookingList.Add(booking);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(int bookingId, Booking booking)
        {
            // Update a booking
            var bookingToUpdate = _bookingList.FirstOrDefault(b => b.Bookingid == bookingId);
            if (bookingToUpdate != null)
            {
                // Update properties as needed
                bookingToUpdate.Customername = booking.Customername;
                bookingToUpdate.Numberofpeople = booking.Numberofpeople;
                bookingToUpdate.Bookingdate = booking.Bookingdate;
                bookingToUpdate.InsuranceNeeded = booking.InsuranceNeeded;
                // etc.
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int bookingId)
        {
            // Delete a booking
            var bookingToDelete = _bookingList.FirstOrDefault(b => b.Bookingid == bookingId);
            if (bookingToDelete != null)
            {
                _bookingList.Remove(bookingToDelete);
            }
            return Task.CompletedTask;
        }
    }
}
