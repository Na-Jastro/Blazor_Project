using AutoMapper;
using BlazorAV.Core.Models;
using BlazorAV.Models.Dtos;

namespace BlazorAV.Api.Helpers
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            MapInput();
            MapOutput();
        }
        private void MapInput()
        {
            CreateMap<CompanyDto, Company>();
            CreateMap<DesignationDto, Designation>();
        }
        private void MapOutput()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<ProtectionType, ProtectionTypeDto>();

            CreateMap<Designation, DesignationDto>()
                .ForMember(nameof(DesignationDto.CompanyName),
                p => p.MapFrom(p => p.Company.CompanyName));

            CreateMap<Client, ClientDto>()
                .ForMember(nameof(ClientDto.CompanyName),
                 p => p.MapFrom(p => p.Company.CompanyName))
                .ForMember(nameof(ClientDto.DesignationDescription),
                p => p.MapFrom(p => p.Designation.DesignationDescription))
                .ForMember(nameof(ClientDto.ProtectionDescription),
                p => p.MapFrom(p => p.ProtectionType.ProtectionDescription));
        }
    }
}
