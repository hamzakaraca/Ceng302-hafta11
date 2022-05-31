using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class WorkingValidator : AbstractValidator<Working>
    {
        public WorkingValidator()
        {
            
            RuleFor(w => w.EmployeeId).NotEmpty();
            RuleFor(w => w.PortId).NotEmpty();
        }
    }
}
