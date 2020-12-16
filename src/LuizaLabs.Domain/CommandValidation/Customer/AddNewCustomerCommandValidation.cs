using LuizaLabs.Domain.Commands.Customer;

namespace LuizaLabs.Domain.CommandValidation.Customer
{
    public class AddNewCustomerCommandValidation : CustomerValidation<AddNewCustomerCommand>
    {
        public AddNewCustomerCommandValidation()
        {
            ValidateEmail();
        }
    }
}

