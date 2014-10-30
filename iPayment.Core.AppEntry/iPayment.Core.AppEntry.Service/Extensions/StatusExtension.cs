using System;
using iPayment.Core.AppEntry.Service.Enums;

namespace iPayment.Core.AppEntry.Service.Extensions
{
    public static class StatusExtension
    {
        internal static Status OperationStatus(this Object obj)
        {
            return obj == null ? Status.Created : Status.Updated;
        }
    }
}