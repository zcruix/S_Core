using AutoMapper;
using iPayment.Core.AppEntry.Data.Model;
using iPayment.Core.AppEntry.Domain.Interfaces;

namespace iPayment.Core.AppEntry.Data.Mappers
{
    public static class GeneralInformationMapper
    {
        public static GeneralInformationDataModel ConvertToGeneralInfoDataModel(this IGeneralInformation generalInformation)
        {
            return Mapper.DynamicMap<GeneralInformationDataModel>(generalInformation);
        }
    }
}
