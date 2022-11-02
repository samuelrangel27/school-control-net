using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.DbContexts;
using school_control_net.Entities;

namespace school_control_net.OData
{
      public class StudentController : ODataBaseController<Student>
      {
            public StudentController(SchoolDbContext dbContext, 
                ILogger<ODataBaseController<Student>> logger) : base(dbContext, logger)
            {
            }
      }
}