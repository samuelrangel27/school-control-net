using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using school_control_net.Commands.SchoolCycles;

namespace school_control_net.Controllers
{
      public class SchoolCycleController : BaseController
      {
            public SchoolCycleController(ILogger<BaseController> logger) 
                : base(logger)
            {
            }

            [HttpPost]
            public async Task<ActionResult> post(CreateCycleCommand command) 
                  => await ProcessCommandAsync(command);

            [HttpPut("open")]
            public async Task<ActionResult> open(OpenSchoolCycleCommand command) 
                  => await ProcessCommandAsync(command);
      }
}