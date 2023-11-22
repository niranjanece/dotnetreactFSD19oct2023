using HotelBookingSystemApplication.Contexts;
using HotelBookingSystemApplication.Interfaces;
using HotelBookingSystemApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystemApplication.Repositories
{
    public class BookingRepository : IRepository<int, BookingDetail>
    {
        private readonly BookingContext _context;

        public BookingRepository(BookingContext context)
        {
            _context = context;
        }
        public BookingDetail Add(BookingDetail entity)
        {
            _context.BookingDetails.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public BookingDetail Delete(int key)
        {
            var booking = GetById(key);
            if(booking != null)
            {
                _context.BookingDetails.Remove(booking);
                _context.SaveChanges();
                return booking;
            }
            return null;
        }

        public IList<BookingDetail> GetAll()
        {
            if(_context.BookingDetails.Count() == 0)
            {
                return null;
            }
            return _context.BookingDetails.ToList();
        }

        public BookingDetail GetById(int id)
        {
            var result = _context.BookingDetails.SingleOrDefault(b => b.bookingId == id);
            return result;
        }

        public BookingDetail Update(BookingDetail entity)
        {
            var booking = GetById(entity.bookingId);
            if( booking != null )
            {
                _context.Entry<BookingDetail>(booking).State = EntityState.Modified;
                _context.SaveChanges();
                return booking;
            }
            return entity;
        }
    }
}
