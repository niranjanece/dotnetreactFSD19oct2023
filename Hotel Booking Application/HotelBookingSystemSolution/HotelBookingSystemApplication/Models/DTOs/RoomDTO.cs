using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystemApplication.Models.DTOs
{
    public class RoomDTO
    {
        public int hotelId { get; set; }
        public string Picture { get; set; }
        public int availableRoom { get; set; }
        public string roomType { get; set; }
        public float price { get; set; }
        public int capacity { get; set; }
    }
}
