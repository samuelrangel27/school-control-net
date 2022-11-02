using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using school_control_net.DbContexts;
using school_control_net.Entities;

namespace school_control_net.OData
{
      public class ClassesController : ODataBaseController<Classes>
      {
            public ClassesController(SchoolDbContext dbContext, 
                ILogger<ODataBaseController<Classes>> logger) : base(dbContext, logger)
            {
            }
      }
}