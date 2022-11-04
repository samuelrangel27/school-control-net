using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using school_control_net.Entities;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

namespace school_control_net.Commands.SchoolCycles
{
    public class CreateCycleCommand : IRequest<Result<SchoolCycle>>
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CreateCycleCommandHandler : IRequestHandler<CreateCycleCommand, Result<SchoolCycle>>
    {
        private readonly ISchoolCycleService schoolCycleService;

        public CreateCycleCommandHandler(ISchoolCycleService schoolCycleService)
        {
            this.schoolCycleService = schoolCycleService;
        }

        public Task<Result<SchoolCycle>> Handle(CreateCycleCommand request, CancellationToken cancellationToken)
        {
            return schoolCycleService.add(request);
        }
    }
}