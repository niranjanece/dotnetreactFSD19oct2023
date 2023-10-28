using System.Runtime.Serialization;

namespace FirstApp
{
    [Serializable]
    internal class unwantedException : Exception
    {
        string message;
        public unwantedException()
        {
            message = "super";
        }

        public override string Message => message;
    }
}