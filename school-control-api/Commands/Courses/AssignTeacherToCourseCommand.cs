using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using school_control_net.Entities;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

namespace school_control_net.Commands.Courses
{
    public class AssignTeacherToCourseCommand : IRequest<Result<Course>>
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
    }

	public class AssignTeacherToCourseCommandHandler :
		IRequestHandler<AssignTeacherToCourseCommand, Result<Course>>
	{
		private readonly ICourseService courseService;

		public AssignTeacherToCourseCommandHandler(ICourseService courseService)
        {
			this.courseService = courseService;
		}

		public async Task<Result<Course>> Handle(AssignTeacherToCourseCommand request, CancellationToken cancellationToken)
		{
			return await courseService.AssignTeacher(request.TeacherId, request.CourseId);
		}
	}
}