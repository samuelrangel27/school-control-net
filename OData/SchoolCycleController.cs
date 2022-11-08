using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.DbContexts;
using school_control_net.Entities;

namespace school_control_net.OData
{
      public class SchoolCycleController : ODataBaseController<SchoolCycle>
      {
            public SchoolCycleController(SchoolDbContext dbContext, ILogger<ODataBaseController<SchoolCycle>> logger) : base(dbContext, logger)
            {
            }
      }
}