using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using school_control_net.Commands.Students;

namespace school_control_net.Controllers
{
      public class StudentController : BaseController
      {
            public StudentController(ILogger<BaseController> logger) : base(logger)
            {
            }

            [HttpPost]
            public async Task<ActionResult> post(CreateStudentCommand command) 
                  => await ProcessCommandAsync(command);
      }
}