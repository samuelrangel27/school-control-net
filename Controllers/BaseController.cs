using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using school_control_net.Utils;

namespace school_control_net.Controllers
{
      [ApiController]
      [Route("api/[controller]")]
      public abstract class BaseController : ControllerBase
      {
            private readonly ILogger<BaseController> _logger;
            private IMediator _mediator;
            protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

            public BaseController(ILogger<BaseController> logger)
            {
                  this._logger = logger;
            }

            protected async Task<ActionResult> ProcessCommandAsync<TResponse>(IRequest<Result<TResponse>> command)
            where TResponse : class
            {
                  try
                  {
                        // if(command is IUserFiltered)
                        // {
                        //     (command as IUserFiltered).UserId = GetUserId();
                        //     (command as IUserFiltered).CustomerId = GetCustomerId();
                        // }

                        var response = await Mediator.Send(command);
                        HttpContext.Response.StatusCode = (int)response.State;
                        return new JsonResult(response);
                  }
                  catch (Exception e)
                  {
                        var error = Result<TResponse>.Fail("Internal server error", new List<string> { "Something went wrong when processing the request. Please, try again later" }, HttpStatusCode.InternalServerError);
                        _logger.LogError(e, "Error {error}", error);
                        HttpContext.Response.StatusCode = 500;
                        return new JsonResult(error);
                  }
            }
      }
}