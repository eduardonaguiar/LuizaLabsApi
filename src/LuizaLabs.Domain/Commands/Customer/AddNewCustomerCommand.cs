using LuizaLabs.Domain.CommandValidation.Customer;
using System;

namespace LuizaLabs.Domain.Commands.Customer
{
    public class AddNewCustomerCommand : CustomerCommand
    {
        public AddNewCustomerCommand(string name, string email)
        {
            Name = name;
            Email = email;            
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
