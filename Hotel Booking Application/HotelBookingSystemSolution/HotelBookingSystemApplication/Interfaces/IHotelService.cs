using HotelBookingSystemApplication.Models;
using HotelBookingSystemApplication.Models.DTOs;

namespace HotelBookingSystemApplication.Interfaces
{
    public interface IHotelService
    {
        HotelDTO AddHotel(HotelDTO hotelDTO);
        HotelDTO UpdateHotel(int id,HotelDTO hotelDTO);
        bool DeleteHotel(int id);   
        List<Hotel> GetHotel();
    }
}
