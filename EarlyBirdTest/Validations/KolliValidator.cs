using EarlyBirdTest.DAL.Models;
using FluentValidation;

namespace EarlyBirdTest.Validations
{
    public class KolliValidator : AbstractValidator<Kolli>
    {
        public KolliValidator() 
        {
            RuleFor(kolli => kolli.Width)
                .LessThanOrEqualTo(Kolli.MaxWidth)
                .WithMessage($"A kolli can only be {Kolli.MaxWidth} cm wide.");
            RuleFor(kolli => kolli.Height)
                .LessThanOrEqualTo(Kolli.MaxHeight)
                .WithMessage($"A kolli can only be {Kolli.MaxHeight} cm high.");
            RuleFor(kolli => kolli.Length)
                .LessThanOrEqualTo(Kolli.MaxLength)
                .WithMessage($"A kolli can only be {Kolli.MaxLength} cm long.");
            RuleFor(kolli => kolli.Weight)
                .LessThanOrEqualTo(Kolli.MaxWeight)
                .WithMessage($"A kolli can only weigh {Kolli.MaxWeight} grams.");
        }
    }
}
