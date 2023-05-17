using FluentValidation.Results;

namespace LeaveManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {

    }

    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = new();
        foreach (var errors in validationResult.Errors)
        {
            ValidationErrors.Add(errors.ErrorMessage);
        }
    }

    public List<string> ValidationErrors { get; set; }
}
