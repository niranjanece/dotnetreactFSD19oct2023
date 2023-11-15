using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystemApplication.Models
{
    public class BookingDetail
    {
        public int bookingId { get; set; }
        public int Email { get; set; }
        [ForeignKey("Email")]
        public Customer Customer { get; set; }
        public int roomsBooked { get; set; }
        public float price { get; set; }
    }
}
