using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class StorageValidator : AbstractValidator<Storage>
    {
        public StorageValidator()
        {
            
            RuleFor(s => s.CargoId).NotEmpty();
        }
    }
}
