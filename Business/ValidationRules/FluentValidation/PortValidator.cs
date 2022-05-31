using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PortValidator : AbstractValidator<Port>
    {
        public PortValidator()
        {
            
            RuleFor(p => p.PortName).MinimumLength(3);

        }
    }
}
