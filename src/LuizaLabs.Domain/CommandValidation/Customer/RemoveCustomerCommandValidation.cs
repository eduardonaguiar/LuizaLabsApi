using LuizaLabs.Domain.Commands.Customer;

namespace LuizaLabs.Domain.CommandValidation.Customer
{
    public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand>
    {
        public RemoveCustomerCommandValidation()
        {
            ValidateId();
        }
    }
}
