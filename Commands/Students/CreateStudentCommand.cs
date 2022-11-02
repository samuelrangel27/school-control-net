using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using school_control_net.Entities;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

namespace school_control_net.Commands.Students
{
    public class CreateStudentCommand : IRequest<Result<Student>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
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
                  return await this.studentService.save(request);
            }
      }
}