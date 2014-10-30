using FluentValidation;
using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Extensions;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain.Validators
{
    public class PhoneValidator : AbstractValidator<IPhone>
    {
        public PhoneValidator()
        {
            RuleFor(phone => phone.PhoneType).NotEqual(PhoneType.UnKnown).WithMessage(@"Phone type cannot be UnKnown.");

            RuleFor(phone => phone.Number)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage(@"Phone Number cannot be empty or null.")
                .Must(pn => pn.IsNumeric())
                .WithMessage(@"Phone number cannot have non numeric characters.")
                .Length(10)
                .WithMessage(@"Phone Number has to be 10 digits in length.");

        }        
    }
}