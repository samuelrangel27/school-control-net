using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Commands.Teachers;
using school_control_net.Entities;
using school_control_net.Models.SchoolHours;
using school_control_net.Models.Teachers;
using school_control_net.Utils;

namespace school_control_net.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<Result<Teacher>> add(TeacherInput classInput);
        Result<Teacher> GetbyId(int id);
        Result<List<ISchoolHour>> GetTeacherSchedule(int id);
    }
}