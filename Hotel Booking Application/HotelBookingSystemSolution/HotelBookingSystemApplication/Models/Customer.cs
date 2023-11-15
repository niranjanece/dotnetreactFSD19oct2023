using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystemApplication.Models
{
    public class Customer
    {
        [Key]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
        public int bookingId { get; set; }
        [ForeignKey("bookingId")]
        public BookingDetail bookingDetail { get; set; }

    }
}
