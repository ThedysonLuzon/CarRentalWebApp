namespace CarRentalWebApp.Models
{
    public partial class Booking
    {
        public int bookingid { get; set; }
        public string? carid { get; set; }
        public string? carrentalcompanyid { get; set; }
        public string? customername { get; set; }
        public int? numberofpeople { get; set; }
        public int? luggagespace { get; set; }
        public bool? insuranceNeeded { get; set; }
        public DateTime? bookingdate { get; set; }

        public virtual Car? car { get; set; }
        public virtual Carrental? carrentalcompany { get; set; }
    }
}
