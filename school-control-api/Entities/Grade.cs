using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_control_net.Entities
{
    public class Grade : BaseEntity<int>
    {
        public float GradeValue { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}