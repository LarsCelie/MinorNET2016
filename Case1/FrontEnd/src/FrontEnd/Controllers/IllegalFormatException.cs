using System;

namespace Controllers
{
    public class IllegalFormatException : Exception
    {
        public IllegalFormatException()
        {
        }

        public IllegalFormatException(string message) : base(message)
        {
        }

        public IllegalFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public string ErrorCode { get; set; }
        public string ErrorName { get; set; }
    }
}