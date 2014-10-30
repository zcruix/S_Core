using System;
using iPayment.Core.AppEntry.Data.Model;

namespace iPayment.Core.AppEntry.Data.Factories
{
    public class ApplicationFormDataModelFactory
    {
        public static ApplicationFormDataModel CreateApplicationFormDataModel()
        {
            return new ApplicationFormDataModel {ApplicationId = Guid.NewGuid()};
        }
    }
}