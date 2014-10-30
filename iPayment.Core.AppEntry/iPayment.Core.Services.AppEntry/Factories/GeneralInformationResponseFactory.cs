using System.Linq;
using iPayment.Core.AppEntry.DTO;
using iPayment.Core.AppEntry.Service.Interfaces;
using iPayment.Core.Services.AppEntry.Mappers;

namespace iPayment.Core.Services.AppEntry.Factories
{
    public static class GeneralInformationResponseFactory
    {
        public static GeneralInformationDto ErrorDto(this IApplicationServiceContext serviceContext)
        {
            return new GeneralInformationDto
            {   Errors =
                    serviceContext.Errors.ToList()
                        .Select(ErrorMapper.MapErrorDto).ToList(),                       
            };
        }

        public static GeneralInformationDto SuccessDto(this IApplicationServiceContext serviceContext)
        {
            return serviceContext.ApplicationForm.GeneralInformation.ConvertToGeneralInfoDto();                        
        }
    }
}