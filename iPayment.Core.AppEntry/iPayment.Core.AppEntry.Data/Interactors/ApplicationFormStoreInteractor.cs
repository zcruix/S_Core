using System;
using System.Linq;
using iPayment.Core.AppEntry.Data.Exceptions;
using iPayment.Core.AppEntry.Data.Extensions;
using iPayment.Core.AppEntry.Data.Factories;
using iPayment.Core.AppEntry.Data.Model;

namespace iPayment.Core.AppEntry.Data.Interactors
{
    public class ApplicationFormStoreInteractor
    {
        public static ApplicationFormDataModel GetApplicationForm(Guid applicationId)
        {
            using (var db = new ApplicationFormContext())
            {
                var applicationFormDataModel = db.ApplicationForms.SingleOrDefault(a => a.ApplicationId == applicationId);
                if (applicationFormDataModel == null) throw new ApplicationFormNotFoundException();
                return applicationFormDataModel;
            }
        }

        public static ApplicationFormDataModel CreateApplicationForm()
        {
            using (var db = new ApplicationFormContext())
                return db.SaveChanges(() => db.ApplicationForms.Add(ApplicationFormDataModelFactory.CreateApplicationFormDataModel()));
        }

        public static int GetApplicationFormKey(Guid applicationId)
        {
            return GetApplicationForm(applicationId).ApplicationFormKey;
        }
    }
}