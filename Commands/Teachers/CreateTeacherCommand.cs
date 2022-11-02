using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using school_control_net.Entities;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

namespace school_control_net.Commands.Teachers
{
      public class CreateTeacherCommand : IRequest<Result<Teacher>>
      {
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
      }

      public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, Result<Teacher>>
      {
            private readonly ITeacherService teacherService;

            public CreateTeacherCommandHandler(ITeacherService teacherService)
            {
                  this.teacherService = teacherService;
            }

            public async Task<Result<Teacher>> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
            {
                  return await this.teacherService.save(request);
            }
      }
}