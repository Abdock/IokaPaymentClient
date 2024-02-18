using System.ComponentModel.DataAnnotations;

namespace IokaPayment.General.Extensions;

public static class ObjectValidationExtensions
{
    public static void ThrowIfValidationFailed(this object obj)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(obj);
        if (Validator.TryValidateObject(obj, validationContext, validationResults, validateAllProperties: true)) return;
        var errorMessages = string.Join("; ", validationResults.Select(e => e.ErrorMessage));
        throw new ArgumentException($"Model validation failed: {errorMessages}");
    }
}