namespace CarRentalWebApp.Models
{
    public partial class Carrental
    {
        public Carrental()
        {
            Bookings = new HashSet<Booking>();
            Cars = new HashSet<Car>();
        }

        public string Carrentalid { get; set; } = null!;
        public string? Carrentalcompanyname { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
