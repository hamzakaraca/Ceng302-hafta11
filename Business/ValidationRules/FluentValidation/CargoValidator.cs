using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CargoValidator:AbstractValidator<Cargo>
    {
        public CargoValidator()
        {
            RuleFor(c => c.Sender).MinimumLength(3);
            RuleFor(c => c.Sender).NotEmpty();
        }
    }
}
