namespace CarRentalWebApp.Models
{
    public class Car
    {
        public string carid { get; set; } = null!;
        public string? carrentalid { get; set; }
        public string? carmodel { get; set; }
        public decimal? insuranceamount { get; set; }
        public string? fueltype { get; set; }
        public string? mileage { get; set; }
        public int? noofdoors { get; set; }
        public decimal? rentalpriceperday { get; set; }
        public string? luggagespace { get; set; }
        public string? geartype { get; set; }
        public bool? freecancelation { get; set; }
        public string? caravailability { get; set; }
    }
}
