using System;
using System.Data.Entity.Migrations;
using iPayment.Core.AppEntry.Data.Exceptions;
using iPayment.Core.AppEntry.Data.Extensions;
using iPayment.Core.AppEntry.Data.Model;

namespace iPayment.Core.AppEntry.Data.Interactors
{
    public class GeneralInformationStoreInteractor
    {     
        public static bool AddOrUpdateGeneralInformation(Guid applicationId, GeneralInformationDataModel generalInfoDataModel)
        {
            generalInfoDataModel.ApplicationFormKey= ApplicationFormStoreInteractor.GetApplicationFormKey(applicationId);
            using (var db = new ApplicationFormContext())
                db.SaveChanges<GeneralInformationDataModel>(() =>
                {
                    db.GeneralInformations.AddOrUpdate(generalInfoDataModel);
                    return null;
                });
            
            return true;
        }

        public static GeneralInformationDataModel GetGeneralInformation(Guid applicationId)
        {
            using (var db = new ApplicationFormContext())
                return db.GeneralInformations.FastFind(ApplicationFormStoreInteractor.GetApplicationFormKey(applicationId));
        }

        public static void RemoveGeneralInformation(Guid applicationId)
        {
            using (var db = new ApplicationFormContext())
            {
                var generalInformation = GetGeneralInformation(applicationId);
                if (generalInformation == null) throw new GeneralInformationNotFoundException();
                db.GeneralInformations.Attach(generalInformation);
                db.GeneralInformations.Remove(generalInformation);
                db.SaveChanges();
            }
        }
    }
}