using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;
using ent = school_control_net.Entities;

namespace school_control_net.Commands.Classes
{
      public class CreateClassCommand : IRequest<Result<ent.Classes>>
      {
            public string Name { get; set; }
            public int AcamedicValue { get; set; }
      }

      public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, Result<ent.Classes>>
      {
            private readonly IClassesService classesService;

            public CreateClassCommandHandler(IClassesService classesService)
            {
                  this.classesService = classesService;
            }
            
            public async Task<Result<ent.Classes>> Handle(CreateClassCommand request, CancellationToken cancellationToken)
            {
                  return await this.classesService.add(request);
            }
      }


}