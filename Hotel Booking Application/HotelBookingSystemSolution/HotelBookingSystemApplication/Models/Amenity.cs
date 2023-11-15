using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystemApplication.Models
{
    public class Amenity
    {
        public int amenityId { get; set; }
        public int hotelId { get; set; }
        [ForeignKey("hotelId")]
        public Hotel Hotel { get; set;}
        public string amenity { get; set; }
    }
}
