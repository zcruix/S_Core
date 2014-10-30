using System;
using iPayment.Core.AppEntry.Data.Interactors;
using iPayment.Core.AppEntry.Data.Interfaces;
using iPayment.Core.AppEntry.Data.Model;

namespace iPayment.Core.AppEntry.Data.Store
{
    //TODO: Wire up all the audit information all thru the layers
    public class ApplicationFormDataStore : IApplicationFormDataStore
    {     
        public ApplicationFormDataModel GetApplicationForm(Guid applicationId)
        {
            return ApplicationFormStoreInteractor.GetApplicationForm(applicationId);
        }

        public ApplicationFormDataModel CreateApplicationForm()
        {
            return ApplicationFormStoreInteractor.CreateApplicationForm();
        }

        public bool AddOrUpdateGeneralInformation(Guid applicationId, GeneralInformationDataModel generalInfoDataModel)
        {
            return GeneralInformationStoreInteractor.AddOrUpdateGeneralInformation(applicationId, generalInfoDataModel);
        }

        public GeneralInformationDataModel GetGeneralInformation(Guid applicationId)
        {
            return GeneralInformationStoreInteractor.GetGeneralInformation(applicationId);
        }

        public void RemoveGeneralInformation(Guid applicationId)
        {
            GeneralInformationStoreInteractor.RemoveGeneralInformation(applicationId);
        }
    }
}