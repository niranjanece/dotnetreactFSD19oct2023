using HotelBookingSystemApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystemApplication.Contexts
{
    public class BookingContext : DbContext 
    {
        public BookingContext(DbContextOptions options) : base(options) 
        {
            
        }
        public DbSet<Hotel> Hotels{ get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingDetail>()
           .HasOne(e => e.room)
           .WithMany()
           .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
