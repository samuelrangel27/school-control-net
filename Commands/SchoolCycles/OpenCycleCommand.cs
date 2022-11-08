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
    public class OpenSchoolCycleCommand : IRequest<Result<SchoolCycle>>
    {
        
    }

    public class OpenSchoolCycleCommandHandler : IRequestHandler<OpenSchoolCycleCommand, Result<SchoolCycle>>
    {
        private readonly ISchoolCycleService schoolCycleService;
        public OpenSchoolCycleCommandHandler(ISchoolCycleService schoolCycleService)
        {
            this.schoolCycleService = schoolCycleService;
        }

        public async Task<Result<SchoolCycle>> Handle(OpenSchoolCycleCommand request, CancellationToken cancellationToken)
        {
            return await schoolCycleService.open();
        }
    }
}