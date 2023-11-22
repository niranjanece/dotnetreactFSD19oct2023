using HotelBookingSystemApplication.Interfaces;
using HotelBookingSystemApplication.Models;
using HotelBookingSystemApplication.Models.DTOs;

namespace HotelBookingSystemApplication.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<int, Hotel> _hotelRepository;

        public HotelService(IRepository<int, Hotel> hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public HotelDTO AddHotel(HotelDTO hotelDTO)
        {
            Hotel hotel = new Hotel()
            {
                hotelName = hotelDTO.hotelName,
                Email = hotelDTO.Email,
                city = hotelDTO.city,
                location = hotelDTO.location,
                Phone = hotelDTO.Phone
            };
            var result = _hotelRepository.Add(hotel);
            if(result != null)
            {
                return hotelDTO;
            }
            return null;
        }

        public bool DeleteHotel(int id)
        {
            var result = (_hotelRepository.Delete(id));
            if(result != null)
            {
                return true;
            }
            return false;
        }

        public List<Hotel> GetHotel()
        {
            var hotel = _hotelRepository.GetAll();
            if(hotel != null)
            {
                return hotel.ToList();
            }
            return null;
        }

        public HotelDTO UpdateHotel(int id,HotelDTO hotelDTO)
        {
            var hotel = _hotelRepository.GetById(id);
            if(hotel != null) 
            {
                hotel.hotelName = hotelDTO.hotelName;
                hotel.Email = hotelDTO.Email;
                hotel.city = hotelDTO.city;
                hotel.location = hotelDTO.location;
                hotel.Phone = hotelDTO.Phone;
                var result = _hotelRepository.Update(hotel);
                return hotelDTO;
            }
            return null;
        }
    }
}
