using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_control_net.Entities
{
    public class Teacher : BaseEntity<int>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public IList<Course> Courses { get; set; }
    }
}