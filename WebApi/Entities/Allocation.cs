using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Allocation
    {
        public Employee Employee { get; set; }
        public Project Project { get; set; }
        public double Percentage { get; set; }
    }
}
