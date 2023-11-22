using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystemApplication.Models.DTOs
{
    public class BookingDTO
    {
        public string Email { get; set; }
        public int roomsBooked { get; set; }
        public float price { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public string roomId { get; set; }
        public string status { get; set; }
    }
}
