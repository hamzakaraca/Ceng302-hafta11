using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CheckOutValidator : AbstractValidator<CheckOut>
    {
        public CheckOutValidator()
        {
            RuleFor(c => c.PortId).NotEmpty();
        }
    }
}
