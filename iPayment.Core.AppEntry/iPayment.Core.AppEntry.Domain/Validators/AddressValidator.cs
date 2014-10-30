using System.Text.RegularExpressions;
using FluentValidation;
using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain.Validators
{
    public class AddressValidator : AbstractValidator<IAddress>
    {
        const string USZipCodeRegEx = @"^\d{5}(?:-\d{4})?$";

        public AddressValidator()
        {
            RuleFor(address => address.AddressType).NotEqual(AddressType.UnKnown).WithMessage(@"AddressType cannot be UnKnown.");

            RuleFor(address => address.AddressLine1).NotEmpty().WithMessage(@"AddressLine1 cannot be empty or null.");                        
            RuleFor(address => address.City).NotEmpty().WithMessage(@"City cannot be empty or null.");
            RuleFor(address => address.State).NotEmpty().WithMessage(@"State cannot be empty or null.");
            RuleFor(address => address.Zipcode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage(@"Zipcode cannot be empty or null.")
                .Must(z => z.Length <= 10)
                .WithMessage(@"Zipcode cannot be more than 10 characters.")
                .Matches(new Regex(USZipCodeRegEx))
                .WithMessage(@"Zipcode is not in the correct format. For example ... 99999 or 99999-111.");
        }
    }
}