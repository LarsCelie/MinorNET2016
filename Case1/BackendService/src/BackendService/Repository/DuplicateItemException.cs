using System;

namespace BackendService.Repository
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException()
        {
        }

        public DuplicateItemException(string message) : base(message)
        {
        }

        public DuplicateItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}