using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace school_control_net.Commands.SchoolCycles.Validators
{
    public class CreateCycleCommandValidator : AbstractValidator<CreateCycleCommand>
    {
        public CreateCycleCommandValidator()
        {
            // RuleFor(x => x.StartDate)
            //     .Must(x => x.)
        }
    }
}