using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Allocation> Allocations { get; set; }
    }
}
