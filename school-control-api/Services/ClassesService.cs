using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Commands.Classes;
using school_control_net.DbContexts;
using school_control_net.Entities;
using school_control_net.Models.Classes;
using school_control_net.Models.Courses;
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
            public async Task<Result<Classes>> add(CreateClassCommand classInput)
            {
                  var newClass = new Classes{
                        Name = classInput.Name,
                        AcademicValue = classInput.AcademicValue,
                        WeeklyHours = classInput.WeeklyHours
                  };
                  await dbContext.Classes.AddAsync(newClass);
                  await dbContext.SaveChangesAsync();
                  return Result<Classes>.Ok(MsgConstants.SUCCESS, newClass);
            }

            public Result<Classes> GetById(int id)
            {
                  var classes = dbContext.Classes.FirstOrDefault(x => x.Id == id);
                  if(classes != null)
                        return Result<Classes>.Ok(MsgConstants.SUCCESS, classes);
                  else
                        return Result<Classes>.Fail(string.Format(MsgConstants.NOTFOUND_WITH_ID, "Class", id));
            }

		public async Task<Result<Classes>> update(UpdateClassInput classInput)
		{
			var classesResult = this.GetById(classInput.Id);
                  if(classesResult.IsSuccess)
                  {
                        classesResult.Data.Name = classInput.Name;
                        classesResult.Data.AcademicValue = classInput.AcademicValue;
                        classesResult.Data.WeeklyHours = classInput.WeeklyHours;
                        dbContext.Classes.Update(classesResult.Data);
                        await dbContext.SaveChangesAsync();
                  }
                  return classesResult;
		}
	}
}