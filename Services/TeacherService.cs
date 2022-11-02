using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Commands.Teachers;
using school_control_net.DbContexts;
using school_control_net.Entities;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

namespace school_control_net.Services
{
      public class TeacherService : ITeacherService
      {
            private readonly SchoolDbContext dbContext;

            public TeacherService(SchoolDbContext dbContext)
            {
                  this.dbContext = dbContext;
            }
            public async Task<Result<Teacher>> save(CreateTeacherCommand teacher)
            {
                  var newTeacher = new Teacher{
                        Name = teacher.Name,
                        StartDate = teacher.StartDate
                  };
                  await dbContext.Teachers.AddAsync(newTeacher);
                  await dbContext.SaveChangesAsync();
                  return Result<Teacher>.Ok(MsgConstants.SUCCESS, newTeacher);
            }
      }
}