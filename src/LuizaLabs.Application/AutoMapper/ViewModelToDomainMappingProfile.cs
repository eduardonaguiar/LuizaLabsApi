using AutoMapper;
using LuizaLabs.Application.ViewModels;
using LuizaLabs.Domain.Commands.Customer;

namespace LuizaLabs.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AddCustomerViewModel, AddNewCustomerCommand>()
                .ConstructUsing(c => new AddNewCustomerCommand(c.Name, c.Email));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email));
        }
    }
}
