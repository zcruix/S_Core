using AutoMapper;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.DTO;

namespace iPayment.Core.Services.AppEntry.Mappers
{
    public static class ErrorMapper
    {
        public static ErrorDto MapErrorDto(IError error)
        {
            return Mapper.DynamicMap<ErrorDto>(error);
        }
    }
}