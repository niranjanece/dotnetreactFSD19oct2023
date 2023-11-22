using HotelBookingSystemApplication.Interfaces;
using HotelBookingSystemApplication.Models;
using HotelBookingSystemApplication.Models.DTOs;

namespace HotelBookingSystemApplication.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<int, Room> _roomRepository;

        public RoomService(IRepository<int, Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public RoomDTO AddRoom(RoomDTO roomDTO)
        {
            Room room = new Room()
            {
                 hotelId = roomDTO.hotelId,
                 availableRoom = roomDTO.availableRoom,
                 capacity = roomDTO.capacity,
                 roomType = roomDTO.roomType,
                 price = roomDTO.price,
                 Picture = roomDTO.Picture
            };
            var result = _roomRepository.Add(room);
            if(result != null)
            {
                return roomDTO;
            }
            return null;
        }

        public List<Room> GetRoom(int id)
        {
            var room = _roomRepository.GetAll().Where(r => r.hotelId == id).ToList();
            if(room != null)
            {
                return room;
            }
            return null;
        }

        public bool RemoveRoom(int id)
        {
            var room = _roomRepository.Delete(id);
            if(room != null)
            {
                return true;
            }
            return false;
        }

        public RoomDTO UpdateRoom(int id, RoomDTO roomDTO)
        {
            var room = _roomRepository.GetById(id);
            if( room != null )
            {
                room.price = roomDTO.price;
                room.capacity = roomDTO.capacity;
                room.roomType = roomDTO.roomType;
                room.Picture = roomDTO.Picture;
                room.availableRoom = roomDTO.availableRoom;
                room.hotelId = roomDTO.hotelId;
                return roomDTO;
            }
            return null;
        }
    }
}
