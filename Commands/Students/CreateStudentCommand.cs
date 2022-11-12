using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using school_control_net.Entities;
using school_control_net.Models.Students;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

namespace school_control_net.Commands.Students
{
      public class CreateStudentCommand : StudentInput, IRequest<Result<Student>>
      {

      }

      public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Result<Student>>
      {
            private readonly IStudentService studentService;

            public CreateStudentCommandHandler(IStudentService studentService)
            {
                  this.studentService = studentService;
            }

            public async Task<Result<Student>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
            {
                  return await this.studentService.add(request);
            }
      }
}