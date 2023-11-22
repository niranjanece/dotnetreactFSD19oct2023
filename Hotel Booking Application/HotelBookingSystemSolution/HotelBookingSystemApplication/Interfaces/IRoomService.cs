using HotelBookingSystemApplication.Models;
using HotelBookingSystemApplication.Models.DTOs;

namespace HotelBookingSystemApplication.Interfaces
{
    public interface IRoomService
    {
        RoomDTO AddRoom(RoomDTO roomDTO);
        bool RemoveRoom(int id);
        List<Room> GetRoom(int id);
        RoomDTO UpdateRoom(int id,RoomDTO roomDTO);
    }
}
