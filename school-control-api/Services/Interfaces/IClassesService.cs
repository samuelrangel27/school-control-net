using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Commands.Classes;
using school_control_net.Entities;
using school_control_net.Models.Classes;
using school_control_net.Models.Courses;
using school_control_net.Utils;

namespace school_control_net.Services.Interfaces
{
    public interface IClassesService
    {
        Task<Result<Classes>> add(CreateClassCommand classInput);
        Task<Result<Classes>> update(UpdateClassInput classInput);
        Result<Classes> GetById(int id);
    }
}