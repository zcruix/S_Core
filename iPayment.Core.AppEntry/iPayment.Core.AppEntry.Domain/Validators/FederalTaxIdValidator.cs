using FluentValidation;
using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Extensions;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain.Validators
{
    public class FederalTaxIdValidator : AbstractValidator<IFederalTaxId>
    {
        public FederalTaxIdValidator()
        {
            RuleFor(taxid => taxid.TaxIdType).NotEqual(TaxIdType.UnKnown).WithMessage(@"TaxIdType cannot be UnKnown.");

            RuleFor(taxid => taxid.Number)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage(@"Tax Id Number cannot be empty or null.")
                .Must(tin => tin.IsNumeric())
                .WithMessage(@"Taxid has non numeric digits.")
                .Length(9)
                .WithMessage(@"Federal Tax Id should be exactly 9 numeric digits.");
        }
    }
}