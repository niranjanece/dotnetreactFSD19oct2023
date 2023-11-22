using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystemApplication.Models
{
    public class BookingDetail
    {
        [Key]
        public int bookingId { get; set; }
        public string Email { get; set; }
        [ForeignKey("Email")]
        public User User { get; set; }
        public int roomsBooked { get; set; }
        public float price { get; set; }
        public string Date { get; set; }

        public string checkIn { get; set; }

        public string checkOut { get; set; }

        public  int roomId { get; set; }
        [ForeignKey("roomId")]
        public Room room { get; set; }

        public string status { get; set; }
    }
}
