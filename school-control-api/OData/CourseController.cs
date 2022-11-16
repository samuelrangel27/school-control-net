using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.DbContexts;
using school_control_net.Entities;

namespace school_control_net.OData
{
      public class CourseController : ODataBaseController<Course>
      {
            public CourseController(SchoolDbContext dbContext, 
                ILogger<ODataBaseController<Course>> logger) : base(dbContext, logger)
            {
            }
      }
}