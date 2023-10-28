using ClinicModelLibrary;
using ClinicBLLibrary;
using ClinicDALibrary;
using System.Numerics;

namespace ClinicApp
{
    internal class Program
    {
        IDoctorService doctorService;
        public Program()
        {
            doctorService = new DoctorService();
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
                        AddDoctor();
                        break;
                    case 2:
                        UpdatePhoneNumber();
                        break;
                    case 3:
                        UpdateExperienc();
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
            try
            {
                Console.WriteLine("Information of the doctors");
                var doctors = doctorService.GetDoctors();
                foreach (var doctor in doctors)
                {
                    Console.WriteLine(doctor);
                }
            }
            catch(NoDoctorAvailableException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        private void AddDoctor()
        {
            try
            {
                Doctor doctor = TakeDoctorDetails();
                var result = doctorService.AddDoctor(doctor);
                if(result != null)
                {
                    Console.WriteLine("Doctor has added");
                }
            }
            catch(FormatException e) {
                Console.WriteLine(e.Message);
            }
            catch(NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        Doctor TakeDoctorDetails()
        {
            Doctor doctor = new Doctor();
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
            return doctor;
        }
        int GetProductIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the doctor id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        private void UpdatePhoneNumber()
        {
            var id = GetProductIdFromUser();
            Console.WriteLine("Please enter the new phone number");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.PhoneNumber = phoneNumber;
            doctor.Id = id;
            try
            {
                var result = doctorService.UpdateDoctorPhoneNumber(id, phoneNumber);
                if(result != null)
                {
                    Console.WriteLine("Update success");
                }
            }
            catch(NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void UpdateExperienc() {
            var id = GetProductIdFromUser();
            Console.WriteLine("Please enter the current experience");
            int experience = Convert.ToInt32(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Experience = experience;
            doctor.Id = id;
            try
            {
                var result = doctorService.UpdateExperience(id, experience);
                if(result != null)
                {
                    Console.WriteLine("Update success");
                }
            }
            catch(NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void deleteDoctorInformation()
        {
            try
            {
                int id = GetProductIdFromUser();
                if(doctorService.Delete(id) != null)
                    Console.WriteLine("Doctor information deleted");
            }
            catch(NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HealthHub");
            Program home = new Program();
            home.StartAdminFunctionalities();
        }
    }
}