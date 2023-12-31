﻿using CarRentalWebApp.Models;

namespace CarRentalWebApp.Repositories
{
    public interface ICarRentalRepository
    {
        Task<IEnumerable<Carrental>> GetAllAsync();
        Task<Carrental?> GetByIdAsync(string carRentalId);
        Task AddAsync(Carrental carRental);
        Task UpdateAsync(Carrental carRental,string id);
        Task DeleteAsync(string carRentalId);
    }
}
