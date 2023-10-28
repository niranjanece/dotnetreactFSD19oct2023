using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub
{
    internal class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public string Specialization { get; set; }
        public long PhoneNumber { get; set; }
        public double Rating { get; set; }
        
        public Doctor()
        {
            Id = 0;

        }
        public Doctor(int id, string name, int experience, string specialization, double rating, long phoneNumber)
        {
            Id = id;
            Name = name;
            Experience = experience; 
            Specialization = specialization;
            Rating = rating;    
            PhoneNumber = phoneNumber;
        }
        public override string ToString()
        {
            return $" Doctor Id : {Id}\n Doctor Name : {Name}\n Experience : {Experience}\n Specialization : {Specialization}\n " +
                $" PhoneNumber : {PhoneNumber}\n Rating : {Rating}";
        }
    }
}
