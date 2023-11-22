using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystemApplication.Models
{
    public class Room
    {
        public int roomId { get; set; }
        public int hotelId { get; set; }
        [ForeignKey("hotelId")]
        public Hotel hotel{ get; set; }
        public string Picture { get; set; }
        public int availableRoom { get; set; }
        public string roomType { get; set; }
        public float price { get; set; }

        public int capacity { get; set; }

    }
}
