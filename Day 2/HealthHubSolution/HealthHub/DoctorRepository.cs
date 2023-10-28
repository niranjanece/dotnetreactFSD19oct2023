using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub
{
    internal class DoctorRepository
    {
        List<Doctor> doctors;

        public DoctorRepository()
        {
            doctors = new List<Doctor>();
        }
        int GetId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors[doctors.Count - 1].Id;
            return ++id;
        }
        public void DoctorDetails(Doctor doctor)
        {
            Console.WriteLine("Please enter the doctor name");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Please enter the doctor experience");
            doctor.Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the doctor specialization");
            doctor.Specialization = Console.ReadLine();
            Console.WriteLine("Please enter the doctor phone number");
            doctor.PhoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Please enter the doctor rating");
            doctor.Rating = Convert.ToDouble(Console.ReadLine());
            
        }
        public Doctor Add()
        {
            int id = GetId();
            Doctor doctor = new Doctor();
            doctor.Id = id;
            DoctorDetails(doctor);
            doctors.Add(doctor);
            Console.WriteLine("Added successfully");
            return doctor;
        }
        public Doctor GetDoctorById(int id)
        {
            for(int i=0;i<doctors.Count;i++)
            {
                if (doctors[i].Id == id )
                    return doctors[i];
            }
            return null;
        }
        public Doctor update(int id, Doctor doctor, String choice)
        {
            Doctor getDoctor = GetDoctorById(id);
            if(getDoctor != null)
            {
                if(choice == "phoneNumber")
                {
                    getDoctor.PhoneNumber = doctor.PhoneNumber;
                    return getDoctor;
                }
                else if(choice == "experience")
                {
                    if (getDoctor.Experience < doctor.Experience) {
                        getDoctor.Experience = doctor.Experience;
                        return getDoctor;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Information");
                        return null;
                    }
                        
                }
                else
                    Console.WriteLine("Invalid data");
            }
            Console.WriteLine("Cannot update");
            return null;
        }
        public Doctor delete(int id)
        {
            Doctor getDoctor = GetDoctorById(id);
            if(getDoctor != null)
            {
                doctors.Remove(getDoctor);
                return getDoctor;
            }
            return null;
        }
        public List<Doctor> GetDoctors()
        {
            return doctors;
        }
    }
}
