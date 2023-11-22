using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystemApplication.Models.DTOs
{
    public class HotelDTO
    {
        public string Email { get; set; }
       
        public string hotelName { get; set; }
        public string city { get; set; }
        public string location { get; set; }
        public string Phone { get; set; }
    }
}
