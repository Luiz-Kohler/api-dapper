using System;

namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public string ErrorMessage { get; protected set; }

        public NotFoundException(string errorMessage) : base()
        {
            ErrorMessage = errorMessage;
        }
    }
}
