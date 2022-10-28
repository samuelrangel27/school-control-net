using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_control_net.Entities
{
    public class Course : BaseEntity<int>
    {
        public string Description { get; set; }
        public Teacher Teacher { get; set; }
        public Classes Class { get; set; }
        public IList<Student> Students { get; set; }
        public SchoolCycle Cycle { get; set; }
    }
}