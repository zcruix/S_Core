using System.Collections.Generic;
using FluentValidation;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Domain.Validators;
using iPayment.Core.AppEntry.Domain.Extensions;

namespace iPayment.Core.AppEntry.Domain
{
    public class MerchantGeneralInformation : IMerchantGeneralInformation
    {
        private readonly AbstractValidator<IMerchantGeneralInformation> _merchantGeneralInformationValidator;

        public MerchantGeneralInformation(AbstractValidator<IMerchantGeneralInformation> merchantGeneralInformationValidator = null)
        {
            _merchantGeneralInformationValidator = merchantGeneralInformationValidator ?? new MerchantGeneralInformationValidator();            
        }

        public string DoingBusinessAsName { get; set; }
        public string LegalBusinessName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessWebsiteUrl { get; set; }
        public string BusinessOperatingHours { get; set; }

        public int NumberOfLocations { get; set; }

        public IPhone BusinessPhone { get; set; }
        public IPhone BusinessFax { get; set; }
        public IPhone CustomerServicePhone { get; set; }

        public IAddress BusinessAddress { get; set; }
        public IAddress MailingAddress { get; set; }

        public IContinuousResidence ContinuousResidenceAtTheBusinessAddress { get; set; }
        public IFederalTaxId FederalTaxID { get; set; }

        public bool IsMailingAddressSameAsBusinessAddress { get; set; }
        public bool IsDoingBusinessAsNameSameAsLegalBusinessName { get; set; }

        public List<IError> ErrorContext { get; set; }

        public bool IsValid()
        {
            ErrorContext = new List<IError>();
            var vr = _merchantGeneralInformationValidator.Validate(this);
            return vr.IsValid(ErrorContext);
        }        
    }
}