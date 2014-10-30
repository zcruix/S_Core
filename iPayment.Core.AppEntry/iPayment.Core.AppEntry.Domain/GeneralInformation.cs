using System.Collections.Generic;
using FluentValidation;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.Domain.Validators;
using iPayment.Core.AppEntry.Domain.Extensions;

namespace iPayment.Core.AppEntry.Domain
{
    public class GeneralInformation : ObjectBase, IGeneralInformation
    {
        private readonly AbstractValidator<IGeneralInformation> _generalInformationValidator;

        public GeneralInformation(AbstractValidator<IGeneralInformation> generalInformationValidator = null)
        {
            _generalInformationValidator = generalInformationValidator ?? new GeneralInformationValidator();            
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

        public List<IError> Errors { get; set; }

        public bool IsValid()
        {
            Errors = new List<IError>();
            var vr = _generalInformationValidator.Validate(this);
            return vr.IsValid(Errors);
        }        
    }
}