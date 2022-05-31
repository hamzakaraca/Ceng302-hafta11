using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class WareHouseValidator : AbstractValidator<WareHouse>
    {
        public WareHouseValidator()
        {
            
            RuleFor(w => w.WareHouseName).MinimumLength(4);
        }
    }
}
