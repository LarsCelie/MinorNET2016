using System;

namespace FrontEnd.Exceptions
{
    public class IllegalFormatException : Exception
    {
        public IllegalFormatException()
        {
        }

        public IllegalFormatException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        public IllegalFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}