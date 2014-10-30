using AutoMapper;
using iPayment.Core.AppEntry.Domain;
using iPayment.Core.AppEntry.Domain.Interfaces;
using iPayment.Core.AppEntry.DTO;
using iPayment.Core.AppEntry.DTO.Requests;

namespace iPayment.Core.Services.AppEntry.Mappers
{
    public static class ApplicationFormMapper
    {
        static ApplicationFormMapper()
        {
            Mapper.CreateMap<IApplicationForm, ApplicationFormResponseDto>();
            Mapper.CreateMap<ApplicationFormRequestDto, IApplicationForm>().ConstructUsing((ResolutionContext c) => new ApplicationForm());
        }

        public static IApplicationForm ConvertToApplicationForm(this ApplicationFormRequestDto applicationFormRequestDto)
        {
            return Mapper.DynamicMap<IApplicationForm>(applicationFormRequestDto);
        }

        public static ApplicationFormResponseDto ConvertToApplicationFormDto(this IApplicationForm applicationForm)
        {
            return Mapper.DynamicMap<ApplicationFormResponseDto>(applicationForm);
        }
    }
}