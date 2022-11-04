using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Commands.SchoolCycles;
using school_control_net.Entities;
using school_control_net.Utils;

namespace school_control_net.Services.Interfaces
{
    public interface ISchoolCycleService
    {
        Task<Result<SchoolCycle>> add(CreateCycleCommand cycle);
        
    }
}