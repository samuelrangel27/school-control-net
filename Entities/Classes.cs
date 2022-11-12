using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_control_net.Entities
{
    public class Classes : BaseEntity<int>
    {
        public string Name { get; set; }
        public int AcamedicValue { get; set; }
        public int WeeklyHours { get; set; }
        public IList<Course> Courses { get; set; }
    }
}