using AutoMapper;
using iPayment.Core.AppEntry.DTO.Templates;
using Domain =iPayment.Core.AppEntry.Domain;
using iPayment.Core.AppEntry.Domain.Interfaces;
using DTO = iPayment.Core.AppEntry.DTO;

namespace iPayment.Core.Services.AppEntry.Mappers
{
    public static class MerchantGeneralInformationMapper
    {
        static MerchantGeneralInformationMapper()
        {
            Mapper.CreateMap<IGeneralInformation, DTO.GeneralInformationDto>();
            Mapper.CreateMap<IPhone, Phone>().ConstructUsing((ResolutionContext c) => new Phone());
            Mapper.CreateMap<IAddress, Address>().ConstructUsing((ResolutionContext c) => new Address());
            Mapper.CreateMap<IContinuousResidence, ContinuousResidence>().ConstructUsing((ResolutionContext c) => new ContinuousResidence());
            Mapper.CreateMap<IFederalTaxId, FederalTaxId>().ConstructUsing((ResolutionContext c) => new FederalTaxId());
            Mapper.CreateMap<IError, DTO.ErrorDto>().ConstructUsing((ResolutionContext c) => new DTO.ErrorDto()); 

            Mapper.CreateMap<DTO.GeneralInformationDto, Domain.GeneralInformation>();
            Mapper.CreateMap<Phone, IPhone>().ConstructUsing((ResolutionContext c) => new Domain.Phone());
            Mapper.CreateMap<Address, IAddress>().ConstructUsing((ResolutionContext c) => new Domain.Address());
            Mapper.CreateMap<ContinuousResidence, IContinuousResidence>().ConstructUsing((ResolutionContext c) => new Domain.ContinuousResidence());
            Mapper.CreateMap<FederalTaxId, IFederalTaxId>().ConstructUsing((ResolutionContext c) => new Domain.FederalTaxId());            
        }

        public static DTO.GeneralInformationDto ConvertToGeneralInfoDto(this IGeneralInformation generalInformation)
        {
            var generalInfoDto = new DTO.GeneralInformationDto();
            Mapper.Map(generalInformation, generalInfoDto);        
            return generalInfoDto;
        }

        public static IGeneralInformation ConvertToGeneralInfo(this DTO.GeneralInformationDto generalInformationDto)
        {
            var generalInformation = new Domain.GeneralInformation();
            Mapper.Map(generalInformationDto, generalInformation);
            return generalInformation;
        }
    }
}