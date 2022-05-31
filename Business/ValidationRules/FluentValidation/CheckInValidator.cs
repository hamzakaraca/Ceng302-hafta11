using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CheckInValidator : AbstractValidator<CheckIn>
    {
        public CheckInValidator()
        {
            RuleFor(c => c.EntryDate).NotEmpty();
            RuleFor(c => c.PortId).NotEmpty();
            RuleFor(c => c.ShipId).NotEmpty();
        }
    }
}
