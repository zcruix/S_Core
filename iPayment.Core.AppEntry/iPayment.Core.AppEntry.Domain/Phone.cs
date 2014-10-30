using System.Collections.Generic;
using FluentValidation;
using iPayment.Core.AppEntry.Domain.Enums;
using iPayment.Core.AppEntry.Domain.Extensions;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Domain.Validators;

namespace iPayment.Core.AppEntry.Domain
{
    public class Phone : IPhone
    {
        private readonly AbstractValidator<IPhone> _phoneValidator;

        public Phone(AbstractValidator<IPhone> phoneValidator = null)
        {
            _phoneValidator = phoneValidator ?? new PhoneValidator();            
        }

        public string Number { get; set; }
        public PhoneType PhoneType { get; set; }
        public List<IError> Errors { get; set; }

        public bool IsValid()
        {
            Errors = new List<IError>();
            var vr = _phoneValidator.Validate(this);
            return vr.IsValid(Errors);
        }
    }
}