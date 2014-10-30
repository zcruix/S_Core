using System.Data.Entity;

namespace iPayment.Core.AppEntry.Data.Model
{
    public class ApplicationFormContext : DbContext
    {
        public virtual DbSet<ApplicationFormDataModel> ApplicationForms { get; set; }
        public virtual DbSet<GeneralInformationDataModel> GeneralInformations { get; set; }
    }
}