using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystemApplication.Models
{
    public class Hotel
    {
        [Key]
        public int hotelId { get; set; }
        public string hotelName { get; set; }
        public  string password { get; set; }
        public string location { get; set; }
        public int roomId { get; set; }
        [ForeignKey("roomId")]
        public Room room { get; set; }
        public int amenityId { get; set; }
        [ForeignKey("amenityId")]
        public Amenity Amenity { get; set; }

        public string picture { get; set; }
    }
}
