using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using school_control_net.Commands.Teachers;

namespace school_control_net.Controllers
{
      public class TeacherController : BaseController
      {
            public TeacherController(ILogger<BaseController> logger) : base(logger)
            {
            }

            [HttpPost]
            public async Task<ActionResult> post(CreateTeacherCommand command) 
                  => await ProcessCommandAsync(command);
      }
}