
using System;
using iPayment.Core.AppEntry.Data.Model;

namespace iPayment.Core.AppEntry.Data.Interfaces
{
    public interface IApplicationFormDataStore
    {
        ApplicationFormDataModel CreateApplicationForm();
        bool AddOrUpdateGeneralInformation(Guid applicationId, GeneralInformationDataModel generalInfoDataModel);
        GeneralInformationDataModel GetGeneralInformation(Guid applicationId);
        void RemoveGeneralInformation(Guid applicationId);
        ApplicationFormDataModel GetApplicationForm(Guid applicationId);
    }
}