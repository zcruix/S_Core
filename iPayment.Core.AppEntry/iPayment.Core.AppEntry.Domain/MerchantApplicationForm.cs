using System.Collections.Generic;
using System.Linq;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain
{
    public class MerchantApplicationForm : IMerchantApplicationForm
    {
        public MerchantApplicationForm(List<IError> errorContext = null)
        {
            ErrorContext = errorContext ?? new List<IError>();    
        }

        public string MerchantID { get; set; }
        public IMerchantGeneralInformation MerchantGeneralInformation { get; set; }
        public IPrincipalInformation PrincipalInformation { get; set; }
        public IEquipmentInformation Equipment { get; set; }
        
        public bool IsValid()
        {
            return !ErrorContext.Any();
        }

        public List<IError> ErrorContext { get; set; }
    }
}