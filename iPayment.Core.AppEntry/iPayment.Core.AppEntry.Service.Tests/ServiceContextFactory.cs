using System;
using iPayment.Core.AppEntry.Data.Repositories;
using iPayment.Core.AppEntry.Domain;
using iPayment.Core.AppEntry.Domain.Tests;
using iPayment.Core.AppEntry.Service.Context;

namespace iPayment.Core.AppEntry.Service.Tests
{
    public static class ServiceContextFactory
    {
        public static ApplicationServiceContext GetMockApplicationServiceContext()
        {
            var repository = new MockApplicationFormRepository();
            var applicationForm = MockApplicationForm();
            repository.CreateApplicationForm(applicationForm);
            return new ApplicationServiceContext(repository, applicationForm);
        }

        public static ApplicationServiceContext GetMockApplicationServiceContextWithGeneralInformation()
        {
            var context = GetMockApplicationServiceContext();
            context.ApplicationForm.GeneralInformation =
                MerchantGeneralInformationFactory.CreateMerchantGeneralInformation();
            return context;
        }

        private static ApplicationForm MockApplicationForm()
        {
            var applicationForm = new ApplicationForm {ApplicationId = Guid.NewGuid()};
            return applicationForm;
        }
    }
}