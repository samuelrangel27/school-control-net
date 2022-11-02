using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Commands.Classes;
using school_control_net.DbContexts;
using school_control_net.Entities;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

namespace school_control_net.Services
{
      public class ClassesService : IClassesService
      {
            private readonly SchoolDbContext dbContext;

            public ClassesService(SchoolDbContext dbContext)
            {
                  this.dbContext = dbContext;
            }
            public async Task<Result<Classes>> save(CreateClassCommand classInput)
            {
                  var newClass = new Classes{
                        Name = classInput.Name,
                        AcamedicValue = classInput.AcamedicValue
                  };
                  await dbContext.Classes.AddAsync(newClass);
                  await dbContext.SaveChangesAsync();
                  return Result<Classes>.Ok(MsgConstants.SUCCESS, newClass);
            }
      }
}