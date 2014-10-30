using System.ComponentModel.DataAnnotations.Schema;

namespace iPayment.Core.AppEntry.Data.Model
{
    public class ApplicationFormSectionBase : EntityBase
    {
        public int ApplicationFormKey { get; set; }

        [ForeignKey("ApplicationFormKey")]
        public virtual ApplicationFormDataModel ApplicationForm { get; set; }
    }
}