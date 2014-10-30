using System;

namespace iPayment.Core.AppEntry.Data.Model
{
    public class EntityBase
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }        
    }
}