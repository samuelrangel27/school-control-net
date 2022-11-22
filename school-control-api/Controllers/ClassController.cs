using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using school_control_net.Commands.Classes;

namespace school_control_net.Controllers
{
      public class ClassController : BaseController
      {
            public ClassController(ILogger<ClassController> logger) : base(logger)
            {
            }

            [HttpPost]
            public async Task<ActionResult> post(CreateClassCommand command) 
                  => await ProcessCommandAsync(command);

            [HttpPut]
            public async Task<ActionResult> put(UpdateClassCommand command) 
                  => await ProcessCommandAsync(command);
      }
}