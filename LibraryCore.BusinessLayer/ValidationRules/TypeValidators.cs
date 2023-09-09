﻿using FluentValidation;
using LibraryCore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = LibraryCore.EntityLayer.Concrete.Type;

namespace LibraryCore.BusinessLayer.ValidationRules
{
    internal class TypeValidators : AbstractValidator<Type>
    {
        public TypeValidators()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Tür ismi boş bırakılamaz.");
            RuleFor(t => t.Name).MinimumLength(2).WithMessage("Tür ismi en az 2 karakter içermelidir.");
        }
    }
}