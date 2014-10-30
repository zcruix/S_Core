using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iPayment.Core.AppEntry.Data.Interfaces;

namespace iPayment.Core.AppEntry.Data.Model
{
    [Table("ApplicationForms")]
    public class ApplicationFormDataModel : EntityBase, IEntityWithApplicationId
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationFormKey { get; set; }
        public Guid ApplicationId { get; set; }        
    }
}