using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_control_net.Entities
{
    public class SchoolCycle : BaseEntity<int>
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SchoolCycleStatus Status { get; set; }
        public IList<Course> Courses { get; set; }
        
    }

    public enum SchoolCycleStatus{
        New = 1,
        Open,
        Closed
    }
}