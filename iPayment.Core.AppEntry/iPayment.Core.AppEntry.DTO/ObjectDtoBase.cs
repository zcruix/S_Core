﻿using System;
using System.Collections.Generic;

namespace iPayment.Core.AppEntry.DTO
{
    public class ObjectDtoBase
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public IEnumerable<ErrorDto> Errors { get; set;}        
    }
}