using HotelBookingSystemApplication.Contexts;
using HotelBookingSystemApplication.Interfaces;
using HotelBookingSystemApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystemApplication.Repositories
{
    public class RoomRepository : IRepository<int, Room>
    {
        private readonly BookingContext _context;

        public RoomRepository(BookingContext context)
        {
            _context = context;
        }
        public Room Add(Room entity)
        {
            _context.Rooms.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Room Delete(int key)
        {
            var room = GetById(key);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
                return room;
            }
            return null;
        }

        public IList<Room> GetAll()
        {
            if (_context.Rooms.Count() == 0)
                return null;
            return _context.Rooms.ToList();
        }

        public Room GetById(int id)
        {
            var room = _context.Rooms.SingleOrDefault(r => r.roomId == id);
            return room;
        }

        public Room Update(Room entity)
        {
            var room = GetById(entity.roomId);
            if (room != null)
            {
                _context.Entry<Room>(room).State = EntityState.Modified;
                _context.SaveChanges();
                return room;
            }
            return null;
        }
    }
}
