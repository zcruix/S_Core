using System;
using iPayment.Core.AppEntry.Service.Enums;
using iPayment.Core.AppEntry.Service.Interfaces;

namespace iPayment.Core.AppEntry.Service.Extensions
{
    public static class ServiceContextExtension
    {
        public static void InvokeSave(this IApplicationServiceContext context, Action doSave, Status status)
        {
            doSave.Invoke();
            context.Status = status;
        }
    }
}