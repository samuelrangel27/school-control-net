using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Commands.Courses;
using school_control_net.DbContexts;
using school_control_net.Entities;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

namespace school_control_net.Services
{
    public class CourseService : ICourseService
    {
        private readonly SchoolDbContext context;
        private readonly ITeacherService teacherService;
        private readonly IClassesService classesService;

        public CourseService(SchoolDbContext context,
            ITeacherService teacherService,
            IClassesService classesService)
        {
            this.classesService = classesService;
            this.teacherService = teacherService;
            this.context = context;
        }
        
        public async Task<Result<Course>> add(CreateCourseCommand course)
        {
            // get open cycle
            var openCycle = context.SchoolCycles.FirstOrDefault(x => x.Status == SchoolCycleStatus.Open);
            var errors = new List<string>();
            var newCourse = new Course
            {
                Description = course.Description
            };
                
            if(openCycle == null)
                errors.Add("No open cycle found");
            else
                newCourse.Cycle = openCycle;

            if(course.TeacherId.HasValue)
            {
                var teacherResult = teacherService.GetbyId(course.TeacherId.Value);
                if(teacherResult.IsSuccess)
                    newCourse.Teacher = teacherResult.Data;
                else
                    errors.Add(teacherResult.Message);
            }

            var classResult = classesService.GetById(course.ClassId);
            if(classResult.IsSuccess)
                newCourse.Class = classResult.Data;
            else
                errors.Add(classResult.Message);
            
            if(errors.Count > 0)
            {
                return Result<Course>.Fail("One or more errors occured when trying to add the course", errors);
            }

            context.Courses.Add(newCourse);
            await context.SaveChangesAsync();
            return Result<Course>.Ok(MsgConstants.SUCCESS, newCourse);
        }
    }
}