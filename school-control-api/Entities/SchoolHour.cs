using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Models.SchoolHours;

namespace school_control_net.Entities
{
    public class SchoolHour : BaseEntity<int>, ISchoolHour
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Day Day { get; set; }
    }
    public enum Day
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }
}