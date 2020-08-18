using Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Validators.Commands
{
    public class CreateMemberTaskCommandValidator : AbstractValidator<CreateMemberTaskCommand>
    {
        public CreateMemberTaskCommandValidator()
        {
            RuleFor(x => x.AssignedToId).NotNull().NotEmpty();
            RuleFor(x => x.IsComplete).NotNull().NotEmpty();
            RuleFor(x => x.Subject).NotNull().NotEmpty();
            //RuleFor(x => x.Subject).EmailAddress().NotNull().NotEmpty();
            //RuleFor(x => x.).NotNull().NotEmpty();
        }
    }


    
}
