﻿using ClinicModelLibrary;
using ClinicDALibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace ClinicBLLibrary
{
    public class DoctorService : IDoctorService
    {
        IRepository repository;
        public DoctorService()
        {
            repository = new DoctorRepository();
        }
        public Doctor AddDoctor(Doctor doctor)
        {
            var result = repository.Add(doctor);
            if (result != null)
                return result;
            throw new NotAddedException();
        }

        public Doctor Delete(int id)
        {
            var doctor = GetDoctor(id);
            if(doctor != null)
            {
                repository.Delete(id);
                return doctor;
            }
            throw new NoSuchDoctorException();
        }

        public Doctor GetDoctor(int id)
        {
            var result = repository.GetById(id);
            return result == null ? throw new NoSuchDoctorException() : result; 
        }

        public List<Doctor> GetDoctors()
        {
            var doctors = repository.GetAll();
            if (doctors.Count != 0)
                return doctors;
            throw new NoDoctorAvailableException();
        }

        public Doctor UpdateDoctorPhoneNumber(int id, long phoneNumber)
        {
            var doctor = GetDoctor(id);
            if(doctor != null)
            {
                doctor.PhoneNumber = phoneNumber;
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }

        public Doctor UpdateExperience(int id, int experience)
        {
            var doctor = GetDoctor(id);
            if(doctor != null)
            {
                doctor.Experience = experience;
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }
    }
}

