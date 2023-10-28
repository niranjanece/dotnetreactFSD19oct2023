using System.Runtime.Serialization;

namespace ClinicBLLibrary
{
    [Serializable]
    public class NoDoctorAvailableException : Exception
    {
        string message;
        public NoDoctorAvailableException()
        {
            message = "No doctors are available currently";
        }
        public override string Message => message;

    }
}