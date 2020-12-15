using LuizaLabs.Domain.Commands.Customer;
using LuizaLabs.Domain.CommandValidation.Customer;

namespace LuizaLabs.CommandValidation.CommandValidation
{
    public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            ValidateId();
            ValidateEmail();
        }
    }
}
