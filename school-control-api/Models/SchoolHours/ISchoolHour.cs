using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Entities;

namespace school_control_net.Models.SchoolHours
{
    public interface ISchoolHour
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Day Day { get; set; }
    }
}