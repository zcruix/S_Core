using System.Collections.Generic;
using FluentValidation;
using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Extensions;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Domain.Validators;

namespace iPayment.Core.AppEntry.Domain
{
    public class Address : IAddress
    {
        private readonly AbstractValidator<IAddress> _addressValidator;

        public Address(AbstractValidator<IAddress> addressValidator = null)
        {
            _addressValidator = addressValidator ?? new AddressValidator();            
        }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string County { get; set; }
        public AddressType AddressType { get; set; }
        public List<IError> Errors { get; set; }

        public bool IsValid()
        {
            Errors = new List<IError>();
            var vr = _addressValidator.Validate(this);
            return vr.IsValid(Errors);
        }        
    }
}