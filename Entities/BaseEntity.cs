using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace school_control_net.Entities
{
    public abstract class BaseEntity<TKey>
    {
        [Key]
        public virtual TKey Id { get; set; }
    }
}