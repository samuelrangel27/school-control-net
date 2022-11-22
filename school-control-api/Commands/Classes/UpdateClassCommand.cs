using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using school_control_net.Models.Classes;
using school_control_net.Models.Courses;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;
using ent = school_control_net.Entities;

namespace school_control_net.Commands.Classes
{
    public class UpdateClassCommand : UpdateClassInput, IRequest<Result<ent.Classes>>
    {
    }

	public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, Result<ent.Classes>>
	{
		private readonly IClassesService classesService;

		public UpdateClassCommandHandler(IClassesService classesService)
        {
			this.classesService = classesService;
		}
		public async Task<Result<ent.Classes>> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
		{
			return await classesService.update(request);
		}
	}
}