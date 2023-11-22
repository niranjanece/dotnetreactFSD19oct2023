using HotelBookingSystemApplication.Contexts;
using HotelBookingSystemApplication.Interfaces;
using HotelBookingSystemApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystemApplication.Repositories
{
    public class AmenityRepository : IRepository<int, Amenity>
    {
        private readonly BookingContext _context;

        public AmenityRepository(BookingContext context)
        {
            _context = context; 
        }
        public Amenity Add(Amenity entity)
        {
            _context.Amenities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Amenity Delete(int key)
        {
            var amenity = GetById(key);
            if(amenity != null) {
                _context.Amenities.Remove(amenity);
                _context.SaveChanges();
                return amenity;
            }
            return null;
        }

        public IList<Amenity> GetAll()
        {
            if(_context.Amenities.Count() == null)
            {
                return null;
            }
            return _context.Amenities.ToList();
        }

        public Amenity GetById(int id)
        {
            var result = _context.Amenities.FirstOrDefault(a => a.amenityId == id);
            return result;
        }

        public Amenity Update(Amenity entity)
        {
            var amenity = GetById(entity.amenityId);
            if( amenity != null )
            {
                _context.Entry<Amenity>(amenity).State = EntityState.Modified;
                _context.SaveChanges();
                return amenity;
            }
            return null;
        }
    }
}
