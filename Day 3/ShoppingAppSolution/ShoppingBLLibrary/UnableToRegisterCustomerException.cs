using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    [Serializable]
    public class UnableToRegisterCustomerException : Exception
    {
        string message;
        public UnableToRegisterCustomerException()
        {
            message = "Unable to register";
        }
        public override string Message => message;

    }
}