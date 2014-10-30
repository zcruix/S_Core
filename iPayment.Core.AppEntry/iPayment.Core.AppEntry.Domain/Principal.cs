using System;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain
{
    public class Principal : IPrincipal
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string SocialSecurityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsAuthorizedToSign { get; set; }
        public IDriverLicense DriverLicense { get; set; }        
        public IResidence Residence { get; set; }
        public IPhone HomePhone { get; set; }

        public bool IsResidentialAddressSameAsBusinessAddress { get; set; }
        public bool IsHomePhoneSameAsBusinessPhone { get; set; }
    }
}