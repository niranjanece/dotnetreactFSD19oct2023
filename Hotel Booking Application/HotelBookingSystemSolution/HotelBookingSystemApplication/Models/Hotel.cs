using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystemApplication.Models
{
    public class Hotel
    {
        [Key]
        public int hotelId { get; set; }

        public string Email { get; set; }
        [ForeignKey("Email")]
        public User user { get; set; }
        public string hotelName { get; set; }
        public string city { get; set; }
        public string location { get; set; }
        public string Phone { get; set; }
    }
}
