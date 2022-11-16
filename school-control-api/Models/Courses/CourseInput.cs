using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Models.SchoolHours;

namespace school_control_net.Models.Courses
{
    public class CourseInput
    {
        public string Description { get; set; }
        public int? TeacherId { get; set; }
        public int ClassId { get; set; }
        public IEnumerable<SchoolHourInput> SchoolHours { get; set; }
    }
}