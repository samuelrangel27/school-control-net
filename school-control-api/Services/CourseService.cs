using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Commands.Courses;
using school_control_net.DbContexts;
using school_control_net.Entities;
using school_control_net.Models.Courses;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;
using Microsoft.EntityFrameworkCore;

namespace school_control_net.Services
{
    [ScopedRegistration]
    public class CourseService : ICourseService
    {
        private readonly SchoolDbContext context;
        private readonly ITeacherService teacherService;
        private readonly IClassesService classesService;
        private readonly ISchoolHourService schoolHourService;

        public CourseService(SchoolDbContext context,
            ITeacherService teacherService,
            ISchoolHourService schoolHourService,
            IClassesService classesService)
        {
            this.schoolHourService = schoolHourService;
            this.classesService = classesService;
            this.teacherService = teacherService;
            this.context = context;
        }
        
        public async Task<Result<Course>> add(CourseInput course)
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
            
            if(course.SchoolHours.Any())
            {
                var schoolHoursValidationResult = schoolHourService.ValidateHours(course.SchoolHours,newCourse.Class.WeeklyHours);
                if(schoolHoursValidationResult.IsError)
                {
                    errors.AddRange(schoolHoursValidationResult.Errors);
                }

                newCourse.SchoolHours = course.SchoolHours
                .Select(x => new SchoolHour
                {
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    Day = x.Day
                }).ToList();
            }

            if(errors.Count > 0)
            {
                return Result<Course>.Fail("One or more errors occured when trying to add the course", errors);
            }

            context.Courses.Add(newCourse);
            await context.SaveChangesAsync();
            return Result<Course>.Ok(MsgConstants.SUCCESS, newCourse);
        }

		public async Task<Result<Course>> AssignTeacher(int teacherId, int courseId)
		{
            var errors = new List<string>();
            var teacherResult = teacherService.GetbyId(teacherId);
            var course = context.Courses
                .Include(x => x.SchoolHours)
                .FirstOrDefault(x => x.Id == courseId);
            
            
            if(teacherResult.IsSuccess){
                var schedule = teacherService.GetTeacherSchedule(teacherId);
                var overlappedScheduleResult = schoolHourService.ValidateOverlappingSchedules(schedule.Data, course.SchoolHours);
            }
            else {
                errors.Add(teacherResult.Message);
            }
            
            if(errors.Any())
                return Result<Course>.Fail(MsgConstants.VALIDATION_ERRORS);
            
            course.Teacher = teacherResult.Data;
            await context.SaveChangesAsync();

            return Result<Course>.Ok(MsgConstants.SUCCESS, course);
		}

	}
}