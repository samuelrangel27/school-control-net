using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_control_net.Utils
{
    public interface IUserFiltered
    {
        string UserId { get; set; }
        int? CustomerId { get; set; }
    }
}