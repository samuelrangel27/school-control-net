using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.DbContexts;
using school_control_net.Entities;

namespace school_control_net.OData
{
      public class TeacherController : ODataBaseController<Teacher>
      {
            public TeacherController(SchoolDbContext dbContext, ILogger<ODataBaseController<Teacher>> logger) : base(dbContext, logger)
            {
            }
      }
}