namespace CarRentalWebApp.Models
{
    public partial class Carrental
    {
        public Carrental()
        {
            Bookings = new HashSet<Booking>();
            Cars = new HashSet<Car>();
        }

        public string carrentalid { get; set; } = null!;
        public string? carrentalcompanyname { get; set; }
        public string? location { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
