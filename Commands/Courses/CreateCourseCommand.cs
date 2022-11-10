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
    public class CreateCourseCommand : IRequest<Result<Course>>
    {
        public string Description { get; set; }
        public int? TeacherId { get; set; }
        public int ClassId { get; set; }
    }

    public class CreateCourseCommandHandler 
        : IRequestHandler<CreateCourseCommand, Result<Course>>
    {
        private readonly ICourseService courseService;

        public CreateCourseCommandHandler(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        public async Task<Result<Course>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            return await courseService.add(request);
        }
    }
}