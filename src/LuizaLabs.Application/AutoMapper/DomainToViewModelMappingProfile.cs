using AutoMapper;
using LuizaLabs.Application.ViewModels;
using LuizaLabs.Domain.Models;

namespace LuizaLabs.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
