using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_control_net.Entities
{
    public class Student : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IList<Course> Courses { get; set; }
    }
}