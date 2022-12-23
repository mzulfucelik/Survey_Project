using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;
using FluentValidation;
using Survey_Project.Core.Services;

namespace Survey_Project.Service.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyPassword} is required").NotEmpty().WithMessage("{PropertyPropertyPassword} is required");
            RuleFor(x => x.EMail).NotEmpty().WithMessage("{PropertyEMail} is required").NotEmpty().WithMessage("{PropertyPropertyEMail is required");

        }
    }
}
