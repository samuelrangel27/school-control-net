using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Entities;
using school_control_net.Models.Courses;
using school_control_net.Utils;

namespace school_control_net.Services.Interfaces
{
    public interface ICourseService
    {
        Task<Result<Course>> add(CourseInput course);
        Task<Result<Course>> AssignTeacher(int teacherId, int courseId);
    }
}