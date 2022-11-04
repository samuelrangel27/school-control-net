using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Commands.Students;
using school_control_net.Entities;
using school_control_net.Utils;

namespace school_control_net.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Result<Student>> add(CreateStudentCommand classInput);
    }
}