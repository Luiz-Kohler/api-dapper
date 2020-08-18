using Domain.Entities;
using Domain.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Text;

namespace Domain.FluentValidators
{
    internal class UserValidator : AbstractValidator<User>
    {
        public void CustomValidate(User user)
        {
            StringBuilder message = new StringBuilder();
            IList<ValidationFailure> failures = base.Validate(user).Errors ?? new List<ValidationFailure>();

            foreach (ValidationFailure failure in failures)
            {
                message.AppendLine($"Property: {failure.PropertyName} Message: {failure.ErrorMessage}");
            }

            if (message.ToString() != "")
            {
                throw new BadRequestException(message.ToString());
            }
        }
        public UserValidator()
        {
            RuleFor(properties => properties.Name)
                .NotEmpty().WithMessage("Name must be informed")
                .Length(2, 100).WithMessage("Name must have between 1 and 100 characters");

            RuleFor(properties => properties.Nick)
                .NotEmpty().WithMessage("Nick must be informed")
                .Length(2, 100).WithMessage("Nick must have between 1 and 100 characters");
        }
    }
}
