using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Commands.Teachers;
using school_control_net.DbContexts;
using school_control_net.Entities;
using school_control_net.Models.Teachers;
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
            public async Task<Result<Teacher>> add(TeacherInput teacher)
            {
                  var newTeacher = new Teacher{
                        Name = teacher.Name,
                        StartDate = teacher.StartDate
                  };
                  await dbContext.Teachers.AddAsync(newTeacher);
                  await dbContext.SaveChangesAsync();
                  return Result<Teacher>.Ok(MsgConstants.SUCCESS, newTeacher);
            }

            public Result<Teacher> GetbyId(int id)
            {
                  var teacher = dbContext.Teachers.FirstOrDefault(x => x.Id == id);
                  if(teacher != null)
                        return Result<Teacher>.Ok(MsgConstants.SUCCESS,teacher);
                  else
                        return Result<Teacher>.Fail(string.Format(MsgConstants.NOTFOUND_WITH_ID,"Teacher",id));
            }
      }
}