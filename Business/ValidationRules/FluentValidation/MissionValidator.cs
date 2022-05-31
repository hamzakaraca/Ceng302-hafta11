using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class MissionValidator : AbstractValidator<Mission>
    {
        public MissionValidator()
        {
            RuleFor(m => m.MissionClass).MinimumLength(3);
        }
    }
}
