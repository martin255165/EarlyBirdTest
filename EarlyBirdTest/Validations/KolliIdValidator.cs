using FluentValidation;

namespace EarlyBirdTest.Validations
{
    public class KolliIdValidator : AbstractValidator<string>
    {
        private const string KolliIdStartChars = "999";
        private const int KolliIdLength = 18;

        public KolliIdValidator()
        {
            RuleFor(kolliId => kolliId).Length(KolliIdLength).WithMessage($"KolliId must be exactly {KolliIdLength} characters long.");
            RuleFor(kolliId => kolliId)
                .Must(kolliId => kolliId.All(char.IsDigit))
                .WithMessage("KolliId must be numeric.");
            RuleFor(kolliId => kolliId)
                .Must(kolliId => kolliId.Substring(0, 3) == KolliIdStartChars)
                .WithMessage($"KolliId must start with {KolliIdStartChars}.");
        }
    }
}
