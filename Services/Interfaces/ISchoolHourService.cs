using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Models.SchoolHours;
using school_control_net.Utils;

namespace school_control_net.Services.Interfaces
{
    public interface ISchoolHourService
    {
        Result<List<ISchoolHour>> ValidateHours(IEnumerable<ISchoolHour> hours, int maxHours);
    }
}