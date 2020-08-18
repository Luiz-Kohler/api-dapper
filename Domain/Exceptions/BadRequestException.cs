using System;

namespace Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public string ErrorMessage { get; protected set; }

        public BadRequestException(string errorMessage) : base()
        {
            ErrorMessage = errorMessage;
        }
    }
}
