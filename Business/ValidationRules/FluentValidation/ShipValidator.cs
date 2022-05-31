using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ShipValidator : AbstractValidator<Ship>
    {
        public ShipValidator()
        {
            
            RuleFor(s => s.Name).MinimumLength(2);
            RuleFor(s => s.Curator).MinimumLength(2);
        }
    }
}
