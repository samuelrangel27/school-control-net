using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using school_control_net.Commands.Courses;

namespace school_control_net.Controllers
{
      public class CourseController : BaseController
      {
            public CourseController(ILogger<BaseController> logger) : base(logger)
            {
            }

            [HttpPost]
            public async Task<ActionResult> post(CreateCourseCommand command) 
                  => await ProcessCommandAsync(command);
      }
}