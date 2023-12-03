namespace CarRentalWebApp.Models
{
    public class Car
    {
        public string? CarId { get; set; }
        public string? CarRentalId { get; set; }
        public string? CarModel { get; set; }
        public decimal? InsuranceAmount { get; set; }
        public string? FuelType { get; set; }
        public string? Mileage { get; set; }
        public int? NumberOfDoors { get; set; }
        public decimal? RentalPricePerDay { get; set; }
        public string? LuggageSpace { get; set; }
        public string? GearType { get; set; }
        public bool? FreeCancellation { get; set; }
        public string? CarAvailability { get; set; }
    }
}
