using FluentValidation;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain.Validators
{
    public class MerchantGeneralInformationValidator : AbstractValidator<IMerchantGeneralInformation>
    {        
        public MerchantGeneralInformationValidator()
        {
            ValidateFirstNameAndLastName();

            ValidateDoingBusinessAsAndLegalBusinessName();

            ValidateFederalTaxId();
            
            ValidateBusinessPhone();

            ValidateCustomerServicePhone();

            ValidateBusinessAddressAndMailingAddress();

            ValidateNumberOfBusinessLocations();

            ValidateBusinessEmailAddress();                                                
        }

        private void ValidateBusinessEmailAddress()
        {
            RuleFor(merchantInfo => merchantInfo.BusinessEmail)
                .EmailAddress()
                .WithMessage("Business Email address has to be a valid email address.");
        }

        private void ValidateNumberOfBusinessLocations()
        {
            RuleFor(merchantInfo => merchantInfo.NumberOfLocations)
                .InclusiveBetween(0, 99999)
                .WithMessage("Number of locations has to be a valid number between 0 and 99999.");
        }

        private void ValidateBusinessAddressAndMailingAddress()
        {
            RuleFor(merchantInfo => merchantInfo.IsMailingAddressSameAsBusinessAddress)
                .Must((merchantInfo, isMailingAddressSameAsBusinessAddress) => SwapAddresses(merchantInfo));

            ValidateBusinessAddress();

            ValidateMailingAddress();
        }

        private void ValidateMailingAddress()
        {
            RuleFor(merchantInfo => merchantInfo.MailingAddress)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("Mailing address is required.")
                .SetValidator(new AddressValidator());
        }

        private void ValidateBusinessAddress()
        {
            RuleFor(merchantInfo => merchantInfo.BusinessAddress)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("Business address is required.")
                .SetValidator(new AddressValidator());
        }

        private void ValidateCustomerServicePhone()
        {
            RuleFor(merchantInfo => merchantInfo.CustomerServicePhone)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("Customer service phone number is required.")
                .SetValidator(new PhoneValidator());
        }

        private void ValidateBusinessPhone()
        {
            RuleFor(merchantInfo => merchantInfo.BusinessPhone)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("Business phone number is required.")
                .SetValidator(new PhoneValidator());
        }

        private void ValidateFederalTaxId()
        {
            RuleFor(merchantInfo => merchantInfo.FederalTaxID)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("Federal Tax Id is required.")
                .SetValidator(new FederalTaxIdValidator());
        }

        private void ValidateDoingBusinessAsAndLegalBusinessName()
        {
            RuleFor(merchantInfo => merchantInfo.IsDoingBusinessAsNameSameAsLegalBusinessName)
                .Must((merchantInfo, isDoingBusinessAsNameSameAsLegalBusinessName) => SwapBusinessNames(merchantInfo));

            ValidateDoingBusinessAs();

            ValidateLegalBusinessName();
        }

        private void ValidateLegalBusinessName()
        {
            RuleFor(merchantInfo => merchantInfo.LegalBusinessName)
                .NotEmpty()
                .WithMessage("Legal Business Name is required.");
        }

        private void ValidateDoingBusinessAs()
        {
            RuleFor(merchantInfo => merchantInfo.DoingBusinessAsName)
                .NotEmpty()
                .WithMessage("Doing Business As Name is required.");
        }

        private void ValidateFirstNameAndLastName()
        {
            RuleFor(merchantInfo => merchantInfo.ContactFirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(merchantInfo => merchantInfo.ContactLastName).NotEmpty().WithMessage("Last Name is required.");
        }

        private static bool SwapAddresses(IMerchantGeneralInformation merchant)
        {
            if (!merchant.IsMailingAddressSameAsBusinessAddress) return true;

            if (merchant.MailingAddress != null)
                merchant.BusinessAddress = merchant.MailingAddress;

            if (merchant.BusinessAddress != null)
                merchant.MailingAddress = merchant.BusinessAddress;
            return true;
        }

        private static bool SwapBusinessNames(IMerchantGeneralInformation merchant)
        {
            if (!merchant.IsDoingBusinessAsNameSameAsLegalBusinessName) return true;

            if (!string.IsNullOrEmpty(merchant.DoingBusinessAsName))
                merchant.LegalBusinessName = merchant.DoingBusinessAsName;

            if (!string.IsNullOrEmpty(merchant.LegalBusinessName))
                merchant.DoingBusinessAsName = merchant.LegalBusinessName;

            return true;
        }           
    }
}