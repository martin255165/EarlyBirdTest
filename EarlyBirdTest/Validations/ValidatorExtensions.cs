using System.Text;
using FluentValidation.Results;

namespace EarlyBirdTest.Validations
{
    public static class ValidatorExtensions
    {
        public static string GetValidationErrors(this ValidationResult validationResult)
        {
            var sb = new StringBuilder();
            foreach (var error in validationResult.Errors)
            {
                sb.AppendLine(error.ErrorMessage);
            }

            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }
    }
}
