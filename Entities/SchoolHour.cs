using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_control_net.Entities
{
    public class SchoolHour : BaseEntity<int>
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