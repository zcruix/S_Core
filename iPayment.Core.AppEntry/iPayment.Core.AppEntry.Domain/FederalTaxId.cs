using System.Collections.Generic;
using FluentValidation;
using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Extensions;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Domain.Validators;

namespace iPayment.Core.AppEntry.Domain
{
    public class FederalTaxId : IFederalTaxId
    {
        private readonly AbstractValidator<IFederalTaxId> _federalTaxIdValidator;

        public FederalTaxId(AbstractValidator<IFederalTaxId> federalTaxIdValidator = null)
        {
            _federalTaxIdValidator = federalTaxIdValidator ?? new FederalTaxIdValidator();            
        }

        public string Number { get; set; }
        public TaxIdType TaxIdType { get; set; }
        public List<IError> ErrorContext { get; set; }

        public bool IsValid()
        {
            ErrorContext = new List<IError>();
            var vr = _federalTaxIdValidator.Validate(this);
            return vr.IsValid(ErrorContext);
        }
    }
}