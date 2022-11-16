using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using school_control_net.Entities;
using school_control_net.Models.Teachers;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

namespace school_control_net.Commands.Teachers
{
      public class CreateTeacherCommand : TeacherInput, IRequest<Result<Teacher>>
      {
            
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
                  return await this.teacherService.add(request);
            }
      }
}