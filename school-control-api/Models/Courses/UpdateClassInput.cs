using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Models.Classes;

namespace school_control_net.Models.Courses
{
    public class UpdateClassInput : ClassInput
    {
        public int Id { get; set; }
    }
}