using System;

namespace iPayment.Core.AppEntry.Domain.Interfaces
{
    public interface IPrincipal
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string SocialSecurityNumber { get; set; }
        string Title { get; set; }
        IResidence Residence { get; set; }
        
        bool IsResidentialAddressSameAsBusinessAddress { get; set; }
        bool IsHomePhoneSameAsBusinessPhone { get; set; }        
        bool IsAuthorizedToSign { get; set; }

        IDriverLicense DriverLicense { get; set; }
        DateTime DateOfBirth { get; set; }
        IPhone HomePhone { get; set; }        
    }
}