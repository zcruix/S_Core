using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Domain.Extensions
{
    public static class ValidationResultsExtension
    {
        public static bool IsValid(this ValidationResult vr,  ICollection<IError> errorList)
        {
            if (vr.IsValid || vr.Errors == null) return vr.IsValid;

            var errors = vr.Errors.ToList();

            errors.ForEach(
                e =>
                    errorList.Add(new Error
                    {
                        ErrorMessage = e.ErrorMessage,
                        FieldName = e.PropertyName,
                        FieldValue = e.AttemptedValue,
                        State = e.CustomState                        
                    }));

            return vr.IsValid;
        }
    }
}