namespace CarRentalWebApp.Models
{
    public partial class Booking
    {
        public int Bookingid { get; set; }
        public string? Carid { get; set; }
        public string? Carrentalcompanyid { get; set; }
        public string? Customername { get; set; }
        public int? Numberofpeople { get; set; }
        public int? Luggagespace { get; set; }
        public bool? InsuranceNeeded { get; set; }
        public DateTime? Bookingdate { get; set; }

        public virtual Car? Car { get; set; }
        public virtual Carrental? Carrentalcompany { get; set; }
    }
}
