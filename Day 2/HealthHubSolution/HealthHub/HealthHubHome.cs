using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub
{
    internal class HealthHubHome
    {
        DoctorRepository doctorRepository;
        public HealthHubHome()
        {
            doctorRepository = new DoctorRepository();
        }
        void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Doctor Information");
            Console.WriteLine("2. Modify doctor phone number");
            Console.WriteLine("3. Modify doctor experience");
            Console.WriteLine("4. Delete Doctor Information");
            Console.WriteLine("5. Print all the Doctor Information");
            Console.WriteLine("0. Exit");
        }
        void StartAdminFunctionalities()
        {
            int choose;
            do
            {
                DisplayAdminMenu();
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 0:
                        Console.WriteLine("Take care of your health");
                        break;
                    case 1:
                        doctorRepository.Add();
                        break;
                    case 2:
                        modifyPhoneNumber();
                        break;
                    case 3:
                        modifyDoctorExperience();
                        break;
                    case 4:
                        deleteDoctorInformation();
                        break;
                    case 5:
                        printDoctors();
                        break;
                    default:
                        Console.WriteLine("Invalid data");
                        break;


                }
            }
            while (choose != 0);
        }
        private void printDoctors()
        {
            Console.WriteLine("Information of the doctors");
            var doctors = doctorRepository.GetDoctors();
            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor); 
            }
        }
        private void deleteDoctorInformation()
        {
            var id = GetDoctorIdFromUser();
            Doctor doctor = new Doctor();
            doctor.Id = id;
            if(doctorRepository.delete(id) != null)
                Console.WriteLine("Deleted successfully");

        }
        private void modifyDoctorExperience()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter a current experience of a doctor");
            int experience = Convert.ToInt32(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Id = id;
            doctor.Experience = experience;
            var result = doctorRepository.update(id, doctor, "experience");
            if(result != null)
                Console.WriteLine("Experience has been updated successfully");

        }

        int GetDoctorIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the Id of a doctor");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        private void modifyPhoneNumber()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter a new phone number");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Id = id;
            doctor.PhoneNumber = phoneNumber;
            var result = doctorRepository.update(id, doctor, "phoneNumber");
            if(result != null)
                Console.WriteLine("Phone number has been updated successfully");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HealthHub");
            HealthHubHome home =new HealthHubHome();
            home.StartAdminFunctionalities();
        }
    }
}
