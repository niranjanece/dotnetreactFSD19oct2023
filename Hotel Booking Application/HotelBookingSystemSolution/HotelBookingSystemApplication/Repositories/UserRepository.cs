﻿using HotelBookingSystemApplication.Contexts;
using HotelBookingSystemApplication.Interfaces;
using HotelBookingSystemApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystemApplication.Repositories
{
    public class UserRepository : IRepository<string, User>
    {
        private readonly BookingContext _context;

        public UserRepository(BookingContext context)
        {
            _context = context;
        }
        public User Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public User Delete(string key)
        {
            var user = GetById(key);
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return user;
            }
            return null;
        }

        public IList<User> GetAll()
        {
            if (_context.Users.Count() == 0)
                return null;
            return _context.Users.ToList();

        }

        public User GetById(string id)
        {
            var result = _context.Users.FirstOrDefault(u => u.Email == id);
            return result;
        }

        public User Update(User entity)
        {
            var user = GetById(entity.Email);
            if(user != null)
            {
                _context.Entry<User>(user).State = EntityState.Modified;
                _context.SaveChanges();   
                return user;
            }
            return null;
        }
    }
}
